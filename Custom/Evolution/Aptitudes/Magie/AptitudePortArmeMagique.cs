using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudePortArmeMagique
    {
        private static string m_name = "Port d'Arme Magique";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.PortArmeMagique];
        private static int m_tooltip = 3006311;
        private static string m_description = "Permet les armes et boucliers tout en lancant des sorts.";
        private static string m_note = "Le niveau 3 permet de méditer avec une armure.";
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "Bâtons et armes à une main",
                "Armes à deux mains",
                "Boucliers", 
                "N/A", 
                "N/A", 
                "N/A", 
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
