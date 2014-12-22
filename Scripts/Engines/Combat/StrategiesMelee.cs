using Server.Engines.Equitation;
using Server.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Combat
{
    public abstract class StrategyMelee : CombatStrategy
    {
        protected override double BaseParerChance(Mobile def)
        {
            double parry = def.Skills[SkillName.Parer].Value;
            double chance = 0;

            if (Weapon(def).Layer == Layer.OneHanded)
                chance = GetBonus(parry, 0.6, 5);
            else
                chance = GetBonus(parry, 0.15, 2.5);

            return chance;
        }

        protected override void AppliquerPoison(Mobile atk, Mobile def)
        {
            BaseWeapon weapon = Weapon(atk);
            Poison poison = weapon.Poison;
            if (poison != null && weapon.PoisonCharges > 0)
			{
                if (!def.Poisoned || poison.Level > def.Poison.Level)
                {
                    --weapon.PoisonCharges;

                    double skill = atk.Skills.Empoisonnement.Value;
                    bool selfdmg = false;
                    double chance = 0;
                    switch (poison.Level)
                    { //peut probablement rendre ca plus compact en utilisant regularite.
                        case 0: //Lesser
                            if (skill > 30) 
                                chance = 80;
                            else
                                chance = 20 + skill * 2;
                            break;
                        case 1: //Regular
                            if (skill < 10)
                            {
                                selfdmg = true;
                                chance = 10 - skill;
                            }
                            else if (skill < 30)
                                chance = 0;
                            else if (skill > 60)
                                chance = 80;
                            else
                                chance = 20 + (skill - 30) * 2;
                            break;
                        case 2: //Greater
                            if (skill < 40)
                            {
                                selfdmg = true;
                                chance = 40 - skill;
                            }
                            else if (skill < 60)
                                chance = 0;
                            else if (skill > 90)
                                chance = 80;
                            else
                                chance = 20 + (skill - 60) * 2;
                            break;
                        case 3: //Deadly
                            if (skill < 70)
                            {
                                selfdmg = true;
                                chance = 70 - skill;
                            }
                            else if (skill < 90)
                                chance = 0;
                            else if (skill > 100)
                                chance = 40;
                            else
                                chance = 20 + (skill - 90) * 2;
                            break;
                        case 4: //Lethal
                            if (skill < 90)
                            {
                                selfdmg = true;
                                chance = 90 - skill;
                            }
                            else if (skill <= 100)
                                chance = 0;
                            else
                                chance = 20 + (skill - 100) * 2;
                            break;
                    }
                    if(chance < 0)
                        chance = 0;
                    chance = chance/100;
                    if (selfdmg)
                    {
                        if (Utility.RandomDouble() > chance)
                            atk.ApplyPoison(atk, poison);
                    }
                    else
                        if (atk.CheckSkill(SkillName.Empoisonnement, chance))
                            def.ApplyPoison(atk, poison);
                }
			}
        }

        protected override void CheckEquitationAttaque(Mobile atk)
        {
            CheckEquitation(atk, EquitationType.Attacking);
        }

        public override bool OnFired(Mobile atk, Mobile def)
        {
            return false;
        }
    }

    public class StrategyPerforante : StrategyMelee
    {
        protected StrategyPerforante() { }

        private static CombatStrategy m_Strategy = new StrategyPerforante();
        public static CombatStrategy Strategy { get { return m_Strategy; } }

        public override SkillName ToucherSkill { get { return SkillName.ArmePerforante; } }

        public override double CritiqueChance(Mobile atk)
        {
            double chance = base.CritiqueChance(atk);
            double incChance = GetBonus(atk.Skills[SkillName.ArmePerforante].Value, 0.05, 5);
            return IncValueDimReturn(chance, incChance);
        }
    }

    public class StrategyTranchante : StrategyMelee
    {
        protected StrategyTranchante() { }

        public readonly static CombatStrategy Strategy = new StrategyTranchante();
        
        public override SkillName ToucherSkill { get { return SkillName.Epee; } }

        protected override double ToucherChance(Mobile atk, Mobile def)
        {
            double chance = base.ToucherChance(atk, def);
            double incChance = GetBonus(atk.Skills[SkillName.Epee].Value, 0.05, 5);
            return IncreasedValue(chance, incChance);
        }
    }

    public class StrategyContondante : StrategyMelee
    {
        protected StrategyContondante() { }

        public readonly static CombatStrategy Strategy = new StrategyContondante();
        
        public override SkillName ToucherSkill { get { return SkillName.ArmeContondante; } }

        public override double DegatsReduits(Mobile atk, Mobile def, double dmg)
        {
            double contpen = GetBonus(atk.Skills[SkillName.ArmeContondante].Value, 0.05, 5);
            return Damage.instance.DegatsPhysiquesReduits(atk, def, dmg, contpen);
        }
    }

    public class StrategyHaste : StrategyMelee
    {
        protected StrategyHaste() { }

        public readonly static CombatStrategy Strategy = new StrategyHaste();
        
        public override SkillName ToucherSkill { get { return SkillName.ArmeHaste; } }

        public override int BaseRange { get { return 2; } }

        public override int Range(Mobile atk)
        {
            if (atk.Mounted)
                return base.BaseRange;
            return BaseRange;
        }
    }

    public class StrategyHache : StrategyMelee
    {
        protected StrategyHache() { }

        public readonly static CombatStrategy Strategy = new StrategyHache();
        
        public override SkillName ToucherSkill { get { return SkillName.Hache; } }

        protected override double ComputerDegats(Mobile atk, double basedmg, bool skillup)
        {
            double dmg = base.ComputerDegats(atk, basedmg, skillup);
            double foresterieBonus = GetBonus(atk.Skills[SkillName.Hache].Value, 0.2, 10);

            return dmg + basedmg * foresterieBonus;
        }
    }
}
