using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;

namespace Server
{
    public class MetierCharpentier
    {
        private static MetierType m_Metier = MetierType.Charpentier;
        private static MetierBranche m_MetierBranche = MetierBranche.Artisan;
        private static string m_Nom = "Charpentier";
        private static int m_Image = 477;

        private static ClasseAptitudes[] m_Aptitudes = new ClasseAptitudes[]
            {
                new ClasseAptitudes(10, NAptitude.Ebenisterie, 5),
                new ClasseAptitudes(9, NAptitude.Forestier, 5),
                new ClasseAptitudes(8, NAptitude.Ebenisterie, 4),
                new ClasseAptitudes(7, NAptitude.Forestier, 4),
                new ClasseAptitudes(6, NAptitude.Ebenisterie, 3),
                new ClasseAptitudes(5, NAptitude.Forestier, 3),
                new ClasseAptitudes(4, NAptitude.Ebenisterie, 2),
                new ClasseAptitudes(3, NAptitude.Forestier, 2),
                new ClasseAptitudes(2, NAptitude.Ebenisterie, 1),
                new ClasseAptitudes(1, NAptitude.Forestier, 1)
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
