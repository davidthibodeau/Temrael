using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeTueurDeMonstre
    {
        private static string m_name = "Tueur de Monstre";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.TueurDeMonstre];
        private static int m_tooltip = 3006302;
        private static string m_description = "Augmente les dégâts, la réduction de dégâts et les chances de porter des coups critiques contre les animaux et créatures.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "+5% Dmg, +3% Def, +3% Crit", 
                "+10% Dmg, +6% Def, +6% Crit", 
                "+15% Dmg, +9% Def, +9% Crit", 
                "+20% Dmg, +12% Def, +12% Crit", 
                "+25% Dmg, +15% Def, +15% Crit", 
                "+30% Dmg, +18% Def, +18% Crit", 
                "+35% Dmg, +21% Def, +21% Crit", 
                "+40% Dmg, +24% Def, +24% Crit", 
                "+45% Dmg, +27% Def, +27% Crit",
                "+50% Dmg, +30% Def, +30% Crit", 
                "+55% Dmg, +33% Def, +33% Crit",
                "+60% Dmg, +36% Def, +36% Crit"
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
