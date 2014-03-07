using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;

namespace Server
{
    public class MetierCuisinier
    {
        private static MetierType m_Metier = MetierType.Cuisinier;
        private static MetierBranche m_MetierBranche = MetierBranche.Artisan;
        private static string m_Nom = "Cuisinier";
        private static int m_Image = 484;

        private static ClasseAptitudes[] m_Aptitudes = new ClasseAptitudes[]
            {
               	new ClasseAptitudes(10, Aptitude.Cuisson, 10),
                new ClasseAptitudes(9, Aptitude.Cuisson, 9),
                new ClasseAptitudes(8, Aptitude.Cuisson, 8),
                new ClasseAptitudes(7, Aptitude.Cuisson, 7),
                new ClasseAptitudes(6, Aptitude.Cuisson, 6),
                new ClasseAptitudes(5, Aptitude.Cuisson, 5),
                new ClasseAptitudes(4, Aptitude.Cuisson, 4),
                new ClasseAptitudes(3, Aptitude.Cuisson, 3),
                new ClasseAptitudes(2, Aptitude.Cuisson, 2),
                new ClasseAptitudes(1, Aptitude.Cuisson, 1),
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
