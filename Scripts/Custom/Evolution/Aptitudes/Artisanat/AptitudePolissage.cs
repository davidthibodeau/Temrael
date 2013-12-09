using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudePolissage
    {
        private static string m_name = "Polissage";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Polissage];
        private static int m_tooltip = 3006299;
        private static string m_description = "Augmente les chances de créer un objet exceptionel.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "+4% chance exceptionel", 
                "+8% chance exceptionel", 
                "+12% chance exceptionel", 
                "+16% chance exceptionel", 
                "+20% chance exceptionel", 
                "+24% chance exceptionel", 
                "+28% chance exceptionel", 
                "+32% chance exceptionel", 
                "+36% chance exceptionel", 
                "+40% chance exceptionel", 
                "+44% chance exceptionel", 
                "+4% chance exceptionel"
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
