using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClasseIllusioniste
    {
        private static ClasseType m_Classe = ClasseType.Illusioniste;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Magie;
        private static int m_Image = 194;
        private static int m_Tooltip = 0;
        private static string m_Name = "Illusioniste";
        private static string m_Role = "À venir";
        private static AlignementB m_Alignement = AlignementB.Aucun;

        private static String[] m_Noms = new String[]
            {
                "Prestidigitateur",
                "Ensorceleur",
                "Illusioniste",
                "Tisseur de Reves"
            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.Illusion, 3),
                new ClasseAptitudes(Aptitude.Adjuration, 2),
                new ClasseAptitudes(Aptitude.PortArmure, 1),
                new ClasseAptitudes(Aptitude.PortArme, 1)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmeMagique, 1),
                new ClasseAptitudes(Aptitude.Transcription, 1),
                new ClasseAptitudes(Aptitude.Illusion, 6),
                new ClasseAptitudes(Aptitude.Adjuration, 4),
                new ClasseAptitudes(Aptitude.PortArmure, 1),
                new ClasseAptitudes(Aptitude.PortArme, 1)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmeMagique, 1),
                new ClasseAptitudes(Aptitude.Transcription, 1),
                new ClasseAptitudes(Aptitude.Illusion, 9),
                new ClasseAptitudes(Aptitude.Adjuration, 6),
                new ClasseAptitudes(Aptitude.PortArmure, 1),
                new ClasseAptitudes(Aptitude.PortArme, 1)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmeMagique, 1),
                new ClasseAptitudes(Aptitude.Transcription, 2),
                new ClasseAptitudes(Aptitude.Illusion, 12),
                new ClasseAptitudes(Aptitude.Adjuration, 8),
                new ClasseAptitudes(Aptitude.PortArmure, 2),
                new ClasseAptitudes(Aptitude.PortArme, 1)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_firstApt,
                m_secondApt,
                m_thirdApt,
                m_fourthApt,
                m_Name,
                m_Noms,
                m_Role,
                m_ClasseBranche,
                m_Image,
                m_Tooltip
            );
    }
}
