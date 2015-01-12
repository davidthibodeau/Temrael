using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Alchimie
{
    public abstract class PotionEffect
    {
        // Niveau de skill requis en alchimie pour la création, et en empoisonnement pour l'utilisation.
        public int NiveauSkillRequis = 0;

        // Nombre de stacks appliqué lorsque bu en potion. Les autres types d'utilisation 
        // par empoisonnement (arme, boisson, nourriture) utilisent un % de cette valeur.
        public int Stacks = 1;

        public int MaxStacks = 2000; // else throw new ThisShouldNotHappenException();

        // Pourcentage filtré à chaque tick de timer.
        public double FilterPerTick =  0.25;

        // Effet spécial de la potion.
        public virtual void Effect(Mobile trg, double stacks)
        {
        }

        public virtual void RemoveEffect(Mobile trg)
        {
        }
    }
}
