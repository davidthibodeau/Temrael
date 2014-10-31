using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server;

namespace Server.Spells
{
	public class PieuxDeTerreSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Pieux De Terre", "Evo Ylem",
				2,
				212,
				9041,
                Reagent.BlackPearl,
                Reagent.Bloodmoss,
                Reagent.Garlic
            );

        public PieuxDeTerreSpell(Mobile caster, Item scroll)
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
            else if (CheckHSequence(m))
            {
                Mobile source = Caster;

                SpellHelper.Turn(source, m);

                SpellHelper.CheckReflect((int)this.Circle, ref source, ref m);

                double damage = GetNewAosDamage(8, 1, 3, false);

                source.MovingParticles(m, 0x381C, 7, 0, false, false, 1903, 0, 3006, 4006, 0, 0);
                source.PlaySound(903);

                SpellHelper.Damage(this, m, damage, 0, 0, 0, 100, 0);
            }

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private PieuxDeTerreSpell m_Owner;

            public InternalTarget(PieuxDeTerreSpell owner)
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