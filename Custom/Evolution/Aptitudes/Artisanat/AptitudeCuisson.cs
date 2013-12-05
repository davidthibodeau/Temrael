using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeCuisson
    {
        private static string m_name = "Cuisson";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Cuisson];
        private static int m_tooltip = 3006293;
        private static string m_description = "Permet de créer des objets de cuisine.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "P. créer objets dem. 40 Cuisine", 
                "P. créer objets dem. 50 Cuisine", 
                "P. créer objets dem. 55 Cuisine",
                "P. créer objets dem. 60 Cuisine",
                "P. créer objets dem. 65 Cuisine", 
                "P. créer objets dem. 70 Cuisine",
                "P. créer objets dem. 75 Cuisine", 
                "P. créer objets dem. 80 Cuisine", 
                "P. créer objets dem. 85 Cuisine", 
                "P. créer objets dem. 90 Cuisine", 
                "P. créer objets dem. 95 Cuisine", 
                "P. objets 100 Cuisine (Max)"
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
