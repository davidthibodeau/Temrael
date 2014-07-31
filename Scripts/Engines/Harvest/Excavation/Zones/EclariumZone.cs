using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class EclariumZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new EclariumZone());
        }

        public EclariumZone()
            : base(ZoneType.Mining)
        {
            //Nord Ouest vers Sud Est
            Area.Add(new Rectangle3D(new Point3D(2106, 3559, -70), new Point3D(2163, 3612, -91)));
            Area.Add(new Rectangle3D(new Point3D(3437, 1960, -63), new Point3D(3505, 1988, -62)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 90.0, 0.0, Resources[0], null ), // Iron
					new HarvestVein( 10.0, 0.0, Resources[11], Resources[0]), // Eclarium
                };
        }
    }
}