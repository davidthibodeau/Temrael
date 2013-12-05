using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class RequinsZone : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new RequinsZone());
        }

        public RequinsZone()
            : base(ZoneType.Fishing, typeof(Harpoon))
		{
            /*Area.Add(new Rectangle3D(new Point3D(266, 182, -15), new Point3D(515, 387, 15))); //Coin Nord-Ouest
            Area.Add(new Rectangle3D(new Point3D(169, 313, -15), new Point3D(266, 463, 15)));
            Area.Add(new Rectangle3D(new Point3D(384, 55, -15), new Point3D(594, 176, 15)));
            Area.Add(new Rectangle3D(new Point3D(3964, 318, -15), new Point3D(4350, 565, 15))); //Montagnes Nord-Est
            Area.Add(new Rectangle3D(new Point3D(4277, 491, -15), new Point3D(4528, 661, 15)));
            Area.Add(new Rectangle3D(new Point3D(4666, 291, -15), new Point3D(5026, 695, 15)));
            Area.Add(new Rectangle3D(new Point3D(3547, 3380, -15), new Point3D(4330, 3740, 15))); //Mer Sud-Est*/

            Veins = new HarvestVein[]
                {
				    new HarvestVein( 40.0, 0.0, HarvestZone.Resources[44], null ), //Requins Gris
				    new HarvestVein( 30.0, 0.0, HarvestZone.Resources[45], null ), //Requins Blancs
                    new HarvestVein( 18.0, 0.0, HarvestZone.Resources[46], null ), //Raie
				    new HarvestVein( 15.0, 0.0, HarvestZone.Resources[47], null ) //Espadons
                };
		}
    }
}