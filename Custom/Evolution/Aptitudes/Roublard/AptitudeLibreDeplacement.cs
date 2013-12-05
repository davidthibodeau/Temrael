using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeLibreDeplacement
    {
        private static string m_name = "Libre Deplacement";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.LibreDeplacement];
        private static int m_tooltip = 3006342;
        private static string m_description = "Réduit la perte de stamina sur les terrains considéré 'rudes'.";
        private static string m_note = "Les forêts, déserts, neige et marais sont considérés comme rudes.";
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "10 % de réduction",
                "20 % de réduction", 
                "30 % de réduction", 
                "40 % de réduction", 
                "50 % de réduction", 
                "60 % de réduction", 
                "70 % de réduction", 
                "80 % de réduction", 
                "90 % de réduction", 
                "100 % de réduction", 
                "110 % de réduction", 
                "120 % de réduction"
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
