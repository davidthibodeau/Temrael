using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeBenedictions
    {
        private static string m_name = "Benedictions";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[48];
        private static int m_tooltip = 3006327;
        private static string m_description = "Miracles du prêtre.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "Repas Céleste", 
                 "Repos Céleste", 
                 "Panacée",
                 "Guérison Céleste", 
                 "Exaltation",
                 "Stase",
                 "Véhémence", 
                 "Rétablissement",
                 "Extase",
                 "Bénir", 
                 "Remède Divin",
                 "Guérison Miraculeuse"
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
