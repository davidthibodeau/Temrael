using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Buffing
{
    [PropertyObject]
    public class Buffs
    {
        private Dictionary<BuffID, BaseBuff> bufflist = new Dictionary<BuffID, BaseBuff>();

        [CommandProperty(AccessLevel.Batisseur)]
        public int Str { get { return (int)ComputeBuffValue(BuffStat.Str); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Dex { get { return (int)ComputeBuffValue(BuffStat.Dex); } }
        
        [CommandProperty(AccessLevel.Batisseur)]
        public int Int { get { return (int)ComputeBuffValue(BuffStat.Int); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int HitsMax { get { return (int)ComputeBuffValue(BuffStat.HitsMax); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int StamMax { get { return (int)ComputeBuffValue(BuffStat.StamMax); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int ManaMax { get { return (int)ComputeBuffValue(BuffStat.ManaMax); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Vitesse { get { return (int)ComputeBuffValue(BuffStat.Vitesse); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Penetration { get { return (int)ComputeBuffValue(BuffStat.Penetration); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public double ResistancePhysique { get { return ComputeBuffValue(BuffStat.ResistancePhysique); } }

        [CommandProperty(AccessLevel.Batisseur)]
        public double ResistanceMagique { get { return ComputeBuffValue(BuffStat.ResistanceMagique); } }

        private double ComputeBuffValue(BuffStat stat)
        {
            return 0;
        }

        public void AddBuff(BaseBuff buff)
        {

        }

        public override string ToString()
        {
            return "...";
        }
    }
}
