using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Server.Spells.TechniquesCombat
{
    // Un snare empêche le mouvement, mais 
    // n'empêche pas le joueur de donner des coups
    // ou d'utiliser des spells.

    public class SnareTechnique
    {
        #region Membres / consts.

        private const int ManaCost = 30;
        private static List<Mobile> ReadyMobiles;

        #endregion

        #region Ctor
        public SnareTechnique(Mobile atk)
        {
            if (ReadyMobiles == null)
                ReadyMobiles = new List<Mobile>();

            if (!ReadyMobiles.Contains(atk))
            {
                ReadyMobiles.Add(atk);
            }
        }
        #endregion

        public static void GetOnHitEffect(Mobile atk, Mobile def)
        {
            if (ReadyMobiles != null)
            {
                if (ReadyMobiles.Contains(atk))
                {
                    if (CheckMana(atk))
                    {
                        Effects.SendTargetParticles(def, 0x3789, 2, 3000, 0, EffectLayer.CenterFeet);
                        new SnareEffect(def, new TimeSpan(0, 0, 5));
                        ReadyMobiles.Remove(atk);
                    }
                }
            }
        }

        private static bool CheckMana(Mobile atk)
        {
            if (atk.Mana >= ManaCost)
            {
                atk.Mana -= ManaCost;
                return true;
            }
            else
            {
                return false;
            }
        }
    }


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
