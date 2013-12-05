using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeGraceDivine
    {
        private static string m_name = "Grace Divine";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[51];
        private static int m_tooltip = 3006330;
        private static string m_description = "Augmente le maximum de piété.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "+10 points de piété", 
                 "+20 points de piété",
                 "+30 points de piété",
                 "+40 points de piété",
                 "+50 points de piété",
                 "+60 points de piété",
                 "+70 points de piété",
                 "+80 points de piété",
                 "+90 points de piété", 
                 "+100 points de piété",
                 "+110 points de piété",
                 "+10 par niveau"
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
