using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class BouleDeFeuSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Boule De Feu", "Vas Flam",
				2,
				203,
				9041,
				Reagent.BlackPearl,
                Reagent.Garlic,
                Reagent.SulfurousAsh
            );

        public BouleDeFeuSpell(Mobile caster, Item scroll)
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
				Mobile source = Caster;

				SpellHelper.Turn( source, m );
                
                Disturb(m);

                SpellHelper.CheckReflect((int)this.Circle, ref source, ref m);

                //double damage = GetNewAosDamage(6, 1, 2, false);

                if (CheckResisted(m))
                {
                    //damage *= 0.75;

                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                }

				source.MovingParticles( m, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160 );
				source.PlaySound( 0x44B );

				//SpellHelper.Damage( this, m, damage, 0, 100, 0, 0, 0 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private BouleDeFeuSpell m_Owner;

            public InternalTarget(BouleDeFeuSpell owner)
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