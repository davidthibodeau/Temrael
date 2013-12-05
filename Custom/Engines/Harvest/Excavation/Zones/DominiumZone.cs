using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class DominiumZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new DominiumZone());
        }

        public DominiumZone()
            : base(ZoneType.Mining)
        {
            //Nord Ouest vers Sud Est
            Area.Add(new Rectangle3D(new Point3D(2998, 2818, -83), new Point3D(3088, 2877, -85)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 90.0, 0.0, Resources[0], null ), // Iron
					new HarvestVein( 10.0, 0.0, Resources[10], Resources[0]), // Dominium
                };
        }
    }
}