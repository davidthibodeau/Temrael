using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class UmbrariumZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new UmbrariumZone());
        }

        public UmbrariumZone()
            : base(ZoneType.Mining)
        {
            //Nord Ouest vers Sud Est
            Area.Add(new Rectangle3D(new Point3D(4231, 1979, 0), new Point3D(4263, 2014, 2)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 90.0, 0.0, Resources[0], null ), // Iron
					new HarvestVein( 10.0, 0.0, Resources[14], Resources[0]), // Umbrarium
                };
        }
    }
}