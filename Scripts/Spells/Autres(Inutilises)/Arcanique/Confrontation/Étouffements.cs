using System;
using Server.Targeting;
using Server.Network;
using Server;
using System.Collections;

namespace Server.Spells
{
    public class EtouffementsSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static readonly new SpellInfo Info = new SpellInfo(
                "Étouffements", "Bet Grav Corp",
                SpellCircle.Seventh,
                236,
                9031,
                Reagent.SulfurousAsh,
                Reagent.Ginseng,
                Reagent.MandrakeRoot
            );

        public EtouffementsSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new EtouffementsTarget(this);
        }

        public static Hashtable m_Timers = new Hashtable();

        private class EtouffementsTarget : Target
        {
            private EtouffementsSpell m_spell;

            public EtouffementsTarget(EtouffementsSpell spell)
                : base(12, false, TargetFlags.Harmful)
            {
                m_spell = spell;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Mobile && m_spell.CheckHSequence((Mobile)targeted))
                {
                    Mobile targ = (Mobile)targeted;

                    SpellHelper.Turn(m_spell.Caster, targ);

                    Spell.Disturb(targ);

                    SpellHelper.CheckReflect((int)m_spell.Circle, m_spell.Caster, ref targ);

                    DateTime endtime = DateTime.Now + m_spell.GetDurationForSpell(0.3);

                    Timer t = new EtouffementsSpell.InternalTimer(targ, endtime);

                    EtouffementsSpell.m_Timers[targ] = t;
                    
                    t.Start();

                    targ.FixedParticles(14276, 9, 32, 5007, EffectLayer.Waist);
                    targ.PlaySound(534);
                }

                m_spell.FinishSequence();
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_spell.FinishSequence();
            }
        }

        public static void StopTimer(Mobile m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);
            }
        }

        private class InternalTimer : Timer
        {
            private Mobile m_From;
            private DateTime ending;

            public InternalTimer(Mobile from, DateTime endtime)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(1))
            {
                m_From = from;
                ending = endtime;

                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                if (m_From.Alive && !m_From.Deleted && DateTime.Now < ending)
                {
                    int damage = 1;
                    AOS.Damage(m_From, null, damage, 100, 0, 0, 0, 0);
                }
                else
                    Stop();
            }
        }
    }
}
