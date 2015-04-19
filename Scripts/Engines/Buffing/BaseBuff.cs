using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Server.Spells;
using Server.Items;

namespace Server.Engines.Buffing
{
    public abstract class BaseBuff
    {
        private HashSet<BuffStat> statSet = new HashSet<BuffStat>();

        public bool ContainsStat(BuffStat stat)
        {
            return statSet.Contains(stat);
        }

        /* Le ID doit être unique.
           Type (BaseBuff) --- int ID.*/
        public static readonly Dictionary<Type, int> typeTable = new Dictionary<Type, int>()
        {
            { typeof(PotionStrBuffScal), 1 },
            { typeof(BuffForce), 2 }
        };

        // À overrider si on veut demander un update chez le client.
        public virtual MobileDelta mobileDelta
        {
            get { return MobileDelta.None; }
        }

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
