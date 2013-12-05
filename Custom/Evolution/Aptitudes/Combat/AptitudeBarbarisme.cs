using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeBarbarisme
    {
        private static string m_name = "Barbarisme";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Barbarisme];
        private static int m_tooltip = 3006301;
        private static string m_description = "Augmente la réduction de l'AR de l'adversaire.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "+3% de réduction d'AR",
                "+6% de réduction d'AR", 
                "+9% de réduction d'AR", 
                "+12% de réduction d'AR",
                "+15% de réduction d'AR",
                "+18% de réduction d'AR",
                "+21% de réduction d'AR", 
                "+24% de réduction d'AR", 
                "+27% de réduction d'AR",
                "+30% de réduction d'AR", 
                "+33% de réduction d'AR", 
                "+3% par niveau"
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
