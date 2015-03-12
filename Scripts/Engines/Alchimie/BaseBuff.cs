using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Server.Spells;
using Server.Items;

namespace Server.Engines.Buffs
{
    public abstract class BaseBuff
    {
        public static readonly Dictionary<Type, int> typeTable = new Dictionary<Type, int>() // Type (BaseBuff) --- int ID.
        {
            { typeof(PotionStrBuffScal), 1 },
            { typeof(BuffForce), 2 }
        };

        public virtual void RemoveEffect(Mobile trg)
        {
        }

        public void Serialize(GenericWriter writer)
        {
            if (typeTable.ContainsKey(this.GetType()))
            {
                writer.Write((int)BaseBuff.typeTable[this.GetType()]);
            }
            else
            {
                Console.WriteLine(this.GetType().Name + " n'a pas été trouvé dans le typeList.");
                writer.Write(0);
            }
        }

        public static object Deserialize(GenericReader reader)
        {
            int i = reader.ReadInt();
            if (i != 0)
            {
                Type t = FindKeyWithValue(i);
                if (t != null)
                {
                    return Activator.CreateInstance(t);
                }
            }
            return null;
        }

        private static Type FindKeyWithValue(int val)
        {
            foreach (KeyValuePair<Type, int> pair in typeTable)
            {
                if (pair.Value == val)
                {
                    return pair.Key;
                }
            }

            return null;
        }
    }

    public abstract class Poison : BaseBuff
    {
        // Niveau de skill requis en alchimie pour la création, et en empoisonnement pour l'utilisation.
        public int NiveauSkillRequis = 0;

        // Nombre de stacks appliqué lorsque bu en potion. Les autres types d'utilisation 
        // par empoisonnement (arme, boisson, nourriture) utilisent un % de cette valeur.
        public int Stacks = 1;

        public int MaxStacks = 2000; // else throw new ThisShouldNotHappenException();

        // Pourcentage filtré à chaque tick de timer.
        public double FilterPerTick = 0.25;

        // Effet spécial de la potion.
        public abstract void Effect(Mobile trg, double stacks);
    }

    public abstract class Buff : BaseBuff
    {
        public TimeSpan duree = TimeSpan.FromSeconds(30);

        // Effet spécial de la potion.
        public abstract void Effect(Mobile trg);
    }
}
