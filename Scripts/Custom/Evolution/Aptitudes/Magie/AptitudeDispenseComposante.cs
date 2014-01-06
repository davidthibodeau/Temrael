using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeDispenseComposante
    {
        private static string m_name = "Dispense Compo.";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.DispenseComposante];
        private static int m_tooltip = 3006302;
        private static string m_description = "Permet d'incanter sans composantes matériels.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "Un Seul Niveau", 
                "N/A",
                "N/A",
                "N/A", 
                "N/A", 
                "N/A", 
                "N/A", 
                "N/A", 
                "N/A", 
                "N/A", 
                "N/A", 
                "N/A",
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
