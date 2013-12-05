using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class OrZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new OrZone());
        }

        public OrZone()
            : base(ZoneType.Mining)
        {
            //Nord Ouest vers Sud Est
            Area.Add(new Rectangle3D(new Point3D(2836, 2093, 34), new Point3D(2859, 2121, -80)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 90.0, 0.0, Resources[0], null ), // Iron
					new HarvestVein( 10.0, 0.0, Resources[5], Resources[0]), // Or
                };
        }
    }
}