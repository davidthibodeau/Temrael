using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class BouleDeGlaceSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		private static SpellInfo m_Info = new SpellInfo(
				"Boule De Glace", "Vas Aqua",
				SpellCircle.Fifth,
				203,
				9041,
				Reagent.BlackPearl,
                Reagent.Garlic,
                Reagent.Ginseng
            );

        public BouleDeGlaceSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
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
				Mobile source = Caster;

				SpellHelper.Turn( source, m );

                Disturb(m);

                SpellHelper.CheckReflect((int)this.Circle, ref source, ref m);

                double damage = GetNewAosDamage(25, 1, 4, true);

                if (CheckResisted(m))
                {
                    damage *= 0.75;

                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                }

				source.MovingParticles( m, 0x36D4, 7, 0, false, true, 1941, 0, 9502, 4019, 0x160, 0 );
				source.PlaySound( 282 );

				SpellHelper.Damage( this, m, damage, 0, 100, 0, 0, 0 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private BouleDeGlaceSpell m_Owner;

            public InternalTarget(BouleDeGlaceSpell owner)
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