using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Misc;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells
{
    public class PoemeSpell : BardeSpell
    {
        public static Hashtable m_PoemeTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        //Identification des constantes utilisées (pour modification aisée)
        private const double bonus_donne = 0.03;
        private const int portee = 8;

        private static SpellInfo m_Info = new SpellInfo(
                "Poeme", "",
                SpellCircle.First,
                215,
                9041,
                false
            );

        public override int RequiredAptitudeValue { get { return 9; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Composition }; } }

        public PoemeSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                TimeSpan duration = GetDurationForSpell(1, 0.10);
                double factor = 1;

                // Calcul du bonus donné par le sort
                /*if (Caster is TMobile)
                {
                    factor += (double)(((TMobile)Caster).GetAptitudeValue(NAptitude.Composition) * bonus_donne);
                }*/

                DateTime endtime = DateTime.Now + duration;

                ArrayList m_target = new ArrayList();

                Map map = Caster.Map;

                //Sélection des cibles du sort
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

                    m_PoemeTable[targ] = factor;

                    Timer t = new PoemeTimer(targ, factor, DateTime.Now + duration);
                    m_Timers[targ] = t;
                    t.Start();

                    targ.FixedParticles(14170, 10, 20, 5013, 1945, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                    targ.PlaySound(483);
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
                m_PoemeTable.Remove(m);

                m.FixedParticles(14170, 10, 20, 5013, 1945, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(483);
            }
        }

        public class PoemeTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;
            private double m_amount;
            private int m_total;

            public PoemeTimer(Mobile target, double amount, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;
                m_amount = amount;
                m_total = 0;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && PoemeSpell.m_PoemeTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    PoemeSpell.m_PoemeTable.Remove(m_target);
                    PoemeSpell.m_Timers.Remove(m_target);

                    m_target.Dex -= m_total;
                    m_target.Cha -= m_total;

                    m_target.FixedParticles(14170, 10, 20, 5013, 1945, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(483);

                    Stop();
                }
                else
                {
                    m_target.FixedParticles(14170, 10, 20, 5013, 2144, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                    m_target.Dex += (int)m_amount;
                    m_target.Cha += (int)m_amount;
                    m_total += (int)m_amount;
                }
            }
        }
    }
}