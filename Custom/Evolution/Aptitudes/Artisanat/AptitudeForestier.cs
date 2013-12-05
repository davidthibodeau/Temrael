using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeForestier
    {
        private static string m_name = "Forestier";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Forestier];
        private static int m_tooltip = 0;
        private static string m_description = "Augmente le nombre de bûches coupés sur les arbres selon un certain % de chance.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
               	"5%", 
                "10%", 
                "15%", 
                "20%", 
                "25%", 
                "30%", 
                "35%", 
                "40%",
                "45%", 
                "50%", 
                "55%", 
                "60%"
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
