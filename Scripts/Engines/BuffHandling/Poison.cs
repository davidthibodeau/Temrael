using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Server.Spells;
using Server.Items;

namespace Server.Engines.BuffHandling
{
    public abstract class Poison : BaseBuff
    {
        // Niveau de skill requis en alchimie pour la création, et en empoisonnement pour l'utilisation.
        public abstract int NiveauSkillRequis { get; }

        // Nombre de stacks appliqué lorsque bu en potion. Les autres types d'utilisation 
        // par empoisonnement (arme, boisson, nourriture) utilisent un % de cette valeur ( Voir ApplyRate(double value, Source t) ).
        public abstract int Stacks { get; }

        // La limite de stacks applicable. On ne devrait pas atteindre cette limite, mais elle agit comme sécurité.
        public abstract int MaxStacks { get; }

        // Pourcentage filtré à chaque tick de timer.
        public abstract double FilterPerTick { get; }

    }

    public class PotionStrBuffScal : Poison
    {
        public override int NiveauSkillRequis { get { return 50; } }
        public override int Stacks { get { return 50; } }
        public override int MaxStacks { get { return 50; } }
        public override double FilterPerTick { get { return 0.02; } }

        public PotionStrBuffScal()
        {
        }

        //StatMod s;
        //// Effet spécial de la potion.
        //public override void Effect(Mobile trg, double stacks)
        //{
        //    if (trg.StatMods.Contains(s))
        //    {
        //        trg.RemoveStatMod("Potion de force scal");
        //        s = new StatMod(StatType.Str, "Potion de force scal", (int)stacks, TimeSpan.FromSeconds(2));
        //        trg.AddStatMod(s);
        //    }
        //    else
        //    {
        //        s = new StatMod(StatType.Str, "Potion de force scal", (int)stacks, TimeSpan.FromSeconds(2));
        //        trg.AddStatMod(s);
        //    }
        //}

        //public override void RemoveEffect(Mobile trg)
        //{
        //    trg.RemoveStatMod("Potion de force scal");
        //}
    }

}
