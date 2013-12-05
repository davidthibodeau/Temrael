using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class MytherilZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new MytherilZone());
        }

        public MytherilZone()
            : base(ZoneType.Mining)
        {
            //Nord Ouest vers Sud Est
            Area.Add(new Rectangle3D(new Point3D(2886, 1811, -74), new Point3D(2931, 1846, -80)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 90.0, 0.0, Resources[0], null ), // Iron
					new HarvestVein( 10.0, 0.0, Resources[6], Resources[0]), // Mytheril
                };
        }
    }
}