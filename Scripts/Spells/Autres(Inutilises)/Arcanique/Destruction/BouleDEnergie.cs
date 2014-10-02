using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class BouleDEnergieSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Boule D'energie", "Corp Por",
				SpellCircle.Sixth,
				230,
				9022,
				Reagent.BlackPearl,
				Reagent.Nightshade,
                Reagent.Garlic
            );

        public BouleDEnergieSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
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

                Disturb(m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                double damage = GetNewAosDamage(30, 1, 3, true);

                if (CheckResisted(m))
                {
                    damage *= 0.75;

                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                }

                m.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);
                m.PlaySound(0x307);

                SpellHelper.Damage(this, m, damage, 0, 100, 0, 0, 0);

				m.MovingParticles( m, 0x379F, 7, 0, false, true, 3043, 4043, 0x211 );
				m.PlaySound( 0x20A );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private BouleDEnergieSpell m_Owner;

            public InternalTarget(BouleDEnergieSpell owner)
                : base(12, false, TargetFlags.Harmful)
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