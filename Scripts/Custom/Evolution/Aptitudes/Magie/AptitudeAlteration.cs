using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeAlteration
    {
        private static string m_name = "Alteration";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Alteration];
        private static int m_tooltip = 3006318;
        private static string m_description = "Permet d'utiliser les sorts mystiques qui altèrent les capacités des autres personnages.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "Faiblesse", 
                 "Maladroit",
                 "Débilité", 
                 "Télékinesis",
                 "Reflet", 
                 "", 
                 "", 
                 "Malédiction", 
                 "", 
                 "Paralysie", 
                 "Fléau", 
                 "Pétrification"
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
