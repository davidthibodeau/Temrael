using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeInvocation
    {
        private static string m_name = "Invocation";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Invocation];
        private static int m_tooltip = 3006321;
        private static string m_description = "Permet de conjurer des créatures et objets des mondes mystiques.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "Nourriture", 
                 "Flèche Magique", 
                 "Mur de Pierre", 
                 "Convocation", 
                 "Élémental de Terre",
                 "Esprit de Lames", 
                 "Élémental d'Air", 
                 "", 
                 "Élémental de Feu", 
                 "Élémental d'Eau", 
                 "", 
                 "Conjuration"
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
