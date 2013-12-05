using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class PetitsPoissonsZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new PetitsPoissonsZone());
        }

        public PetitsPoissonsZone()
            : base(ZoneType.Fishing, typeof(StrongFishingPole))
		{
            Area.Add(new Rectangle3D(new Point3D(0, 0, -15), new Point3D(1320, 1587, 15))); //Hasteindale
            /*Area.Add(new Rectangle3D(new Point3D(412, 1483, -15), new Point3D(782, 1784, 15))); //Baie Nord Woiale
            Area.Add(new Rectangle3D(new Point3D(1872, 1279, -15), new Point3D(2934, 1707, 15))); //Baie proche Sombrum
            Area.Add(new Rectangle3D(new Point3D(1429, 2170, -15), new Point3D(1927, 2809, 15))); // Baie Est Woiale
            Area.Add(new Rectangle3D(new Point3D(1510, 377, -15), new Point3D(2088, 695, 15))); //Proche de Gorlak-city
            Area.Add(new Rectangle3D(new Point3D(1066, 1279, -15), new Point3D(1259, 1442, 15))); //Proche citria
            Area.Add(new Rectangle3D(new Point3D(463, 2219, -15), new Point3D(856, 2523, 15))); //Proche Illidelwis
            Area.Add(new Rectangle3D(new Point3D(2865, 1879, -15), new Point3D(3110, 2340, 15))); //Proche Kar*/

            Veins = new HarvestVein[]
                {
				    new HarvestVein( 25.0, 0.0, HarvestZone.Resources[29], null ), //Truite sauvage
				    new HarvestVein( 25.0, 0.0, HarvestZone.Resources[30], null ), //Carpe
				    new HarvestVein( 25.0, 0.0, HarvestZone.Resources[31], null ), //Esturgeon
				    new HarvestVein( 25.0, 0.0, HarvestZone.Resources[32], null ), //Brochet
                };
		}
    }
}