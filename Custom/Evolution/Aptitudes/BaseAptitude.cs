using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class BaseAptitude
    {
        private static string m_name = string.Empty;
        private static AptitudesEntry m_entry = null;
        private static int m_tooltip = 0;
        private static string m_description = string.Empty;
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {

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
