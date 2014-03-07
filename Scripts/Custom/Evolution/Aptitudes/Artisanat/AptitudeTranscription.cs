using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class AptitudeTranscription
    {
        private static string m_name = "Transcription";
        private static AptitudesEntry m_entry = Aptitudes.m_AptitudeEntries[(int)Aptitude.Transcription];
        private static int m_tooltip = 3006300;
        private static string m_description = "Permet d'écrire des parchemins magiques.";
        private static string m_note = string.Empty;
        private static int m_image = 0;

        private static String[] m_descriptionNiveau = new String[]
            {
                "P. créer objets 40 Inscription",
                "P. créer objets 50 Inscription", 
                "P. créer objets 55 Inscription", 
                "P. créer objets 60 Inscription", 
                "P. créer objets 65 Inscription",
                "P. créer objets 70 Inscription", 
                "P. créer objets 75 Inscription", 
                "P. créer objets 80 Inscription", 
                "P. créer objets 85 Inscription", 
                "P. créer objets 90 Inscription", 
                "P. créer objets 95 Inscription", 
                "P. objets 100 Inscription (Max)"
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
