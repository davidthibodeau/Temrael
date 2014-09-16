using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class FlameStrikeSpell : Spell
	{
        public static int spellID { get { return 0; } } // TOCHANGE

        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;

		private static SpellInfo m_Info = new SpellInfo(
				"Jet de Flamme", "Kal Vas Flam",
				SpellCircle.Eighth,
				245,
				9042,
                s_ManaCost,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.SpidersSilk,
				Reagent.SulfurousAsh
            );

		public FlameStrikeSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return true; } }

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

				SpellHelper.CheckReflect( (int)this.Circle, Caster, ref m );

             //   double damage = Utility.RandomMinMax(45, 90);
                double damage = Utility.RandomMinMax(80, 90);

                damage = SpellHelper.AdjustValue(Caster, damage);

				if ( CheckResisted( m ) )
				{
					damage *= 0.75;

					m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
				}

				damage *= GetDamageScalar( m );

				m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x208 );

				SpellHelper.Damage( this, m, damage, 0, 0, 0, 0, 100 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private FlameStrikeSpell m_Owner;

			public InternalTarget( FlameStrikeSpell owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
				{
					m_Owner.Target( (Mobile)o );
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}