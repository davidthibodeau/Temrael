using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;

namespace Server
{
    public class MetierForgeron
    {
        private static MetierType m_Metier = MetierType.Forgeron;
        private static MetierBranche m_MetierBranche = MetierBranche.Artisan;
        private static string m_Nom = "Forgeron";
        private static int m_Image = 482;

        private static ClasseAptitudes[] m_Aptitudes = new ClasseAptitudes[]
            {
                new ClasseAptitudes(10, Aptitude.Metallurgie, 5),
                new ClasseAptitudes(9, Aptitude.Mineur, 5),
                new ClasseAptitudes(8, Aptitude.Metallurgie, 4),
                new ClasseAptitudes(7, Aptitude.Mineur, 4),
                new ClasseAptitudes(6, Aptitude.Metallurgie, 3),
                new ClasseAptitudes(5, Aptitude.Mineur, 3),
                new ClasseAptitudes(4, Aptitude.Metallurgie, 2),
                new ClasseAptitudes(3, Aptitude.Mineur, 2),
                new ClasseAptitudes(2, Aptitude.Metallurgie, 1),
                new ClasseAptitudes(1, Aptitude.Mineur, 1)
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
