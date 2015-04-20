using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Server.Spells;
using Server.Items;

namespace Server.Engines.BuffHandling
{
    public abstract class BaseBuff : IComparable
    {
        protected abstract BuffEffect effect
        {
            get;
        }

        public bool ContainsEffect(BuffEffect stat)
        {
            return (effect & stat) == stat;
        }

        public abstract double Effect(BuffEffect stat);

        public abstract BuffID Id { get; }

        public abstract int CompareTo(object obj);
    }

    public abstract class Poison : BaseBuff
    {
        // Niveau de skill requis en alchimie pour la création, et en empoisonnement pour l'utilisation.
        public int NiveauSkillRequis = 0;

        // Nombre de stacks appliqué lorsque bu en potion. Les autres types d'utilisation 
        // par empoisonnement (arme, boisson, nourriture) utilisent un % de cette valeur ( Voir ApplyRate(double value, Source t) ).
        public int Stacks = 1;

        // La limite de stacks applicable. On ne devrait pas atteindre cette limite, mais elle agit comme sécurité.
        public int MaxStacks = 2000;

        // Pourcentage filtré à chaque tick de timer.
        public double FilterPerTick = 0.25;

        // Effet du poison.
        public abstract void Effect(Mobile trg, double stacks);
    }

    public abstract class Buff : BaseBuff
    {
        public TimeSpan duree;

        // Retourne la valeur d'offset ( si il y en a une ). Par exemple, un buff qui donne 30 de force devrait retourner 30.
        protected double RetourGetOffset;

        public Buff(TimeSpan duration)
        {
            duree = duration;
            RetourGetOffset = 0;
        }

        public virtual void Effect(Mobile trg)
        {
        }

        // Retourne true si le timer gérant le buff doit restarter, retourne false sinon.
        // Peut décider d'updater sa valeur si celle de la valeur entrée est "meilleure" que la sienne.
        public abstract bool CompareNewEntry( Buff buff );
    }
}
