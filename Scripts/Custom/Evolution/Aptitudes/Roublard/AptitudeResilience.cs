using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeResilience
    {
        private static string m_name = "Resilience";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Resilience];
        private static int m_tooltip = 3006345;
        private static string m_description = "Augmente le maximum de stamina.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "3 Stamina Bonus", 
                 "6 Stamina Bonus", 
                 "9 Stamina Bonus", 
                 "12 Stamina Bonus",
                 "15 Stamina Bonus", 
                 "18 Stamina Bonus", 
                 "21 Stamina Bonus", 
                 "24 Stamina Bonus", 
                 "27 Stamina Bonus", 
                 "30 Stamina Bonus", 
                 "33 Stamina Bonus", 
                 "+3 Stamina Bonus Par Niveau"
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
