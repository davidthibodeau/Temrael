using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Items;

namespace Server.Engines.Combat
{
    public abstract class StrategyMonstre : CombatStrategy
    {
        protected override void CheckEquitationAttaque(Mobile atk)
        {
        }

        public override SkillName ToucherSkill
        {
            get { return SkillName.Epee; }
        }

        public override int Range(Mobile atk)
        {
            BaseCreature monstre = atk as BaseCreature;
            return monstre.MaxRange;
        }
    }

    public class StrategyMonstreMelee : StrategyMonstre
    {
        protected StrategyMonstreMelee() { }

        public readonly static CombatStrategy Strategy = new StrategyMonstreMelee();

        public override bool OnFired(Mobile atk, Mobile def)
        {
            return false;
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
    }

    public class StrategyMonstreDist : StrategyMonstre
    {
        public int EffectID { get { return 0xF42; } }
        public Type AmmoType { get { return typeof(Arrow); } }
        public Item Ammo { get { return new Arrow(); } }

        protected StrategyMonstreDist() { }

        public readonly static CombatStrategy Strategy = new StrategyMonstreDist();

        protected override void AppliquerPoison(Mobile atk, Mobile def)
        {
        }

        public override void OnHit(Mobile atk, Mobile def)
        {
			if ( atk.Player && !def.Player && (def.Body.IsAnimal || def.Body.IsMonster) && 0.4 >= Utility.RandomDouble() )
				def.AddToBackpack( Ammo );

            base.OnHit(atk, def);
        }

        public override void OnMiss(Mobile atk, Mobile def)
        {
            if (atk.Player && 0.4 >= Utility.RandomDouble())
            {
                Ammo.MoveToWorld(new Point3D(def.X + Utility.RandomMinMax(-1, 1), def.Y + Utility.RandomMinMax(-1, 1), def.Z), def.Map);
            }

            base.OnMiss(atk, def);
        }

        public override bool OnFired(Mobile atk, Mobile def)
        {
            Effects.SendMovingEffect(atk, def, EffectID, 18, 1, false, false);

			return true;
        }
    }
}
