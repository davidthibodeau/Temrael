using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Items;

namespace Server.Engines.BuffHandling
{

    public enum BuffID
    {
        Benediction,
    }

    [Flags]
    public enum BuffEffect
    {
        None                = 0x000,
        Str                 = 0x001,
        Dex                 = 0x002,
        Int                 = 0x004,
        HitsMax             = 0x008,
        StamMax             = 0x010,
        ManaMax             = 0x020,
        Vitesse             = 0x040,
        Penetration         = 0x080,
        ResistancePhysique  = 0x100,
        ResistanceMagique   = 0x200,
    }

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
        public override MobileDelta mobileDelta
        {
            get
            {
                return MobileDelta.Stat;
            }
        }

        private int forceOffset;

        public BuffForce(int offset, TimeSpan duration) : base(duration)
        {
            forceOffset = offset;
        }

        public override void Effect(Mobile trg)
        {
            RetourGetOffset = forceOffset;
        }

        public override void RemoveEffect(Mobile trg)
        {
            RetourGetOffset = 0;
        }

        public override bool CompareNewEntry(Buff buff)
        {
            if (buff is BuffForce)
            {
                BuffForce buffForce = (BuffForce)buff;

                if (Math.Abs(buffForce.forceOffset) > Math.Abs(RetourGetOffset))
                {
                    forceOffset = buffForce.forceOffset;
                }

                return true;
            }

            return false;
        }
    }
    #endregion

    #region Debuffs

    #endregion
}
