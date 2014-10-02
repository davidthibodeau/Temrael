using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class EpinesSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Epines", "Dras Ylem Beh Bal",
				SpellCircle.Third,
				212,
				9041,
				Reagent.BlackPearl,
				Reagent.SulfurousAsh,
				Reagent.MandrakeRoot
			);

        public EpinesSpell(Mobile caster, Item scroll)
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

                int damage = GetNewAosDamage(12, 1, 5, true);
                
                if (m == null || m.Deleted || !m.Alive)
                    return;

                if (Caster == null || Caster.Deleted || !Caster.Alive)
                    return;

                if (m.Spell != null)
                    m.Spell.OnCasterHurt();

                Caster.MovingEffect(m, 0x1BFE, 7, 1, false, false, 1043, 0);
                Caster.PlaySound(903);

                SpellHelper.Damage(TimeSpan.Zero, m, Caster, damage, 0, 0, 0, 0, 100);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private EpinesSpell m_Owner;

            public InternalTarget(EpinesSpell owner)
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