using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Harvest
{
    public class MinesHurlevent : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new MinesHurlevent());
        }

        public MinesHurlevent()
            : base(ZoneType.Mining)
        {

            Veins = new HarvestVein[] { };
        }


    }


}
