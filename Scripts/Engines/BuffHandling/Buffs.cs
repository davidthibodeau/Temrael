using Server.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.BuffHandling
{
    [PropertyObject]
    public class Buffs
    {
        private Dictionary<BuffID, BaseBuff> buffList = new Dictionary<BuffID, BaseBuff>();

        [CommandProperty(AccessLevel.Batisseur)]
        public int Str { get { return (int)ComputeBuffValue(BuffEffect.Str); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Dex { get { return (int)ComputeBuffValue(BuffEffect.Dex); } }
        
        [CommandProperty(AccessLevel.Batisseur)]
        public int Int { get { return (int)ComputeBuffValue(BuffEffect.Int); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int HitsMax { get { return (int)ComputeBuffValue(BuffEffect.HitsMax); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int StamMax { get { return (int)ComputeBuffValue(BuffEffect.StamMax); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int ManaMax { get { return (int)ComputeBuffValue(BuffEffect.ManaMax); } }

        // La vitesse est calculee en pourcventage de la vitesse du personnage.
        [CommandProperty(AccessLevel.Batisseur)]
        public double Vitesse { get { return ComputeBuffValue(BuffEffect.Vitesse); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Penetration { get { return (int)ComputeBuffValue(BuffEffect.Penetration); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public double ResistancePhysique { get { return ComputeBuffValue(BuffEffect.ResistancePhysique); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public double ResistanceMagique { get { return ComputeBuffValue(BuffEffect.ResistanceMagique); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public double HitRegen { get { return ComputeBuffValue(BuffEffect.HitRegen); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public double StamRegen { get { return ComputeBuffValue(BuffEffect.StamRegen); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public double ManaRegen { get { return ComputeBuffValue(BuffEffect.ManaRegen); } }

        private double ComputeBuffValue(BuffEffect stat)
        {
            double value = 0;
            foreach (BaseBuff buff in buffList.Values)
            {
                value += buff.Effect(stat);
            }

            return value;
        }

        public bool AddBuff(BaseBuff buff)
        {
            if (buffList.ContainsKey(buff.Id))
            {
                //TODO: Introduire une notion de comparaison adéquate.
                if(buff.CompareTo(buffList[buff.Id]) > 0)
                {
                    buffList[buff.Id] = buff;
                    return true;
                }
                return false;
            }

            buffList.Add(buff.Id, buff);
            return true;
        }

        public override string ToString()
        {
            return "...";
        }
    }
}
