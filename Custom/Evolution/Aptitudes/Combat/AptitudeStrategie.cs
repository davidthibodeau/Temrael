using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeStrategie
    {
        private static string m_name = "Strategie";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Strategie];
        private static int m_tooltip = 3006315;
        private static string m_description = "Permet l'accès aux formations militaires.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "Aucune", 
                "Bordel", 
                "Aucune", 
                "Autre", 
                "Aucune", 
                "Ligne", 
                "Aucune", 
                "Triangle",
                "Aucune", 
                "Carré Plein",
                "Aucune", 
                "Carré Vide"
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
