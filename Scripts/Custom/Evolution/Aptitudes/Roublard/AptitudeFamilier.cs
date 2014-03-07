using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeFamilier
    {
        private static string m_name = "Familier";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Familier];
        private static int m_tooltip = 3006341;
        private static string m_description = "Augmente le nombre de compagnons maximum.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "+1 Familier", 
                "+2 Familier", 
                "+3 Familier",
                "+4 Familier", 
                "+5 Familier", 
                "+6 Familier", 
                "+7 Familier", 
                "+8 Familier",
                "+9 Familier",
                "+10 Familier",
                "+11 Familier", 
                "+1 Familier/niveau"
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
