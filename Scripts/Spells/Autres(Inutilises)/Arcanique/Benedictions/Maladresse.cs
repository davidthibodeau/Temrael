using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class MaladresseSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly SpellInfo m_Info = new SpellInfo(
                "Maladresse", "Uus Jux",
				SpellCircle.First,
				212,
				9031,
				Reagent.Bloodmoss,
				Reagent.Nightshade
            );

        public MaladresseSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
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
				SpellHelper.Turn( Caster, m );

				SpellHelper.CheckReflect( (int)this.Circle, Caster, ref m );

                SpellHelper.AddStatCurse(Caster, m, StatType.Dex, GetDurationForSpell(1));

				if ( m.Spell != null )
					m.Spell.OnCasterHurt();

				m.Paralyzed = false;

				m.FixedParticles( 0x3779, 10, 15, 5002, EffectLayer.Head );
				m.PlaySound( 0x1DF );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private MaladresseSpell m_Owner;

            public InternalTarget(MaladresseSpell owner)
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