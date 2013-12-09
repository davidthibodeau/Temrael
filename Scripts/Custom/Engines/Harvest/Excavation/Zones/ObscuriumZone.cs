using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class ObscuriumZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new ObscuriumZone());
        }

        public ObscuriumZone()
            : base(ZoneType.Mining)
        {
            //Nord Ouest vers Sud Est
            Area.Add(new Rectangle3D(new Point3D(2305, 3032, -80), new Point3D(2379, 3067, -79)));
            Area.Add(new Rectangle3D(new Point3D(2374, 1335, -12), new Point3D(2429, 1399, -60)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 90.0, 0.0, Resources[0], null ), // Iron
					new HarvestVein( 10.0, 0.0, Resources[8], Resources[0]), // Obscurium
                };
        }
    }
}