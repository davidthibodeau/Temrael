using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Misc;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells
{
	public class HarmonieSpell : BardeSpell
	{
        public static Hashtable m_HarmonieTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        //Identification des constantes utilisées (pour modification aisée)
        private const double bonus_donne = 0.03;
        private const int portee = 8;

		private static SpellInfo m_Info = new SpellInfo(
				"Harmonie", "",
				SpellCircle.First,
				215,
				9041,
				false
			);

        public override int RequiredAptitudeValue { get { return 11; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Composition }; } }

        public HarmonieSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
        {
            if (CheckSequence())
            {
                TimeSpan duration = GetDurationForSpell(20, 1.5);
                double factor = 0;

                if (Caster is TMobile)
                {
                    factor += (double)(((TMobile)Caster).GetAptitudeValue(NAptitude.Composition) * bonus_donne);
                }

                DateTime endtime = DateTime.Now + duration;

                ArrayList m_target = new ArrayList();

                Map map = Caster.Map;

                if (map != null)
                {
                    foreach (Mobile m in Caster.GetMobilesInRange(portee))
                    {
                        if (Caster.CanBeBeneficial(m, false) && (Caster.Party == m.Party) && (m.AccessLevel < AccessLevel.GameMaster))
                            m_target.Add(m);
                    }
                }

                for (int i = 0; i < m_target.Count; ++i)
                {
                    Mobile targ = (Mobile)m_target[i];

                    StopTimer(targ);

                    m_HarmonieTable[targ] = factor;

                    Timer t = new HarmonieTimer(targ, DateTime.Now + duration);
                    m_Timers[targ] = t;
                    t.Start();

                    targ.FixedParticles(14170, 10, 20, 5013, 1328, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                    targ.PlaySound(517);
                }
            }

            FinishSequence();
		}

        public void StopTimer(Mobile m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);
                m_HarmonieTable.Remove(m);

                m.FixedParticles(14170, 10, 20, 5013, 1328, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(517);
            }
        }

        public class HarmonieTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public HarmonieTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && HarmonieSpell.m_HarmonieTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    HarmonieSpell.m_HarmonieTable.Remove(m_target);
                    HarmonieSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14170, 10, 20, 5013, 1328, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(517);

                    Stop();
                }
            }
        }
	}
}