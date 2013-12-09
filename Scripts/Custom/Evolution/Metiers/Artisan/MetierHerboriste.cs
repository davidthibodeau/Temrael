using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;

namespace Server
{
    public class MetierHerboriste
    {
        private static MetierType m_Metier = MetierType.Herboriste;
        private static MetierBranche m_MetierBranche = MetierBranche.Artisan;
        private static string m_Nom = "Herboriste";
        private static int m_Image = 483;

        private static ClasseAptitudes[] m_Aptitudes = new ClasseAptitudes[]
            {
               	new ClasseAptitudes(10, NAptitude.Hermetisme, 10),
                new ClasseAptitudes(9, NAptitude.Hermetisme, 9),
                new ClasseAptitudes(8, NAptitude.Hermetisme, 8),
                new ClasseAptitudes(7, NAptitude.Hermetisme, 7),
                new ClasseAptitudes(6, NAptitude.Hermetisme, 6),
                new ClasseAptitudes(5, NAptitude.Hermetisme, 5),
                new ClasseAptitudes(4, NAptitude.Hermetisme, 4),
                new ClasseAptitudes(3, NAptitude.Hermetisme, 3),
                new ClasseAptitudes(2, NAptitude.Hermetisme, 2),
                new ClasseAptitudes(1, NAptitude.Hermetisme, 1),
            };

        public static MetierInfo MetierInfo = new MetierInfo(
                m_Metier,
                m_Aptitudes,
                m_Nom,
                m_MetierBranche,
                m_Image
            );
    }
}
