using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;
using System.Reflection;
using Server.Targeting;

namespace Server.Engines.Alchimie
{
    public abstract class BasePotionEffect
    {
        public static readonly Dictionary<ulong, Type> typeTable = new Dictionary<ulong, Type>()
        {
            { BasePotionEffect.getID(typeof(PotForce)), typeof(PotForce) }, // 1
            { BasePotionEffect.getID(typeof(PotDex)), typeof(PotDex) },     // 2
            { BasePotionEffect.getID(typeof(PotInt)), typeof(PotInt) },     // 3
        };

        #region Ss-module de generation d'ID semi-unique.
        public static ulong getID(Type type) 
        {
            var cur = Activator.CreateInstance(type);

            return ((BasePotionEffect)cur).ID;
        }

        // Les IDs doivent être entre [0 et (Use_ID_Increment-1)].
        public abstract ulong ID { get; }

        public readonly ulong Use_ID_Increment = 100; // Plus ce chiffre est petit, moins il y a de chances que le Use_ID overflowe.
        private static ulong counter = 0;
        public ulong Use_ID()
        {
            if (m_Stackable)
            {
                try
                {
                    checked
                    {
                        counter += Use_ID_Increment;
                        return ID + counter;
                    }
                }
                catch (Exception)
                {
                    counter = 0;
                    return ID + counter;
                }
            }
            else
            {
                return ID;
            }
        }
        public ulong ID_From_Use_ID(ulong Use_ID)
        {
            return Use_ID % Use_ID_Increment;
        }
        #endregion

        public abstract double MinSkill { get; }
        public abstract double MaxSkill { get; }
        public abstract string Name { get; }

        public TargetFlags m_EffectType;
        public bool m_Stackable;

        public abstract void PutEffect(ScriptMobile target, double strength);
        public abstract void RemoveEffect(ScriptMobile target);

        public BasePotionEffect(TargetFlags effectType, bool stackable)
        {
            m_EffectType = effectType;
            m_Stackable = stackable;
        }

        public BasePotionEffect(BasePotionEffect effect)
        {
            m_EffectType = effect.m_EffectType;
            m_Stackable = effect.m_Stackable;
        }

        public string GetPotionInfo()
        {
            return (Name + " : " + m_EffectType);
        }

        #region Serialize
        public void Serialize(GenericWriter writer)
        {
            writer.Write((ulong)ID);
            writer.Write((int)m_EffectType);
            writer.Write(m_Stackable);
        }

        public static BasePotionEffect Deserialize(GenericReader reader)
        {
            ulong ID = reader.ReadULong();
            TargetFlags flags = (TargetFlags)reader.ReadInt();
            bool stackable = reader.ReadBool();

            return (BasePotionEffect)Activator.CreateInstance(typeTable[ID], flags, stackable);
        }
        #endregion
    }
}
