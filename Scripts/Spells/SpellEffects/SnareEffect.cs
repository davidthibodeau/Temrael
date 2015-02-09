using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Spells
{
    public class SnareEffect
    {
        #region Membres / consts.

        private static List<Mobile> SnaredMobiles;

        #endregion

        #region Ctor
        public SnareEffect(Mobile m, TimeSpan duree)
        {
            if (SnaredMobiles == null)
                SnaredMobiles = new List<Mobile>();

            new SnareTimer(m, duree);
        }
        #endregion

        #region Methodes

        public static bool IsSnared(Mobile m)
        {
            if (SnaredMobiles != null)
            {
                if (SnaredMobiles.Contains(m))
                {
                    return true;
                }
            }
            return false;
        }

        public static void UnSnare(Mobile m)
        {
            List<Mobile> toRemove = new List<Mobile>();
            foreach (Mobile mob in SnaredMobiles)
            {
                if (mob == m)
                {
                    toRemove.Add(mob);
                }
            }

            foreach (Mobile mob in toRemove)
            {
                SnaredMobiles.Remove(mob);
            }
        }

        #endregion

        #region Timer
        private class SnareTimer : Timer
        {
            private Mobile m_Target;

            public SnareTimer(Mobile target, TimeSpan duration)
                : base(duration)
            {
                m_Target = target;

                Priority = TimerPriority.TwoFiftyMS;

                SnaredMobiles.Add(m_Target);

                Start();
            }

            protected override void OnTick()
            {
                SnaredMobiles.Remove(m_Target);
            }
        }
        #endregion
    }
}
