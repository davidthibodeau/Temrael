using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeComposition
    {
        private static string m_name = "Composition";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Composition];
        private static int m_tooltip = 3006336;
        private static string m_description = "Donne accès aux musiques de bardes.";
        private static string m_note = "Accessible d'un instrument de musique.";
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "Bruit",
                "Son", 
                "Murmure", 
                "Sona", 
                "Hymne", 
                "Chant", 
                "Sonette",
                "Fanfare",
                "Poème", 
                "Symphonie", 
                "Harmonie", 
                "Sérénade"
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
