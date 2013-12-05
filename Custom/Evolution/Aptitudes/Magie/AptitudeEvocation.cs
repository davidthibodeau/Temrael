using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeEvocation
    {
        private static string m_name = "Evocation";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)NAptitude.Evocation];
        private static int m_tooltip = 3006319;
        private static string m_description = "Permet d'évoquer les sorts de destructions.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                 "Bourrasque, Flamèche, Froid, Tempête",
                 "Boule de Feu", 
                 "Mur de Feu", 
                 "Énergie",
                 "Éclair", 
                 "Explosion",
                 "Énergie de Masse",
                 "Jet de Flamme", 
                 "Météores", 
                 "Tremblement",
                 "Vortex", 
                 "Chaine d'Éclairs"
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
