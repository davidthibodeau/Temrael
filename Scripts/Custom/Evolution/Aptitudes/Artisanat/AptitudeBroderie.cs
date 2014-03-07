using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeBroderie
    {
        private static string m_name = "Broderie";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Broderie];
        private static int m_tooltip = 3006292;
        private static string m_description = "Permet de créer des objets de couture.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
               	"P. créer objets dem. 40 Couture", 
                "P. créer objets dem. 50 Couture", 
                "P. créer objets dem. 55 Couture", 
                "P. créer objets dem. 60 Couture", 
                "P. créer objets dem. 65 Couture", 
                "P. créer objets dem. 70 Couture", 
                "P. créer objets dem. 75 Couture", 
                "P. créer objets dem. 80 Couture",
                "P. créer objets dem. 85 Couture", 
                "P. créer objets dem. 90 Couture", 
                "P. créer objets dem. 95 Couture", 
                "P. objets 100 Couture (Max)"
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
