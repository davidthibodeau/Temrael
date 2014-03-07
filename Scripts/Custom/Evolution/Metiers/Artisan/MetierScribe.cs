using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;

namespace Server
{
    public class MetierScribe
    {
        private static MetierType m_Metier = MetierType.Scribe;
        private static MetierBranche m_MetierBranche = MetierBranche.Artisan;
        private static string m_Nom = "Scribe";
        private static int m_Image = 488;

        private static ClasseAptitudes[] m_Aptitudes = new ClasseAptitudes[]
            {
               	new ClasseAptitudes(10, Aptitude.Transcription, 10),
                new ClasseAptitudes(9, Aptitude.Transcription, 9),
                new ClasseAptitudes(8, Aptitude.Transcription, 8),
                new ClasseAptitudes(7, Aptitude.Transcription, 7),
                new ClasseAptitudes(6, Aptitude.Transcription, 6),
                new ClasseAptitudes(5, Aptitude.Transcription, 5),
                new ClasseAptitudes(4, Aptitude.Transcription, 4),
                new ClasseAptitudes(3, Aptitude.Transcription, 3),
                new ClasseAptitudes(2, Aptitude.Transcription, 2),
                new ClasseAptitudes(1, Aptitude.Transcription, 1),
            };

        public static MetierInfo MetierInfo = new MetierInfo(
                m_Metier,
                m_Aptitudes,
                m_Nom,
                m_MetierBranche,
                m_Image
            );
    }
}
