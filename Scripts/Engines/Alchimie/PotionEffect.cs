using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Server.Spells;
using Server.Items;

namespace Server.Engines.Alchimie
{
    public class PotionEffect
    {
        private static Dictionary<Type, int> typeTable = new Dictionary<Type, int>() // Type (PotionEffect) --- int ID.
        {
            { typeof(PotionStrBuffScal), 1 }
        };

        #region Overridable, ou doit être modifié.

        public virtual Type[] Ingredients 
        { 
            get
            {
                return new Type[] { 
                    typeof(Bloodmoss)
                };
            }
        }

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

        #endregion 

        #region Serialize
        public void Serialize(GenericWriter writer)
        {
            if (typeTable.ContainsKey(this.GetType()))
            {
                writer.Write((int)PotionEffect.typeTable[this.GetType()]);
            }
            else
            {
                Console.WriteLine(this.GetType().Name + " n'a pas été trouvé dans le typeList.");
                writer.Write(0);
            }
        }

        public static PotionEffect Deserialize(GenericReader reader)
        {
            int i = reader.ReadInt();
            if (i != 0)
            {
                Type t = FindKeyWithValue(i);
                if (t != null)
                {
                    return (PotionEffect)Activator.CreateInstance(t);
                }
            }
            return null;
        }

        private static Type FindKeyWithValue( int val )
        {
            foreach( KeyValuePair<Type, int> pair in typeTable)
            {
                if(pair.Value == val)
                {
                    return pair.Key;
                }
            }

            return null;
        }
        #endregion
    }
}
