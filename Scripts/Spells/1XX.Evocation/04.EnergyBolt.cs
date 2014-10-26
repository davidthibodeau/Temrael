using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class EnergyBoltSpell : Spell
	{
        public static int m_SpellID { get { return 104; } } // TOCHANGE

        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;
        private static TimeSpan s_DureeCast = TimeSpan.FromSeconds(1);

		public static readonly new SpellInfo Info = new SpellInfo(
				"Énergie", "Corp Por",
				SpellCircle.Sixth,
				230,
				9022,
                s_ManaCost,
                s_DureeCast,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.BlackPearl,
				Reagent.Nightshade
            );

		public EnergyBoltSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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
                SpellHelper.Turn(Caster, m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

              //  double damage = Utility.RandomMinMax(40, 80);
                double damage = Utility.RandomMinMax(30, 40);

                damage = SpellHelper.AdjustValue(Caster, damage);

                if (CheckResisted(m))
                {
                    damage *= 0.75;

                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                }

                damage *= GetDamageScalar(m);

                m.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);
                m.PlaySound(0x307);

                SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);

				m.MovingParticles( m, 0x379F, 7, 0, false, true, 3043, 4043, 0x211 );
				m.PlaySound( 0x20A );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private EnergyBoltSpell m_Owner;

			public InternalTarget( EnergyBoltSpell owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile)o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}