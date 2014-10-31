using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class AbeillesSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Abeilles", "Bal Corp Hur Xen",
				2,
				212,
				9041,
				Reagent.BlackPearl,
				Reagent.Bloodmoss,
				Reagent.Garlic
			);

        public AbeillesSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

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

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

				double damage = GetNewAosDamage( 10, 1, 3, true);

                m.PlaySound(22);
                m.FixedEffect(0x923, 3, 30);

                if (Utility.RandomDouble() <= 0.15)
                {
                    m.ApplyPoison(Caster, Poison.GetPoison(0));

                    m.SendMessage("Les abeilles vous piquent et vous sentez leur venin parcourir vos veines !");
                }

				SpellHelper.Damage( TimeSpan.Zero, m, Caster, damage, 0, 0, 0, 0, 100 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private AbeillesSpell m_Owner;

            public InternalTarget(AbeillesSpell owner)
                : base(12, false, TargetFlags.Harmful)
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