using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeDerobage
    {
        private static string m_name = "Derobage";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Derobage];
        private static int m_tooltip = 3006339;
        private static string m_description = "Augmente les chances d'une réussite d'usage du fouet.";
        private static string m_note = "Double cliquer un fouet puis un personnage armé.";
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "+ 4% Désarmer, +2 % Voler", 
                "+8 % Désarmer, +4 % Voler", 
                "+12 % Désarmer, +6 % Voler",
                "+16 % Désarmer, +8 % Voler",
                "+20 % Désarmer, +10 % Voler",
                "+24 % Désarmer, +12 % Voler", 
                "+ 28% Désarmer, + 14% Voler", 
                "+32 % Désarmer, +16 % Voler", 
                "+36 % Désarmer, +18 % Voler", 
                "+40 % Désarmer, +20 % Voler", 
                "+44 % Désarmer, +22 % Voler", 
                "+4 %, +2 % par niveau"
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
