using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Items;

namespace Server.Engines.Combat
{
    public class StrategyMonstreMelee : CombatStrategy
    {
        protected StrategyMonstreMelee() { }

        public readonly static CombatStrategy Strategy = new StrategyMonstreMelee();

        public override bool OnFired(Mobile atk, Mobile def)
        {
            return false;
        }

        protected override void CheckEquitationAttaque(Mobile atk)
        {            
        }

        public override SkillName ToucherSkill
        {
            get { return SkillName.Epee; }
        }

        protected override void AppliquerPoison(Mobile atk, Mobile def)
        {
            BaseWeapon weapon = Weapon(atk);
            Poison poison = weapon.Poison;
            if (poison != null)
            {
                if (!def.Poisoned || poison.Level > def.Poison.Level)
                {
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
                    if (chance < 0)
                        chance = 0;
                    chance = chance / 100;
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

        protected override double ParerChance(Mobile def)
        {
            return 0;
        }

        public override int Range(Mobile atk)
        {
            BaseCreature monstre = atk as BaseCreature;
            return monstre.RangeFight;
        }
    }

    public class StrategyMonstreDist : StrategyDistance
    {
        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        protected StrategyMonstreDist() { }

        public readonly static CombatStrategy Strategy = new StrategyMonstreDist();

        protected override void CheckEquitationAttaque(Mobile atk)
        {
        }

        public override SkillName ToucherSkill
        {
            get { return SkillName.Epee; }
        }

        protected override void AppliquerPoison(Mobile atk, Mobile def)
        {
        }

        protected override double ParerChance(Mobile def)
        {
            return 0;
        }

        public override bool OnFired(Mobile atk, Mobile def)
        {
            def.PublicOverheadMessage(Network.MessageType.Regular, 0, true, "Herp derp");

            atk.MovingEffect( def, EffectID, 18, 1, false, false );

			return true;
        }

        public override int Range(Mobile atk)
        {
            BaseCreature monstre = atk as BaseCreature;
            return monstre.RangeFight;
        }
    }


}
