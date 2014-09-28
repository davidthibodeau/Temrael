using System;
using System.Collections;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class MaledictionSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        private static Hashtable m_Registry = new Hashtable();
        public static Hashtable Registry { get { return m_Registry; } }
        public static Hashtable m_Table = new Hashtable();

		public static readonly SpellInfo m_Info = new SpellInfo(
				"Malediction", "Des Sanct",
				SpellCircle.Fifth,
				227,
				9031,
				Reagent.Nightshade,
				Reagent.Garlic,
				Reagent.SulfurousAsh
            );

        public MaledictionSpell(Mobile caster, Item scroll)
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
                ToogleCurse(this, Caster, m);
			}

			FinishSequence();
		}

        public static void ToogleCurse(Spell spell, Mobile Caster, Mobile m)
        {
            SpellHelper.Turn(Caster, m);

            SpellHelper.CheckReflect((int)spell.Circle, Caster, ref m);

            SpellHelper.AddStatCurse(Caster, m, StatType.Str, spell.GetDurationForSpell(1)); SpellHelper.DisableSkillCheck = true;
            SpellHelper.AddStatCurse(Caster, m, StatType.Dex, spell.GetDurationForSpell(1));
            SpellHelper.AddStatCurse(Caster, m, StatType.Int, spell.GetDurationForSpell(1)); SpellHelper.DisableSkillCheck = false;

            TimeSpan duration = spell.GetDurationForSpell(1);

            new MaledictionSpell.InternalTimer(m, duration).Start();

            if (m.Spell != null)
                m.Spell.OnCasterHurt();

            m.Paralyzed = false;

            m.FixedParticles(0x374A, 10, 15, 5028, EffectLayer.Waist);
            m.PlaySound(0x1EA);
        }

        private class InternalTimer : Timer
        {
            private Mobile target;

            public InternalTimer(Mobile targ, TimeSpan duration)
                : base(duration)
            {
                target = targ;
            }

            protected override void OnTick()
            {
                if (target == null || target.Deleted)
                    return;

                target.PlaySound(0x1ED);
                target.FixedParticles(0x375A, 10, 15, 5037, EffectLayer.Waist);
            }
        }

		private class InternalTarget : Target
		{
            private MaledictionSpell m_Owner;

            public InternalTarget(MaledictionSpell owner)
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