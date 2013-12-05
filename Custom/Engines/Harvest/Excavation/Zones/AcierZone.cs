using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class AcierZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new AcierZone());
        }

        public AcierZone()
            : base(ZoneType.Mining)
        {
            //Nord Ouest vers Sud Est
            Area.Add(new Rectangle3D(new Point3D(3318, 2117, -80), new Point3D(3350, 2136, -79)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 90.0, 0.0, Resources[0], null ), // Iron
					new HarvestVein( 10.0, 0.0, Resources[3], Resources[0]), // Acier
                };
        }
    }
}