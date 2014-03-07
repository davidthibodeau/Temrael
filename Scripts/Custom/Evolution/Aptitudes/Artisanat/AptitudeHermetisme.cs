using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeHermetisme
    {
        private static string m_name = "Hermetisme";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Hermetisme];
        private static int m_tooltip = 3006296;
        private static string m_description = "Permet de créer des objets alchimiques.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "P. créer objets 40 Alchimie",
                "P. créer objets 50 Alchimie",
                "P. créer objets 55 Alchimie",
                "P. créer objets 60 Alchimie", 
                "P. créer objets 65 Alchimie", 
                "P. créer objets 70 Alchimie", 
                "P. créer objets 75 Alchimie", 
                "P. créer objets 80 Alchimie",
                "P. créer objets 85 Alchimie", 
                "P. créer objets 90 Alchimie", 
                "P. créer objets 95 Alchimie", 
                "P. objets 100 Alchimie (Max)"
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
