using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class LuminiumZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new LuminiumZone());
        }

        public LuminiumZone()
            : base(ZoneType.Mining)
        {
            //Nord Ouest vers Sud Est
            Area.Add(new Rectangle3D(new Point3D(2772, 886, -82), new Point3D(2902, 991, -79)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 90.0, 0.0, Resources[0], null ), // Iron
					new HarvestVein( 10.0, 0.0, Resources[7], Resources[0]), // Luminium
                };
        }
    }
}