using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClasseEspion
    {
        private static ClasseType m_Classe = ClasseType.Espion;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Roublard;
        private static int m_Image = 185;
        private static int m_Tooltip = 0;
        private static string m_Name = "Espion";
        private static string m_Role = "À venir";
        private static AlignementB m_Alignement = AlignementB.Aucun;

        private static String[] m_Noms = new String[]
            {
                "Charlatan",
                "Imposteur",
                "Espion",
                "Ombre"
            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 1),
                new ClasseAptitudes(NAptitude.PortBouclier, 1),
                new ClasseAptitudes(NAptitude.PortArme, 1),
                new ClasseAptitudes(NAptitude.Deguisement, 3),
                new ClasseAptitudes(NAptitude.MouvementCache, 2)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 2),
                new ClasseAptitudes(NAptitude.PortBouclier, 2),
                new ClasseAptitudes(NAptitude.PortArme, 2),
                new ClasseAptitudes(NAptitude.Deguisement, 6),
                new ClasseAptitudes(NAptitude.MouvementCache, 5)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 2),
                new ClasseAptitudes(NAptitude.PortBouclier, 2),
                new ClasseAptitudes(NAptitude.PortArme, 2),
                new ClasseAptitudes(NAptitude.Deguisement, 9),
                new ClasseAptitudes(NAptitude.MouvementCache, 7)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 3),
                new ClasseAptitudes(NAptitude.PortBouclier, 3),
                new ClasseAptitudes(NAptitude.PortArme, 3),
                new ClasseAptitudes(NAptitude.Deguisement, 12),
                new ClasseAptitudes(NAptitude.MouvementCache, 10)
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
