using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeMouvementCache
    {
        private static string m_name = "Mouvement Cache";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.MouvementCache];
        private static int m_tooltip = 3006343;
        private static string m_description = "Augmente le nombre de pas possible de la compétence infiltration.";
        private static string m_note = "Utiliser la compétence d'infiltration.";
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "+2 pas", 
                "+4 pas", 
                "+6 pas", 
                "+8 pas", 
                "+10 pas",
                "+12 pas", 
                "+14 pas", 
                "+16 pas",
                "+18 pas", 
                "+20 pas", 
                "+22 pas", 
                "+2 pas/niveau"
            };

        public static AptitudeInfo AptitudeInfo = new AptitudeInfo(
                        m_name,
                        m_entry,
                        m_tooltip,
                        m_description,
                        m_descriptionNiveau,
                        m_note,
                        m_image
                    );
    }
}
