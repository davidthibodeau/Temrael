using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Harvest.Excavation.Zones
{
    public class MineCordiliereEparse : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new MineCordiliereEparse());
        }

        public MineCordiliereEparse()
            : base(ZoneType.Mining)
        {
            //Add rectangles pour la zone.(nord ouest vers sud est)
            Area.Add(new Rectangle3D(new Point3D(2145, 1231, -80), new Point3D(2173, 1285, 50)));

            Veins = new HarvestVein[]
                    {
                        new HarvestVein(75, 0, Resources[0], null), //Fer
                        new HarvestVein(25, 0, Resources[1], Resources[0]), // Cuivre
                    };
        }
    }
}
