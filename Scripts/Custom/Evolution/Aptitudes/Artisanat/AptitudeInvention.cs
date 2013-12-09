using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeInvention
    {
        private static string m_name = "Invention";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Invention];
        private static int m_tooltip = 3006297;
        private static string m_description = "Permet de bricoler des objets et inventions.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "P. créer objets 40 Bricolage", 
                "P. créer objets 50 Bricolage",
                "P. créer objets 55 Bricolage", 
                "P. créer objets 60 Bricolage",
                "P. créer objets 65 Bricolage", 
                "P. créer objets 70 Bricolage", 
                "P. créer objets 75 Bricolage", 
                "P. créer objets 80 Bricolage", 
                "P. créer objets 85 Bricolage", 
                "P. créer objets 90 Bricolage", 
                "P. créer objets 95 Bricolage", 
                "P. objets 100 Bricolage (Max)"
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
