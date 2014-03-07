using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeDeguisement
    {
        private static string m_name = "Deguisement";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Deguisement];
        private static int m_tooltip = 3006337;
        private static string m_description = "Augmente le nombre d'identité du personnage.";
        private static string m_note = "Accessible d'un kit de déguisement.";
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "1 identité",
                "2 identités", 
                "3 identités", 
                "4 identités", 
                "5 identités", 
                "6 identités", 
                "7 identités",
                "8 identités",
                "9 identités", 
                "10 identités", 
                "11 identités", 
                "+1 identité"
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
