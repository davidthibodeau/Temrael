using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeEbenisterie
    {
        private static string m_name = "Ebenisterie";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Ebenisterie];
        private static int m_tooltip = 3006294;
        private static string m_description = "Permet de créer des objets de bois.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "P. créer objets 40 Menuiserie", 
                "P. créer objets 50 Menuiserie", 
                "P. créer objets 55 Menuiserie", 
                "P. créer objets 60 Menuiserie", 
                "P. créer objets 65 Menuiserie", 
                "P. créer objets 70 Menuiserie", 
                "P. créer objets 75 Menuiserie", 
                "P. créer objets 80 Menuiserie", 
                "P. créer objets 85 Menuiserie", 
                "P. créer objets 90 Menuiserie", 
                "P. créer objets 95 Menuiserie", 
                "P. objets 100 Menuiserie (Max)"
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
