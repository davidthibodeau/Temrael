using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudePrecision
    {
        private static string m_name = "Precision";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Precision];
        private static int m_tooltip = 3006312;
        private static string m_description = "Augmente les chances d'atteindre son adversaire.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "+4% de chance", 
                "+8% de chance", 
                "+12% de chance", 
                "+16% de chance", 
                "+20% de chance", 
                "+24% de chance", 
                "+28% de chance", 
                "+32% de chance", 
                "+36% de chance", 
                "+40% de chance", 
                "+44% de chance", 
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
