using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class BronzeZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new BronzeZone());
        }

        public BronzeZone()
            : base(ZoneType.Mining)
        {
            //Nord Ouest vers Sud Est
            Area.Add(new Rectangle3D(new Point3D(2531, 2034, 31), new Point3D(2572, 2085, -79)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 90.0, 0.0, Resources[0], null ), // Iron
					new HarvestVein( 10.0, 0.0, Resources[2], Resources[2]), // Bronze
                };
        }
    }
}