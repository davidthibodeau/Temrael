using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells
{
	public class EnduranceSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Endurance", "In Vas Ex Beh Bal",
				SpellCircle.Second,
				233,
				9012,
				false,
				Reagent.Bloodmoss,
				Reagent.Ginseng,
				Reagent.Garlic
			);

        public EnduranceSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public static Hashtable m_Timers = new Hashtable();

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (!(m is TMobile))
            {
                Caster.SendMessage("Ce sort ne peut être qu'utilisé sur les joueurs.");
            }
            else if (CheckBSequence(m))
            {
                DateTime endtime = DateTime.Now + GetDurationForSpell(1);

                StopTimer((TMobile)m);

                Timer t = new EnduranceTimer((TMobile)m, endtime);

                m_Timers[(TMobile)m] = t;

                t.Start();
            }

            FinishSequence();
        }

        public static void StopTimer(TMobile m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);
                //m.Endurance = false;
                m.FixedParticles(0x373A, 10, 15, 5018, 2041, 0, EffectLayer.Waist);
                m.PlaySound(0x1EA);
            }
        }

        private class InternalTarget : Target
        {
            private EnduranceSpell m_Owner;

            public InternalTarget(EnduranceSpell owner)
                : base(12, false, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                {
                    m_Owner.Target((Mobile)o);
                }
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }

        private class EnduranceTimer : Timer
        {
            private TMobile m_target;
            private DateTime m_end;

            public EnduranceTimer(TMobile target, DateTime endtime)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(1))
            {
                m_target = target;
                m_end = endtime;
                //m_target.Endurance = true;

                m_target.FixedParticles(0x373A, 10, 15, 5018, 2041, 0, EffectLayer.Waist);
                m_target.PlaySound(0x1EA);
                m_target.SendMessage("Vous vous sentez soutenu d'une endurance significative.");

                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                if (!m_target.Alive || DateTime.Now >= m_end)
                {
                    //m_target.Endurance = false;
                    m_target.FixedParticles(0x373A, 10, 15, 5018, 2041, 0, EffectLayer.Waist);
                    m_target.PlaySound(0x1EA);
                    Stop();
                }
            }
        }

	}
}