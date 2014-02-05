using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClasseRodeur
    {
        private static ClasseType m_Classe = ClasseType.Rodeur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Roublard;
        private static int m_Image = 424;
        private static int m_Tooltip = 0;
        private static string m_Name = "Rodeur";
        private static string m_Role = "À venir";
        private static AlignementB m_Alignement = AlignementB.Aucun;

        private static String[] m_Noms = new String[]
            {
                "Forestier",
                "Pisteur",
                "Eclaireur",
                "Rodeur"
            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 2),
                new ClasseAptitudes(NAptitude.PortBouclier, 1),
                new ClasseAptitudes(NAptitude.PortArme, 2),
                new ClasseAptitudes(NAptitude.PortArmeDistance, 2),
                new ClasseAptitudes(NAptitude.LibreDeplacement, 2),
                new ClasseAptitudes(NAptitude.Depistage, 1),
                new ClasseAptitudes(NAptitude.Resilience, 1),
                new ClasseAptitudes(NAptitude.Familier, 1)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 2),
                new ClasseAptitudes(NAptitude.PortBouclier, 1),
                new ClasseAptitudes(NAptitude.PortArme, 3),
                new ClasseAptitudes(NAptitude.PortArmeDistance, 3),
                new ClasseAptitudes(NAptitude.LibreDeplacement, 5),
                new ClasseAptitudes(NAptitude.Depistage, 2),
                new ClasseAptitudes(NAptitude.Resilience, 2),
                new ClasseAptitudes(NAptitude.Familier, 3)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 2),
                new ClasseAptitudes(NAptitude.PortBouclier, 2),
                new ClasseAptitudes(NAptitude.PortArme, 3),
                new ClasseAptitudes(NAptitude.PortArmeDistance, 4),
                new ClasseAptitudes(NAptitude.LibreDeplacement, 7),
                new ClasseAptitudes(NAptitude.Depistage, 3),
                new ClasseAptitudes(NAptitude.Resilience, 3),
                new ClasseAptitudes(NAptitude.Familier, 4)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 3),
                new ClasseAptitudes(NAptitude.PortBouclier, 2),
                new ClasseAptitudes(NAptitude.PortArme, 4),
                new ClasseAptitudes(NAptitude.PortArmeDistance, 5),
                new ClasseAptitudes(NAptitude.LibreDeplacement, 10),
                new ClasseAptitudes(NAptitude.Depistage, 4),
                new ClasseAptitudes(NAptitude.Resilience, 4),
                new ClasseAptitudes(NAptitude.Familier, 6)
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
