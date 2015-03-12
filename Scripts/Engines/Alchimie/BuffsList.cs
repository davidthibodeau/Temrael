using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Items;

namespace Server.Engines.Buffs
{
    #region Potions à buff.

    public class PotionStrBuffScal : Poison
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

    #region Buffs
    public class BuffForce : Buff
    {
        private int m_Bonus;

        public BuffForce(int bonus)
        {
            m_Bonus = bonus;
        }

        StatMod s;
        public override void Effect(Mobile trg)
        {
            if (!trg.StatMods.Contains(s))
            {
                trg.RemoveStatMod("Buff de force");
                s = new StatMod(StatType.Str, "Buff de force", m_Bonus, TimeSpan.FromSeconds(2));
                trg.AddStatMod(s);
            }
            else
            {
                s = new StatMod(StatType.Str, "Buff de force", m_Bonus, TimeSpan.FromSeconds(2));
                trg.AddStatMod(s);
            }
        }

        public override void RemoveEffect(Mobile trg)
        {
            trg.RemoveStatMod("Buff de force");
        }
    }
    #endregion

    #region Debuffs

    #endregion
}
