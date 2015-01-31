using System;
using System.IO;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;

namespace Server.Spells
{
    public class TotemHelper
    {
        public static double GetTotemBonus(Mobile m, TotemType totemtype)
        {
            if (m == null)
                return 0;

            ArrayList targets = new ArrayList();

            Map map = m.Map;

            if (map != null)
            {
                foreach (Item item in m.GetItemsInRange(15))
                {
                    if (item != null && m.CanSee(item) && item is Totem)
                        targets.Add(item);
                }
            }

            Totem chosen = null;

            for (int i = 0; i < targets.Count; ++i)
            {
                Totem totem = (Totem)targets[i];

                if (totem != null && totem.TotemType == totemtype)
                {
                    if (m.InRange(totem, totem.MaxRange))
                    {
                        if (chosen == null || chosen.Bonus < totem.Bonus)
                            chosen = totem;
                    }
                }
            }

            if (chosen != null && m != null && chosen.TotemType != TotemType.Amulette && chosen.TotemType != TotemType.Miracle && chosen.TotemType != TotemType.Refecteur)
            {
                Effects.SendTargetParticles(m,chosen.EffectID, chosen.EffectSpeed, chosen.EffectDuration, 5005, chosen.Hue, 0, chosen.EffectLayer);
            }

            if (chosen == null)
                return 0;

            return chosen.Bonus;
        }

        public static Totem GetTotem(Mobile m, TotemType totemtype)
        {
            if (m == null)
                return null;

            ArrayList targets = new ArrayList();

            Map map = m.Map;

            if (map != null)
            {
                foreach (Item item in m.GetItemsInRange(15))
                {
                    if (item != null && m.CanSee(item) && item is Totem)
                        targets.Add(item);
                }
            }

            Totem chosen = null;

            for (int i = 0; i < targets.Count; ++i)
            {
                Totem totem = (Totem)targets[i];

                if (totem != null && totem.TotemType == totemtype)
                {
                    if (m.InRange(totem, totem.MaxRange))
                    {
                        if (chosen == null || chosen.Bonus < totem.Bonus)
                            chosen = totem;
                    }
                }
            }

            return chosen;
        }
    }
}