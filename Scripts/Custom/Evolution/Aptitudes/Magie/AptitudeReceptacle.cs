using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeReceptacle
    {
        private static string m_name = "Receptacle";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Receptacle];
        private static int m_tooltip = 3006323;
        private static string m_description = "Augmente la mana maximum.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "3 Mana Bonus", 
                 "6 Mana Bonus", 
                 "9 Mana Bonus", 
                 "12 Mana Bonus",
                 "15 Mana Bonus", 
                 "18 Mana Bonus", 
                 "21 Mana Bonus", 
                 "24 Mana Bonus", 
                 "27 Mana Bonus", 
                 "30 Mana Bonus",
                 "33 Mana Bonus", 
                 "+3 Mana Bonus Par Niveau"
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
