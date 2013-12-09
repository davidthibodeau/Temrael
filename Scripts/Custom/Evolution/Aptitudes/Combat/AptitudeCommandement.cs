using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeCommandement
    {
        private static string m_name = "Commandement";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Commandement];
        private static int m_tooltip = 3006304;
        private static string m_description = "Augmente le nombre de soldats possible à contrôler.";
        private static string m_note = "Les soldats sont accessibles de la géopolitique ou du recrutement de mercenaires.";
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "1 soldat", 
                "2 soldats", 
                "3 soldats", 
                "4 soldats", 
                "5 soldats", 
                "6 soldats", 
                "7 soldats", 
                "8 soldats", 
                "9 soldats", 
                "10 soldats",
                "11 soldats", 
                "+ 1 soldat par niveau"
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
