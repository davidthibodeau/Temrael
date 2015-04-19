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

    public class SnareTechnique : BaseTechnique
    {
        #region Membres / consts.

        private static int ManaCost { get { return 30; } }

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
                    if (CheckMana(atk, ManaCost))
                    {
                        atk.SendMessage("Vous fauchez " + def.GetNameUsedBy(atk) + ", il ne peut plus bouger !");
                        def.SendMessage("Vous êtes fauché par " + atk.GetNameUsedBy(def) + ", vous ne pouvez plus bouger !");

                        Effects.SendTargetParticles(def, 0x3789, 5, 5000, 0, EffectLayer.CenterFeet);
                        new SnareEffect(def, new TimeSpan(0, 0, 4));
                        ReadyMobiles.Remove(atk);
                    }
                }
            }
        }
    }
}
