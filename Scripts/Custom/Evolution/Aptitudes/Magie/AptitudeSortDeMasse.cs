using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeSortDeMasse
    {
        private static string m_name = "Sort de Masse";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.SortDeMasse];
        private static int m_tooltip = 3006325;
        private static string m_description = "Augmente le rayon d'action des sorts de masses.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "+1 tile",
                 "+2 tiles", 
                 "+3 tiles",
                 "+4 tiles", 
                 "+5 tiles", 
                 "+6 tiles", 
                 "+7 tiles",
                 "+8 tiles", 
                 "+9 tiles", 
                 "+10 tiles", 
                 "+11 tiles", 
                 "+12 tiles"
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
