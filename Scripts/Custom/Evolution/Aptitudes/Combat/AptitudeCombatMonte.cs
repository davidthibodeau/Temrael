using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeCombatMonte
    {
        private static string m_name = "Combat monte";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.CombatMonte];
        private static int m_tooltip = 3006303;
        private static string m_description = "Augmente les dégâts à cheval et les chances de rester en scelle lors d'actions complexes.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "+3% de Dégâts à cheval", 
                "+6% de Dégâts à cheval", 
                "+9% de Dégâts à cheval", 
                "+12% de Dégâts à cheval", 
                "+15% de Dégâts à cheval",
                "+18% de Dégâts à cheval", 
                "+21% de Dégâts à cheval", 
                "+24% de Dégâts à cheval",
                "+27% de Dégâts à cheval",
                "+30% de Dégâts à cheval", 
                "+33% de Dégâts à cheval", 
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
