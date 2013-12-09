using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class VenariumZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new VenariumZone());
        }

        public VenariumZone()
            : base(ZoneType.Mining)
        {
            //Nord Ouest vers Sud Est
            Area.Add(new Rectangle3D(new Point3D(2902, 1529, 30), new Point3D(2939, 1556, -80)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 90.0, 0.0, Resources[0], null ), // Iron
					new HarvestVein( 10.0, 0.0, Resources[12], Resources[0]), // Venarium
                };
        }
    }
}