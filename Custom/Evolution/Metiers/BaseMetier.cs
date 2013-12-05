using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;

namespace Server
{
    public class BaseMetier
    {
        private static MetierType m_Metier = MetierType.None;
        private static MetierBranche m_MetierBranche = MetierBranche.Aucune;
        private static string m_Nom = "Aucun";
        private static int m_Image = 0;

        private static ClasseAptitudes[] m_Aptitudes = new ClasseAptitudes[]
            {
               	//new ClasseAptitudes(NAptitude.LancerPrecis, 4),
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
