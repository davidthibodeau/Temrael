using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeRobustesse
    {
        private static string m_name = "Robustesse";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Robustesse];
        private static int m_tooltip = 3006314;
        private static string m_description = "Augmente la résistance du personnage aux dégâts physiques.";
        private static string m_note = "Réduction des dégâts reçus.";
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "+2% de réduction",
                "+4% de réduction", 
                "+6% de réduction", 
                "+8% de réduction", 
                "+10% de réduction",
                "+12% de réduction", 
                "+14% de réduction",
                "+16% de réduction", 
                "+18% de réduction", 
                "+20% de réduction", 
                "+22% de réduction", 
                "+24% de réduction"
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
