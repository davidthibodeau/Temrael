using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class GrosPoissonsZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new GrosPoissonsZone());
        }

        public GrosPoissonsZone()
            : base(ZoneType.Fishing, typeof(LargeStrongFishingPole))
		{
            /*Area.Add(new Rectangle3D(new Point3D(418, 1087, -15), new Point3D(925, 1361, 15))); //Mer Ouest proche continent
            Area.Add(new Rectangle3D(new Point3D(824, 3161, -15), new Point3D(1261, 3384, 15))); //Mer Sud-Ouest proche continent
            Area.Add(new Rectangle3D(new Point3D(2243, 2910, -15), new Point3D(2837, 3265, 15))); // Mer proche Najar Him
            Area.Add(new Rectangle3D(new Point3D(3108, 2168, -15), new Point3D(3346, 2513, 15))); //Mer proche Kar
            Area.Add(new Rectangle3D(new Point3D(4300, 2096, -15), new Point3D(4559, 2508, 15))); //Mer milieu
            Area.Add(new Rectangle3D(new Point3D(3515, 1501, -15), new Point3D(4173, 1768, 15))); //Mer milieu
            Area.Add(new Rectangle3D(new Point3D(1196, 57, -15), new Point3D(2492, 302, 15))); //Mer Sud-Est*/

            Veins = new HarvestVein[]
                {
				    new HarvestVein( 18.0, 0.0, HarvestZone.Resources[38], null ), //Grand Brochet
				    new HarvestVein( 18.0, 0.0, HarvestZone.Resources[39], null ), //Grand Doré
				    new HarvestVein( 18.0, 0.0, HarvestZone.Resources[40], null ), //Esturgeon mer
				    new HarvestVein( 18.0, 0.0, HarvestZone.Resources[41], null ), //Grand Saumon
                    new HarvestVein( 15, 0.0, HarvestZone.Resources[42], null ), //Thon
				    new HarvestVein( 15, 0.0, HarvestZone.Resources[43], null ), //Saumon
                };
		}
    }
}