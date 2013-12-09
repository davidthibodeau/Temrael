using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class MystiriumZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new MystiriumZone());
        }

        public MystiriumZone()
            : base(ZoneType.Mining)
        {
            //Nord Ouest vers Sud Est
            Area.Add(new Rectangle3D(new Point3D(2886, 2533, 10), new Point3D(2958, 2574, -28)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 90.0, 0.0, Resources[0], null ), // Iron
					new HarvestVein( 10.0, 0.0, Resources[9], Resources[0]), // Mystirium
                };
        }
    }
}