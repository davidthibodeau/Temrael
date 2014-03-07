using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeCommerce
    {
        private static string m_name = "Commerce";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Commerce];
        private static int m_tooltip = 0;
        private static string m_description = "Permet de placer des NPC vendeur joueur dans des zones designes.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
               	"P. d'ajouter des NPC", 
                "", 
                "", 
                "", 
                "", 
                "", 
                "", 
                "",
                "", 
                "", 
                "", 
                ""
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
