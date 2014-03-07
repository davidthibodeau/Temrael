using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudePortArme
    {
        private static string m_name = "Port d'Arme";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.PortArme];
        private static int m_tooltip = 3006311;
        private static string m_description = "Permet le port d'armes.";
        private static string m_note = "Voir le port d'arme de distance pour les armes de jet.";
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "Permet le port de niv. 1",
                "Permet le port de niv. 2",
                "Permet le port de niv. 3", 
                "Permet le port de niv. 4", 
                "Permet le port de niv. 5", 
                "Permet le port de niv. 6", 
                "N/A", 
                "N/A", 
                "N/A", 
                "N/A", 
                "N/A",
                "N/A"
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
