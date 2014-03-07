using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClasseDuelliste
    {
        private static ClasseType m_Classe = ClasseType.Duelliste;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Guerrier;
        private static int m_Image = 303;
        private static int m_Tooltip = 0;
        private static string m_Name = "Duelliste";
        private static string m_Role = "À venir";
        private static AlignementB m_Alignement = AlignementB.Aucun;

        private static String[] m_Noms = new String[]
            {
                "Dandy",
                "Bretteur",
                "Duelliste",
                "Fine Lame"
            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 1),
                new ClasseAptitudes(Aptitude.PortArme, 4),
                new ClasseAptitudes(Aptitude.Esquive, 1),
                new ClasseAptitudes(Aptitude.CoupPrecis, 2),
                new ClasseAptitudes(Aptitude.CoupPuissant, 2)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 2),
                new ClasseAptitudes(Aptitude.PortArme, 5),
                new ClasseAptitudes(Aptitude.Esquive, 3),
                new ClasseAptitudes(Aptitude.CoupPrecis, 4),
                new ClasseAptitudes(Aptitude.CoupPuissant, 4)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 2),
                new ClasseAptitudes(Aptitude.PortArme, 6),
                new ClasseAptitudes(Aptitude.Esquive, 4),
                new ClasseAptitudes(Aptitude.CoupPrecis, 6),
                new ClasseAptitudes(Aptitude.CoupPuissant, 6)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 3),
                new ClasseAptitudes(Aptitude.PortArme, 6),
                new ClasseAptitudes(Aptitude.Esquive, 6),
                new ClasseAptitudes(Aptitude.CoupPrecis, 8),
                new ClasseAptitudes(Aptitude.CoupPuissant, 8)
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
