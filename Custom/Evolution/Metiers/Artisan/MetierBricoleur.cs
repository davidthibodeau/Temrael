using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;

namespace Server
{
    public class MetierBricoleur
    {
        private static MetierType m_Metier = MetierType.Bricoleur;
        private static MetierBranche m_MetierBranche = MetierBranche.Artisan;
        private static string m_Nom = "Bricoleur";
        private static int m_Image = 474;

        private static ClasseAptitudes[] m_Aptitudes = new ClasseAptitudes[]
            {
                new ClasseAptitudes(10, NAptitude.Invention, 5),
                new ClasseAptitudes(9, NAptitude.Mineur, 5),
                new ClasseAptitudes(8, NAptitude.Invention, 4),
                new ClasseAptitudes(7, NAptitude.Mineur, 4),
                new ClasseAptitudes(6, NAptitude.Invention, 3),
                new ClasseAptitudes(5, NAptitude.Mineur, 3),
                new ClasseAptitudes(4, NAptitude.Invention, 2),
                new ClasseAptitudes(3, NAptitude.Mineur, 2),
                new ClasseAptitudes(2, NAptitude.Invention, 1),
                new ClasseAptitudes(1, NAptitude.Mineur, 1)
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
