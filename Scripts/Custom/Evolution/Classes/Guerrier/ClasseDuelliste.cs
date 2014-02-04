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
                new ClasseAptitudes(NAptitude.PortArmure, 1),
                new ClasseAptitudes(NAptitude.PortArme, 4),
                new ClasseAptitudes(NAptitude.Esquive, 1),
                new ClasseAptitudes(NAptitude.CoupPrecis, 2),
                new ClasseAptitudes(NAptitude.CoupPuissant, 2)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 2),
                new ClasseAptitudes(NAptitude.PortArme, 5),
                new ClasseAptitudes(NAptitude.Esquive, 3),
                new ClasseAptitudes(NAptitude.CoupPrecis, 4),
                new ClasseAptitudes(NAptitude.CoupPuissant, 4)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 2),
                new ClasseAptitudes(NAptitude.PortArme, 6),
                new ClasseAptitudes(NAptitude.Esquive, 4),
                new ClasseAptitudes(NAptitude.CoupPrecis, 6),
                new ClasseAptitudes(NAptitude.CoupPuissant, 6)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 3),
                new ClasseAptitudes(NAptitude.PortArme, 6),
                new ClasseAptitudes(NAptitude.Esquive, 6),
                new ClasseAptitudes(NAptitude.CoupPrecis, 8),
                new ClasseAptitudes(NAptitude.CoupPuissant, 8)
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
