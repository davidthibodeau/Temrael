using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class ArgentZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new ArgentZone());
        }

        public ArgentZone()
            : base(ZoneType.Mining)
        {
            //Nord Ouest vers Sud Est
            Area.Add(new Rectangle3D(new Point3D(2743, 2540, -27), new Point3D(2827, 2620, -28)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 90.0, 0.0, Resources[0], null ), // Iron
					new HarvestVein( 10.0, 0.0, Resources[4], Resources[0]), // Argent
                };
        }
    }
}