using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeMetallurgie
    {
        private static string m_name = "Metallurgie";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Metallurgie];
        private static int m_tooltip = 3006298;
        private static string m_description = "Permet de forger des armes et armures.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "P. créer objets dem. 40 Forge",
                "P. créer objets dem. 50 Forge",
                "P. créer objets dem. 55 Forge", 
                "P. créer objets dem. 60 Forge", 
                "P. créer objets dem. 65 Forge", 
                "P. créer objets dem. 70 Forge", 
                "P. créer objets dem. 75 Forge", 
                "P. créer objets dem. 80 Forge", 
                "P. créer objets dem. 85 Forge", 
                "P. créer objets dem. 90 Forge", 
                "P. créer objets dem. 95 Forge", 
                "P. objets 100 Forge (Max)"
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
