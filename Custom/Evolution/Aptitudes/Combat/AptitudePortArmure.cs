using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudePortArmure
    {
        private static string m_name = "Port d'Armure";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.PortArmure];
        private static int m_tooltip = 3006311;
        private static string m_description = "Permet le port d'armures.";
        private static string m_note = "Voir le port de bouclier pour les boucliers et pavois.";
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
