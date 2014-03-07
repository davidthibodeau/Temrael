using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeIncantation
    {
        private static string m_name = "Incantation";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Incantation];
        private static int m_tooltip = 3006324;
        private static string m_description = "Augmente la rapidité des incantations.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "Augmente la rapidité", 
                 "Augmente la rapidité",
                 "Augmente la rapidité",
                 "Augmente la rapidité", 
                 "Augmente la rapidité", 
                 "Augmente la rapidité", 
                 "Augmente la rapidité", 
                 "Augmente la rapidité", 
                 "Augmente la rapidité", 
                 "Augmente la rapidité", 
                 "N/A", 
                 "N/A"
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
