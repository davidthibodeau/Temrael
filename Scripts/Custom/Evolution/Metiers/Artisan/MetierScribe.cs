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
               	new ClasseAptitudes(10, NAptitude.Transcription, 10),
                new ClasseAptitudes(9, NAptitude.Transcription, 9),
                new ClasseAptitudes(8, NAptitude.Transcription, 8),
                new ClasseAptitudes(7, NAptitude.Transcription, 7),
                new ClasseAptitudes(6, NAptitude.Transcription, 6),
                new ClasseAptitudes(5, NAptitude.Transcription, 5),
                new ClasseAptitudes(4, NAptitude.Transcription, 4),
                new ClasseAptitudes(3, NAptitude.Transcription, 3),
                new ClasseAptitudes(2, NAptitude.Transcription, 2),
                new ClasseAptitudes(1, NAptitude.Transcription, 1),
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
