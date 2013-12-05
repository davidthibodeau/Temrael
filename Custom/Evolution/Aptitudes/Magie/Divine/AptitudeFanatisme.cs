using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeFanatisme
    {
        private static string m_name = "Fanatisme";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[49];
        private static int m_tooltip = 3006328;
        private static string m_description = "Miracles du templier.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "Sacrifice", 
                 "Sauvegarde",
                 "Ferveur Divine",
                 "Bouclier Céleste",
                 "Fortification Divine",
                 "Monture Céleste", 
                 "Fougue Céleste", 
                 "Protection Céleste", 
                 "Bastion Céleste",
                 "Zèle Divin",
                 "Ardeur Céleste", 
                 "Défense Divine"
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
