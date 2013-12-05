using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeAssassinat
    {
        private static string m_name = "Assassinat";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Assassinat];
        private static int m_tooltip = 3006334;
        private static string m_description = "Augmente les chances et dégâts d'une tentative d'assassinat réussi.";
        private static string m_note = "Double cliquez une dague et ensuite un personnage joueur pour assassiner.";
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "+10% de chance", 
                "+20% de chance", 
                "+30% de chance", 
                "+40% de chance", 
                "+50% de chance", 
                "+60% de chance",
                "+70% de chance", 
                "+80% de chance", 
                "+90% de chance", 
                "+100% de chance",
                "+110% de chance",
                "+10% par niveau"
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
