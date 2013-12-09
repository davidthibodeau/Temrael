using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeNecromancie
    {
        private static string m_name = "Necromancie";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Necromancie];
        private static int m_tooltip = 3006322;
        private static string m_description = "Permet d'utiliser les sorts qui altèrent la mort.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "Spectre", 
                 "Corruption, Présage", 
                 "Corps Mortifié",
                 "Minion",
                 "Bête Horrifique", 
                 "Venin", 
                 "Flétrir", 
                 "Étranglement", 
                 "Liche", 
                 "Maudire, Sermant", 
                 "Esprit Vengeur", 
                 "Animation, Vampirisme"
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
