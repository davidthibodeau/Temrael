using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;

namespace Server
{
    public class MetierDresseur
    {
        private static MetierType m_Metier = MetierType.Dresseur;
        private static MetierBranche m_MetierBranche = MetierBranche.Divers;
        private static string m_Nom = "Dresseur";
        private static int m_Image = 480;

        private static ClasseAptitudes[] m_Aptitudes = new ClasseAptitudes[]
            {
               	new ClasseAptitudes(10, NAptitude.Familier, 6),
                new ClasseAptitudes(9, NAptitude.Familier, 5),
                new ClasseAptitudes(7, NAptitude.Familier, 4),
                new ClasseAptitudes(5, NAptitude.Familier, 3),
                new ClasseAptitudes(3, NAptitude.Familier, 2),
                new ClasseAptitudes(1, NAptitude.Familier, 1)
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
