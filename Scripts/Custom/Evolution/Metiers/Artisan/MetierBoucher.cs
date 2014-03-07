using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;

namespace Server
{
    public class MetierBoucher
    {
        private static MetierType m_Metier = MetierType.Boucher;
        private static MetierBranche m_MetierBranche = MetierBranche.Artisan;
        private static string m_Nom = "Boucher";
        private static int m_Image = 473;

        private static ClasseAptitudes[] m_Aptitudes = new ClasseAptitudes[]
            {
             /*  	new ClasseAptitudes(10, NAptitude.Boucherie, 10),
                new ClasseAptitudes(9, NAptitude.Boucherie, 9),
                new ClasseAptitudes(8, NAptitude.Boucherie, 8),
                new ClasseAptitudes(7, NAptitude.Boucherie, 7),
                new ClasseAptitudes(6, NAptitude.Boucherie, 6),
                new ClasseAptitudes(5, NAptitude.Boucherie, 5),
                new ClasseAptitudes(4, NAptitude.Boucherie, 4),
                new ClasseAptitudes(3, NAptitude.Boucherie, 3),
                new ClasseAptitudes(2, NAptitude.Boucherie, 2),
                new ClasseAptitudes(1, NAptitude.Boucherie, 1),*/
				
				new ClasseAptitudes(10, Aptitude.Tanneur, 5),
                new ClasseAptitudes(9, Aptitude.Boucherie, 5),
                new ClasseAptitudes(8, Aptitude.Tanneur, 4),
                new ClasseAptitudes(7, Aptitude.Boucherie, 4),
                new ClasseAptitudes(6, Aptitude.Tanneur, 3),
                new ClasseAptitudes(5, Aptitude.Boucherie, 3),
                new ClasseAptitudes(4, Aptitude.Tanneur, 2),
                new ClasseAptitudes(3, Aptitude.Boucherie, 2),
                new ClasseAptitudes(2, Aptitude.Tanneur, 1),
                new ClasseAptitudes(1, Aptitude.Boucherie, 1)
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
