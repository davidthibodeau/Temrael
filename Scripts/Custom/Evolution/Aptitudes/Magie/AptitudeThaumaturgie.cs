using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeThaumaturgie
    {
        private static string m_name = "Thaumaturgie";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Thaumaturgie];
        private static int m_tooltip = 3006326;
        private static string m_description = "Permet de soigner les autres personnages avec les sorts de restoration.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "Force", 
                 "Agilité",
                 "Ruse", 
                 "Armure Magique",
                 "Protection", 
                 "Antidote",
                 "Soins", 
                 "Puissance",
                 "Remède", 
                 "Protection Magique",
                 "Soins Magiques", 
                 "Résurrection"
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
