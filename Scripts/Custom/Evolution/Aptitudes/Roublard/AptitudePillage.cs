using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudePillage
    {
        private static string m_name = "Pillage";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Pillage];
        private static int m_tooltip = 3006344;
        private static string m_description = "Augmente le poid maximal qu'un voleur peut voler.";
        private static string m_note = "Le poid sur UO est évalué en 'stone'.";
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "+5 'stone'", 
                 "+10 'stone'",
                 "+15 'stone'", 
                 "+20 'stone'", 
                 "+25 'stone'", 
                 "+30 'stone'", 
                 "+35 'stone'", 
                 "+40 'stone'", 
                 "+45 'stone'", 
                 "+50 'stone'",
                 "+55 'stone'", 
                 "+5 'stone'/niveau"
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
