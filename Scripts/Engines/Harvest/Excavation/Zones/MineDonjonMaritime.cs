using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Harvest
{
    public class MineDonjonMaritimeMain : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new MineDonjonMaritimeMain());
        }

        public MineDonjonMaritimeMain()
            : base(ZoneType.Mining, Map.Malas)
        {
            //Add rectangles pour la zone.(nord ouest vers sud est)
            Area.Add(new Rectangle3D(new Point3D(1789, 408, -80), new Point3D(1815, 422, 50)));

            Veins = new HarvestVein[]
                    {
                        new HarvestVein(60, 0, Resources[0], null), //Fer
                        new HarvestVein(5,  0, Resources[2], Resources[0]), // Bronze
                        new HarvestVein(20, 0, Resources[3], Resources[0]), // Acier
                        new HarvestVein(15, 0, Resources[6], Resources[0]), // Mytheril
                    };
        }
    }
    public class MineDonjonMaritime : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new MineDonjonMaritime());
        }

        public MineDonjonMaritime()
            : base(ZoneType.Mining, Map.Malas)
        {
            //Add rectangles pour la zone.(nord ouest vers sud est)
            Area.Add(new Rectangle3D(new Point3D(1744, 423, -80), new Point3D(1814, 441, 50)));
            Area.Add(new Rectangle3D(new Point3D(1744, 394, -80), new Point3D(1788, 422, 50)));
            Area.Add(new Rectangle3D(new Point3D(1736, 347, -80), new Point3D(1758, 378, 50)));
            Area.Add(new Rectangle3D(new Point3D(1764, 343, -80), new Point3D(1811, 360, 50)));

            Veins = new HarvestVein[]
                    {
                        new HarvestVein(65, 0, Resources[0], null), //Fer
                        new HarvestVein(15, 0, Resources[1], Resources[0]), // Cuivre
                        new HarvestVein(10, 0, Resources[2], Resources[0]), // Bronze
                        new HarvestVein(9,  0, Resources[4], Resources[0]), // Argent
                        new HarvestVein(1,  0, Resources[6], Resources[0]), // Mytheril
                    };
        }
    }
}
