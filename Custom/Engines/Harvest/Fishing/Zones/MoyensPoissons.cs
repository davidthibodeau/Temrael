using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class MoyensPoissonsZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new MoyensPoissonsZone());
        }

        public MoyensPoissonsZone()
            : base(ZoneType.Fishing, typeof(LargeFishingPole))
		{
            /*Area.Add(new Rectangle3D(new Point3D(2176, 406, -15), new Point3D(2450, 636, 15))); //Mer Nord proche continent
            Area.Add(new Rectangle3D(new Point3D(1528, 3056, -15), new Point3D(1834, 3345, 15))); //Mer Sud proche continent
            Area.Add(new Rectangle3D(new Point3D(72, 3488, -15), new Point3D(954, 4038, 15))); // Ile des dragons (partout)
            Area.Add(new Rectangle3D(new Point3D(737, 1120, -15), new Point3D(1096, 1380, 15))); //Proche de Citria
            Area.Add(new Rectangle3D(new Point3D(824, 344, -15), new Point3D(1090, 484, 15))); //Nord proche continent
            Area.Add(new Rectangle3D(new Point3D(3246, 398, -15), new Point3D(3713, 655, 15))); //Proche ile des glaces
            Area.Add(new Rectangle3D(new Point3D(2560, 745, -15), new Point3D(2921, 1110, 15))); //Proche Sombrum*/

            Veins = new HarvestVein[]
                {
                    new HarvestVein( 20, 0.0, HarvestZone.Resources[33], null ), //Truite des mers
				    new HarvestVein( 20, 0.0, HarvestZone.Resources[34], null ), //Morue
				    new HarvestVein( 20, 0.0, HarvestZone.Resources[35], null ), //Fletan
				    new HarvestVein( 20, 0.0, HarvestZone.Resources[36], null ), //Marquereau
				    new HarvestVein( 20, 0.0, HarvestZone.Resources[37], null ), //Sole
                };
		}
    }
}