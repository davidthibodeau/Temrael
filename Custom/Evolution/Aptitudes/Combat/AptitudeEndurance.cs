using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeEndurance
    {
        private static string m_name = "Endurance";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Endurance];
        private static int m_tooltip = 3006308;
        private static string m_description = "Augmente le maximum de points de vie.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "3 Vitalité Bonus", 
                 "6 Vitalité Bonus", 
                 "9 Vitalité Bonus", 
                 "12 Vitalité Bonus",
                 "15 Vitalité Bonus",
                 "18 Vitalité Bonus", 
                 "21 Vitalité Bonus", 
                 "24 Vitalité Bonus", 
                 "27 Vitalité Bonus", 
                 "30 Vitalité Bonus", 
                 "33 Vitalité Bonus", 
                 "+3 Vitalité Bonus Par Niveau"
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
