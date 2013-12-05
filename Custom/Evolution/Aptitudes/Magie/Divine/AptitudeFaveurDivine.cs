using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeFaveurDivine
    {
        private static string m_name = "Faveur Divine";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[50];
        private static int m_tooltip = 3006329;
        private static string m_description = "Augmente l'effet des miracles.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "+4% d'efficacité", 
                 "+8% d'efficacité", 
                 "+12% d'efficacité", 
                 "+16% d'efficacité", 
                 "+20% d'efficacité", 
                 "+24% d'efficacité", 
                 "+28% d'efficacité", 
                 "+32% d'efficacité", 
                 "+36% d'efficacité", 
                 "+40% d'efficacité", 
                 "+44% d'efficacité", 
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
