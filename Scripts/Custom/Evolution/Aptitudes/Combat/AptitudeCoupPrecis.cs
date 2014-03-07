using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeCoupPrecis
    {
        private static string m_name = "Coup Precis";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.CoupPrecis];
        private static int m_tooltip = 3006305;
        private static string m_description = "Augmente les chances des coups critiques.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "+2% de chance", 
                "+4% de chance", 
                "+6% de chance", 
                "+8% de chance", 
                "+10% de chance",
                "+12% de chance", 
                "+14% de chance", 
                "+16% de chance", 
                "+18% de chance", 
                "+20% de chance", 
                "+22% de chance", 
                "+2% par niveau"
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
