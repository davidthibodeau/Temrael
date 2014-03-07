using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeFignolage
    {
        private static string m_name = "Fignolage";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Fignolage];
        private static int m_tooltip = 3006295;
        private static string m_description = "Augmente les chances de créer tous les objets.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "+4% chance de confection", 
                "+8% chance de confection", 
                "+12% chance de confection",
                "+16% chance de confection",
                "+20% chance de confection",
                "+24% chance de confection", 
                "+28% chance de confection", 
                "+32% chance de confection", 
                "+36% chance de confection", 
                "+40% chance de confection", 
                "+44% chance de confection",
                "+48% de chance de confection"
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
