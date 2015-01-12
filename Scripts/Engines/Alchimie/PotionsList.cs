using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Alchimie
{
    #region Potions à buff.

    public class PotionStrBuffScal : PotionEffect
    {
        public PotionStrBuffScal()
        {
            NiveauSkillRequis = 50;
            Stacks = 50;
            MaxStacks = 50;
            FilterPerTick = 0.02;
        }

        StatMod s;
        // Effet spécial de la potion.
        public override void Effect(Mobile trg, double stacks)
        {
            if (trg.StatMods.Contains(s))
            {
                trg.RemoveStatMod("Potion de force scal");
                s = new StatMod(StatType.Str, "Potion de force scal", (int)stacks, TimeSpan.FromSeconds(2));
                trg.AddStatMod(s);
            }
            else
            {
                s = new StatMod(StatType.Str, "Potion de force scal", (int)stacks, TimeSpan.FromSeconds(2));
                trg.AddStatMod(s);
            }
        }

        public override void RemoveEffect(Mobile trg)
        {
            trg.RemoveStatMod("Potion de force scal");
        }
    }

    #endregion

    #region Potions à malus.





    #endregion
}
