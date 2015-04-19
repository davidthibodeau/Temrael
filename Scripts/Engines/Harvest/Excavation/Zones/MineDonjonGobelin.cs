using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Harvest
{
    public class MineDonjonGobelin : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new MineDonjonGobelin());
        }

        public MineDonjonGobelin()
            : base(ZoneType.Mining, Map.Malas)
        {
            //Add rectangles pour la zone.(nord ouest vers sud est)
            Area.Add(new Rectangle3D(new Point3D(732, 750, -80), new Point3D(833, 861, 50)));
            Area.Add(new Rectangle3D(new Point3D(600, 752, -80), new Point3D(727, 916, 50)));

            Veins = new HarvestVein[]
                    {
                        new HarvestVein(50, 0, Resources[0], null), //Fer
                        new HarvestVein(35, 0, Resources[1], Resources[0]), // Cuivre
                        new HarvestVein(15, 0, Resources[2], Resources[0]), // Bronze
                    };
        }
    }
}
