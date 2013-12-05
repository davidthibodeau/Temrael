using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeSpiritisme
    {
        private static string m_name = "Spiritisme";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Spiritisme];
        private static int m_tooltip = 3006325;
        private static string m_description = "Augmente la durée des sorts.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "+5% de durée prolongée",
                 "+10% de durée prolongée", 
                 "+15% de durée prolongée",
                 "+20% de durée prolongée", 
                 "+25% de durée prolongée", 
                 "+30% de durée prolongée", 
                 "+35% de durée prolongée",
                 "+40% de durée prolongée", 
                 "+45% de durée prolongée", 
                 "+50% de durée prolongée", 
                 "+55% de durée prolongée", 
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
