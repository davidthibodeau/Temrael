using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class FulgurationSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Fulguration", "Por Ort Grav Vas Flam",
				SpellCircle.Eighth,
				239,
				9021,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh,
                Reagent.Ginseng
            );

        public override int RequiredAptitudeValue { get { return 6; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] {NAptitude.Evocation }; } }

        public FulgurationSpell(Mobile caster, Item scroll)
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
            else if (CheckHSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                double damage = GetNewAosDamage(35, 1, 5, true);

                m.BoltEffect(0);

                Effects.PlaySound(m.Location, Caster.Map, 0x20C);

                int itemID = 0x398C;

                TimeSpan duration = GetDurationForSpell(0.5);

                new MurDeFeuSpell.InternalItem(this, itemID, m.Location, Caster, Caster.Map, duration, 0);

                SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);
            }

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private FulgurationSpell m_Owner;

            public InternalTarget(FulgurationSpell owner)
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