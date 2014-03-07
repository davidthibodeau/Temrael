using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClasseSorcier
    {
        private static ClasseType m_Classe = ClasseType.Sorcier;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Magie;
        private static int m_Image = 339;
        private static int m_Tooltip = 0;
        private static string m_Name = "Sorcier";
        private static string m_Role = "À venir";
        private static AlignementB m_Alignement = AlignementB.Aucun;

        private static String[] m_Noms = new String[]
            {
                "Elementaliste",
                "Sorcier",
                "Evocateur",
                "Mage de Bataille"
            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmeMagique, 1),
                new ClasseAptitudes(Aptitude.Evocation, 3),
                new ClasseAptitudes(Aptitude.Sorcellerie, 1),
                new ClasseAptitudes(Aptitude.SortDeMasse, 2),
                new ClasseAptitudes(Aptitude.PortArmure, 1),
                new ClasseAptitudes(Aptitude.PortArme, 1)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmeMagique, 1),
                new ClasseAptitudes(Aptitude.Evocation, 6),
                new ClasseAptitudes(Aptitude.Sorcellerie, 2),
                new ClasseAptitudes(Aptitude.SortDeMasse, 3),
                new ClasseAptitudes(Aptitude.PortArmure, 1),
                new ClasseAptitudes(Aptitude.PortArme, 1)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmeMagique, 1),
                new ClasseAptitudes(Aptitude.Evocation, 9),
                new ClasseAptitudes(Aptitude.Sorcellerie, 3),
                new ClasseAptitudes(Aptitude.SortDeMasse, 4),
                new ClasseAptitudes(Aptitude.PortArmure, 2),
                new ClasseAptitudes(Aptitude.PortArme, 1)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmeMagique, 1),
                new ClasseAptitudes(Aptitude.Evocation, 12),
                new ClasseAptitudes(Aptitude.Sorcellerie, 4),
                new ClasseAptitudes(Aptitude.SortDeMasse, 6),
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
