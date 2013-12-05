using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class CrustacesZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new CrustacesZone());
        }

        public CrustacesZone()
            : base(ZoneType.Fishing, typeof(FishingNet))
		{
            /*Area.Add(new Rectangle3D(new Point3D(3840, 2474, -15), new Point3D(4440, 2954, 15))); //Mer Est
            Area.Add(new Rectangle3D(new Point3D(2060, 3507, -15), new Point3D(2456, 3849, 15))); //Mer Sud
            Area.Add(new Rectangle3D(new Point3D(953, 3551, -15), new Point3D(1373, 3887, 15))); //Mer Sud-Ouest
            Area.Add(new Rectangle3D(new Point3D(384, 3135, -15), new Point3D(658, 3336, 15))); //Mer Ouest
            Area.Add(new Rectangle3D(new Point3D(107, 2316, -15), new Point3D(226, 2545, 15))); //Mer Ouest
            Area.Add(new Rectangle3D(new Point3D(99, 1682, -15), new Point3D(202, 1984, 15))); //Mer Ouest
            Area.Add(new Rectangle3D(new Point3D(101, 660, -15), new Point3D(556, 1016, 15))); //Mer Sud-Est*/

            Veins = new HarvestVein[]
                {
				    new HarvestVein( 30, 0.0, HarvestZone.Resources[23], null ), //Sardine
				    new HarvestVein( 18, 0.0, HarvestZone.Resources[24], null ), //Anchoie
				    new HarvestVein( 18, 0.0, HarvestZone.Resources[25], null ), //Hareng
				    new HarvestVein( 18, 0.0, HarvestZone.Resources[26], null ), //Huitre
                    new HarvestVein( 15, 0.0, HarvestZone.Resources[27], null ), //Calmar
				    new HarvestVein( 15, 0.0, HarvestZone.Resources[28], null ), //Pieuvre
                };
		}
    }
}