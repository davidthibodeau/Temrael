using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class CuivreZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new CuivreZone());
        }

        public CuivreZone()
            : base(ZoneType.Mining)
        {
            //Nord Ouest vers Sud Est
            Area.Add(new Rectangle3D(new Point3D(2434, 981, -69), new Point3D(2507, 1025, -77)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 90.0, 0.0, Resources[0], null ), // Iron
					new HarvestVein( 10.0, 0.0, Resources[1], Resources[0]), // Cuivre
                };
        }
    }
}