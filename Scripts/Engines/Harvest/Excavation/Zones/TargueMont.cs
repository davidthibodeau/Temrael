using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Harvest
{
    public class TargueMont : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new TargueMont());
        }

        public TargueMont()
            : base(ZoneType.Mining)
        {
            //Add rectangles pour la zone.(nord ouest vers sud est)
            //Area.Add(new Rectangle3D(new Point3D(4231, 1979, 0), new Point3D(4263, 2014, 2)));
            Area.Add(new Rectangle3D(new Point3D(1900, 1711, -70), new Point3D(2032, 1765, 50)));
            Area.Add(new Rectangle3D(new Point3D(1923, 1766, -70), new Point3D(1964, 1788, 50)));
            Area.Add(new Rectangle3D(new Point3D(1864, 1765, -70), new Point3D(1922, 1864, 50)));
            Area.Add(new Rectangle3D(new Point3D(1894, 1880, -70), new Point3D(1950, 1942, 50)));

            Veins = new HarvestVein[]
                    {
                        new HarvestVein(60, 0, Resources[0], null), //Fer
                        new HarvestVein(16, 0, Resources[1], Resources[0]), // Cuivre
                        new HarvestVein(12, 0, Resources[2], Resources[0]), // Bronze
                        new HarvestVein(4, 0, Resources[3], Resources[0]), // Acier
                        new HarvestVein(3, 0, Resources[4], Resources[0]), // Argent
                    };
        }

    }
}
