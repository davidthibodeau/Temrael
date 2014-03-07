using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeParade
    {
        private static string m_name = "Parade";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Parade];
        private static int m_tooltip = 3006310;
        private static string m_description = "Augmente les chances de parer une attaque adverse.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "+3% de chance",
                "+6% de chance", 
                "+9% de chance", 
                "+12% de chance",
                "+15% de chance", 
                "+18% de chance", 
                "+21% de chance", 
                "+24% de chance", 
                "+27% de chance", 
                "+30% de chance", 
                "+33% de chance",
                "+3% par niveau"
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
