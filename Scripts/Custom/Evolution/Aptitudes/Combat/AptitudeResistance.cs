using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeResistance
    {
        private static string m_name = "Resistance";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Resistance];
        private static int m_tooltip = 3006313;
        private static string m_description = "Augmente l'AR naturel du personnage.";
        private static string m_note = "L'AR Naturel est ajouté automatiquement à votre personnage.";
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "+2 d'AR naturel",
                "+4 d'AR naturel", 
                "+6 d'AR naturel",
                "+8 d'AR naturel", 
                "+10 d'AR naturel",
                "+12 d'AR naturel", 
                "+14 d'AR naturel", 
                "+16 d'AR naturel", 
                "+18 d'AR naturel", 
                "+20 d'AR naturel", 
                "+22 d'AR naturel", 
                "+2 par niveau"
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
