using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeIllusion
    {
        private static string m_name = "Illusion";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Illusion];
        private static int m_tooltip = 3006320;
        private static string m_description = "Permet d'user des illusions pour fourber vos adversaires.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "Vision Nocturne, Voile",
                 "", 
                 "Téléportation", 
                 "Incognito", 
                 "Rappel", 
                 "Lobotomie",
                 "Marque", 
                 "Polymorph", 
                 "Révélation", 
                 "Invisibilité",
                 "", 
                 "Voyagement"
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
