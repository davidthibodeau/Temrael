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
               	new ClasseAptitudes(10, Aptitude.Hermetisme, 10),
                new ClasseAptitudes(9, Aptitude.Hermetisme, 9),
                new ClasseAptitudes(8, Aptitude.Hermetisme, 8),
                new ClasseAptitudes(7, Aptitude.Hermetisme, 7),
                new ClasseAptitudes(6, Aptitude.Hermetisme, 6),
                new ClasseAptitudes(5, Aptitude.Hermetisme, 5),
                new ClasseAptitudes(4, Aptitude.Hermetisme, 4),
                new ClasseAptitudes(3, Aptitude.Hermetisme, 3),
                new ClasseAptitudes(2, Aptitude.Hermetisme, 2),
                new ClasseAptitudes(1, Aptitude.Hermetisme, 1),
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
