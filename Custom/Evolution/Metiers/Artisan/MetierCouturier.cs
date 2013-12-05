using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;

namespace Server
{
    public class MetierCouturier
    {
        private static MetierType m_Metier = MetierType.Couturier;
        private static MetierBranche m_MetierBranche = MetierBranche.Artisan;
        private static string m_Nom = "Couturier";
        private static int m_Image = 478;

        private static ClasseAptitudes[] m_Aptitudes = new ClasseAptitudes[]
            {
                new ClasseAptitudes(10, NAptitude.Broderie, 5),
                new ClasseAptitudes(9, NAptitude.Tanneur, 5),
                new ClasseAptitudes(8, NAptitude.Broderie, 4),
                new ClasseAptitudes(7, NAptitude.Tanneur, 4),
                new ClasseAptitudes(6, NAptitude.Broderie, 3),
                new ClasseAptitudes(5, NAptitude.Tanneur, 3),
                new ClasseAptitudes(4, NAptitude.Broderie, 2),
                new ClasseAptitudes(3, NAptitude.Tanneur, 2),
                new ClasseAptitudes(2, NAptitude.Broderie, 1),
                new ClasseAptitudes(1, NAptitude.Tanneur, 1)
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
