using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class AtheniumZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new AtheniumZone());
        }

        public AtheniumZone()
            : base(ZoneType.Mining)
        {
            //Nord Ouest vers Sud Est
            Area.Add(new Rectangle3D(new Point3D(2628, 2193, 45), new Point3D(2658, 2230, -79)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 90.0, 0.0, Resources[0], null ), // Iron
					new HarvestVein( 10.0, 0.0, Resources[13], Resources[0]), // Athenium
                };
        }
    }
}