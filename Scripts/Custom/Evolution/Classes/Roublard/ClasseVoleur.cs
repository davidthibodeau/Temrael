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
        private static AlignementB m_Alignement = AlignementB.Aucun;

        private static String[] m_Noms = new String[]
            {
                "Bandit",
                "Detrousseur",
                "Cambrioleur",
                "Voleur"
            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 1),
                new ClasseAptitudes(NAptitude.PortArme, 1),
                new ClasseAptitudes(NAptitude.Cambriolage, 3),
                new ClasseAptitudes(NAptitude.Derobage, 2),
                new ClasseAptitudes(NAptitude.Pillage, 2)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 1),
                new ClasseAptitudes(NAptitude.PortArme, 2),
                new ClasseAptitudes(NAptitude.Cambriolage, 6),
                new ClasseAptitudes(NAptitude.Derobage, 4),
                new ClasseAptitudes(NAptitude.Pillage, 4)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 2),
                new ClasseAptitudes(NAptitude.PortArme, 2),
                new ClasseAptitudes(NAptitude.Cambriolage, 9),
                new ClasseAptitudes(NAptitude.Derobage, 6),
                new ClasseAptitudes(NAptitude.Pillage, 6)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 2),
                new ClasseAptitudes(NAptitude.PortArme, 3),
                new ClasseAptitudes(NAptitude.Cambriolage, 12),
                new ClasseAptitudes(NAptitude.Derobage, 8),
                new ClasseAptitudes(NAptitude.Pillage, 8)
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
