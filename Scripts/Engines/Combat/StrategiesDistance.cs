using Server.Engines.Equitation;
using Server.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Combat
{
    public abstract class StrategyDistance : CombatStrategy
    {
        public abstract int EffectID{ get; }
        public abstract Item Ammo { get; }
        public abstract Type AmmoType { get; }

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

		public override bool OnFired( Mobile attacker, Mobile defender )
		{
			BaseQuiver quiver = attacker.FindItemOnLayer( Layer.Cloak ) as BaseQuiver;
			Container pack = attacker.Backpack;

			if ( attacker.Player )
			{
				if ( quiver == null || quiver.LowerAmmoCost == 0 || quiver.LowerAmmoCost > Utility.Random( 100 ) )
				{
					if ( quiver != null && quiver.ConsumeTotal( AmmoType, 1 ) )
						quiver.InvalidateWeight();
					else if ( pack == null || !pack.ConsumeTotal( AmmoType, 1 ) )
						return false;
				}
			}

			attacker.MovingEffect( defender, EffectID, 18, 1, false, false );

			return true;
		}

        public override SkillName ToucherSkill { get { return SkillName.ArmeDistance; } }

        protected override double ComputerDegats(Mobile atk, int basedmg, bool skillup)
        {
            if (skillup)
                CheckSkillGain(atk, SkillName.Anatomie);

            double dmg = base.ComputerDegats(atk, basedmg, skillup);
            double menuiserieBonus = GetBonus(atk.Skills[SkillName.Menuiserie].Value, 0.2, 10);

            return dmg + basedmg * menuiserieBonus;
        }

        protected override void AppliquerPoison(Mobile atk, Mobile def)
        {
            //Un arc n'applique pas le poison.
        }

        protected override void CheckEquitationAttaque(Mobile atk)
        {
            CheckEquitation(atk, EquitationType.Ranged);
        }
    }

    public class StrategyArc : StrategyDistance
    {
        protected StrategyArc() { }

        public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType{ get{ return typeof( Arrow ); } }
		public override Item Ammo{ get{ return new Arrow(); } }

        public readonly static CombatStrategy Strategy = new StrategyArc();
        
        public override int BaseRange { get { return 10; } }

        public override void AttaqueAnimation(Mobile atk)
        {
            if (atk.Body.Type == BodyType.Human)
            {
                atk.Animate(27, 7, 1, true, false, 0);
            }
            else
            {
                base.AttaqueAnimation(atk);
            }
        }
    }

    public class StrategyArbalete : StrategyDistance
    {
        protected StrategyArbalete() { }

        public override int EffectID { get { return 0x1BFE; } }
        public override Type AmmoType { get { return typeof(Bolt); } }
        public override Item Ammo { get { return new Bolt(); } }

        public readonly static CombatStrategy Strategy = new StrategyArbalete();
        
        public override int BaseRange { get { return 8; } }

        public override void AttaqueAnimation(Mobile atk)
        {
            if (atk.Body.Type == BodyType.Human)
            {
                atk.Animate(28, 7, 1, true, false, 0);
            }
            else
            {
                base.AttaqueAnimation(atk);
            }
        }
    }
}
