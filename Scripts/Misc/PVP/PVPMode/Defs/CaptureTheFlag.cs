using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Misc.PVP
{
    public class CaptureTheFlag : PVPMode
    {
        public CaptureTheFlag(PVPEvent pvpevent)
            : base(pvpevent)
        {
        }

        protected override void OnStart()
        {
            
        }

        public override TimeSpan timeout
        {
            get { return TimeSpan.FromMinutes(10); }
        }
    }
}
