using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Misc;
using Server.Items;
using Server.Mobiles;
using Server.Engines.PartySystem;

namespace Server.Spells
{
	public class HymneSpell : BardeSpell
	{
        public static Hashtable m_HymneTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        //Identification des constantes utilisées (pour modification aisée)
        private const double bonus_donne = 0.5;
        private const int portee = 8;

		private static SpellInfo m_Info = new SpellInfo(
				"Hymne", "",
				SpellCircle.First,
				215,
				9041,
				false
			);

        public override int RequiredAptitudeValue { get { return 5; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Composition }; } }

        public HymneSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
        {
            if (CheckSequence())
            {
                TimeSpan duration = GetDurationForSpell(20, 1.5);
                double amount = 1;

                //Calcul du bonus donné par le sort (niveau * bonus_donne)
                if (Caster is TMobile)
                {
                    amount += (double)(((TMobile)Caster).GetAptitudeValue(Aptitude.Composition) * bonus_donne);
                }

                DateTime endtime = DateTime.Now + duration;

                ArrayList m_target = new ArrayList();

                Map map = Caster.Map;

                Party party = Engines.PartySystem.Party.Get(Caster);

                //Définition des cibles du sort
                m_target.Add(Caster);

                if (map != null)
                {
                    foreach (Mobile m in Caster.GetMobilesInRange(portee))
                    {
                        if (SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false))
                        {
                            if (party != null && party.Count > 0)
                            {
                                for (int k = 0; k < party.Members.Count; ++k)
                                {
                                    PartyMemberInfo pmi = (PartyMemberInfo)party.Members[k];
                                    Mobile member = pmi.Mobile;
                                    if (member.Serial == m.Serial)
                                        m_target.Add(m);
                                }
                            }
                        }
                    }
                }            

                for (int i = 0; i < m_target.Count; ++i)
                {
                    Mobile targ = (Mobile)m_target[i];

                    StopTimer(targ);

                    m_HymneTable[targ] = amount;

                    Timer t = new HymneTimer(targ, amount, DateTime.Now + duration);
                    m_Timers[targ] = t;
                    t.Start();

                    targ.FixedParticles(14170, 10, 20, 5013, 1944, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                    targ.PlaySound(493);
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
                m_HymneTable.Remove(m);

                m.FixedParticles(14170, 10, 20, 5013, 1944, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(493);
            }
        }

        public class HymneTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;
            private double m_amount;

            public HymneTimer(Mobile target, double amount, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;
                m_amount = amount;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && HymneSpell.m_HymneTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    HymneSpell.m_HymneTable.Remove(m_target);
                    HymneSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14170, 10, 20, 5013, 1944, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(493);

                    Stop();
                }
                else
                {
                    m_target.FixedParticles(14170, 10, 20, 5013, 1944, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                    m_target.Hits += (int)m_amount;
                }
            }
        }
	}
}