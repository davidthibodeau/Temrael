using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClasseVoleur
    {
        private static ClasseType m_Classe = ClasseType.Voleur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Roublard;
        private static int m_Image = 429;
        private static int m_Tooltip = 0;
        private static string m_Name = "Voleur";
        private static string m_Role = "À venir";

        private static String[] m_Noms = new String[]
            {
                "Bandit",
                "Detrousseur",
                "Cambrioleur",
                "Voleur"
            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 1),
                new ClasseAptitudes(Aptitude.PortArme, 1),
                new ClasseAptitudes(Aptitude.Cambriolage, 3),
                new ClasseAptitudes(Aptitude.Derobage, 2),
                new ClasseAptitudes(Aptitude.Pillage, 2)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 1),
                new ClasseAptitudes(Aptitude.PortArme, 2),
                new ClasseAptitudes(Aptitude.Cambriolage, 6),
                new ClasseAptitudes(Aptitude.Derobage, 4),
                new ClasseAptitudes(Aptitude.Pillage, 4)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 2),
                new ClasseAptitudes(Aptitude.PortArme, 2),
                new ClasseAptitudes(Aptitude.Cambriolage, 9),
                new ClasseAptitudes(Aptitude.Derobage, 6),
                new ClasseAptitudes(Aptitude.Pillage, 6)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 2),
                new ClasseAptitudes(Aptitude.PortArme, 3),
                new ClasseAptitudes(Aptitude.Cambriolage, 12),
                new ClasseAptitudes(Aptitude.Derobage, 8),
                new ClasseAptitudes(Aptitude.Pillage, 8)
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
