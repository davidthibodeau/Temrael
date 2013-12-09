using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeCoupPuissant
    {
        private static string m_name = "Coup Puissant";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.CoupPuissant];
        private static int m_tooltip = 3006306;
        private static string m_description = "Augmente les dégâts des coups critiques.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "+5% de dégâts", 
                "+10% de dégâts", 
                "+15% de dégâts", 
                "+20% de dégâts", 
                "+25% de dégâts", 
                "+30% de dégâts", 
                "+35% de dégâts", 
                "+40% de dégâts", 
                "+45% de dégâts", 
                "+50% de dégâts", 
                "+55% de dégâts",
                "+5% par niveau"
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
