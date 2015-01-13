using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Harvest
{
    public class MineVolcan : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new MineVolcan());
        }

        public MineVolcan()
            : base(ZoneType.Mining)
        {
            //Add rectangles pour la zone.(nord ouest vers sud est)
            Area.Add(new Rectangle3D(new Point3D(1527, 1931, -80), new Point3D(1675, 2085, 50)));
            Area.Add(new Rectangle3D(new Point3D(1545, 2085, -80), new Point3D(1646, 2119, 50)));

            Veins = new HarvestVein[]
                    {
                        new HarvestVein(50, 0, Resources[0], null), //Fer
                        new HarvestVein(18, 0, Resources[1], Resources[0]), // Cuivre
                        new HarvestVein(12, 0, Resources[2], Resources[0]), // Bronze
                        new HarvestVein(10, 0, Resources[3], Resources[0]), // Acier
                        new HarvestVein(10, 0, Resources[5], Resources[0]), // Or
                    };
        }
    }
}
