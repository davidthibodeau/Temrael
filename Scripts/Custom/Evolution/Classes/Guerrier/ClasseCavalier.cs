using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClasseCavalier
    {
        private static ClasseType m_Classe = ClasseType.Cavalier;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Guerrier;
        private static int m_Image = 328;
        private static int m_Tooltip = 0;
        private static string m_Name = "Cavalier";
        private static string m_Role = "À venir";
        private static AlignementB m_Alignement = AlignementB.Aucun;

        private static String[] m_Noms = new String[]
            {
                "Ecuyer",
                "Cavalier",
                "Jouteur",
                "Chevalier"
            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 2),
                new ClasseAptitudes(NAptitude.PortArme, 3),
                new ClasseAptitudes(NAptitude.PortBouclier, 2),
                new ClasseAptitudes(NAptitude.CombatMonte, 2)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 3),
                new ClasseAptitudes(NAptitude.PortArme, 4),
                new ClasseAptitudes(NAptitude.PortBouclier, 3),
                new ClasseAptitudes(NAptitude.CombatMonte, 4)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 4),
                new ClasseAptitudes(NAptitude.PortArme, 5),
                new ClasseAptitudes(NAptitude.PortBouclier, 4),
                new ClasseAptitudes(NAptitude.CombatMonte, 6)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 5),
                new ClasseAptitudes(NAptitude.PortArme, 6),
                new ClasseAptitudes(NAptitude.PortBouclier, 5),
                new ClasseAptitudes(NAptitude.CombatMonte, 8)
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
