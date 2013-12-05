using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeSorcellerie
    {
        private static string m_name = "Sorcellerie";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Sorcellerie];
        private static int m_tooltip = 3006324;
        private static string m_description = "Augmente les dégâts des sorts.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "+4% de dégâts", 
                 "+8% de dégâts",
                 "+12% de dégâts",
                 "+16% de dégâts", 
                 "+20% de dégâts", 
                 "+24% de dégâts", 
                 "+28% de dégâts", 
                 "+32% de dégâts", 
                 "+36% de dégâts", 
                 "+40% de dégâts", 
                 "+44% de dégâts", 
                 "+4% par niveau"
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
