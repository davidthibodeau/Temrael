using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Misc.PVP.PVPModeDef
{
    public class TDTickets : PVPMode
    {
        public TDTickets(PVPEvent pvpevent)
            : base(pvpevent)
        {
        }

        public override TimeSpan timeout
        {
            get { return TimeSpan.FromMinutes(10); }
        }

        public override int NbMaxEquipes
        {
            get { return 0; }
        }

        protected override void OnStart()
        {
        }
    }
}
