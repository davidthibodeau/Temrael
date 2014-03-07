using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeAdjuration
    {
        private static string m_name = "Adjuration";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Adjuration];
        private static int m_tooltip = 3006317;
        private static string m_description = "Permet d'utiliser les sorts ténébreux qui utilisent la magie noire.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "Fermeture Magique & Piège Magique",
                 "Ouverture Magique & Suppression Magique", 
                 "Nuisance", "Champ de Dissipation", 
                 "Dissipation", "Drain de Mana", 
                 "Poison",
                 "Dissipation de Masse", 
                 "Drain Vampirique",
                 "Mur de Poison", 
                 "N/A", 
                 "N/A",
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
