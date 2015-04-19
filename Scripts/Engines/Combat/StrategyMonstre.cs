using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Items;
using Server.Engines.Buffing;

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
            Server.Engines.Buffs.Poison poison = weapon.Poison;
            if (poison != null && weapon.PoisonCharges > 0)
            {
                if (!def.Poisoned)
                {
                    --weapon.PoisonCharges;

                    double skill = atk.Skills.Empoisonnement.Value;
                    bool selfdmg = false;
                    double chance = 0;

                    if (chance < 0)
                        chance = 0;
                    chance = chance / 100;
                    if (selfdmg)
                    {
                        if (Utility.RandomDouble() > chance)
                            BuffHandler.Instance.ApplyPoison(atk, poison, Source.Weapon);
                    }
                    else
                        if (atk.CheckSkill(SkillName.Empoisonnement, chance))
                            BuffHandler.Instance.ApplyPoison(def, poison, Source.Weapon);
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
            atk.MovingEffect( def, EffectID, 18, 1, false, false );

			return true;
        }
    }
}
