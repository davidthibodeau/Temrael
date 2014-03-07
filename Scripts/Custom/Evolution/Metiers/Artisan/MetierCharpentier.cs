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
                new ClasseAptitudes(10, Aptitude.Ebenisterie, 5),
                new ClasseAptitudes(9, Aptitude.Forestier, 5),
                new ClasseAptitudes(8, Aptitude.Ebenisterie, 4),
                new ClasseAptitudes(7, Aptitude.Forestier, 4),
                new ClasseAptitudes(6, Aptitude.Ebenisterie, 3),
                new ClasseAptitudes(5, Aptitude.Forestier, 3),
                new ClasseAptitudes(4, Aptitude.Ebenisterie, 2),
                new ClasseAptitudes(3, Aptitude.Forestier, 2),
                new ClasseAptitudes(2, Aptitude.Ebenisterie, 1),
                new ClasseAptitudes(1, Aptitude.Forestier, 1)
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
