using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;
using System.Collections;

namespace Server.Engines.Alchimie
{
    public abstract class BaseSynergy
    {
        // Liste des synergies disponibles, qui sera utilisée au check des requirements.
        public static readonly List<BaseSynergy> synergyList = new List<BaseSynergy>()
        {
            { new NightVision() }
        };

        public abstract string Name { get; }

        public abstract List<Type> Requirements { get; }
        public bool MeetsRequirements(List<BasePotionEffect> list)
        {
            List<BasePotionEffect> temp = new List<BasePotionEffect>(list);

            foreach (Type type in Requirements)
            {
                bool found = false;
                foreach (BasePotionEffect effect in list)
                {
                    if (effect.GetType() == type)
                    {
                        if (temp.Remove(effect))
                        {
                            found = true;
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

                if (!found)
                    return false;
            }

            return true;
        }

        public abstract void PutEffect(ScriptMobile target, double strength);
        public abstract void RemoveEffect(ScriptMobile target);

        public string GetPotionInfo()
        {
            return Name;
        }

        public BaseSynergy() { }
    }
}
