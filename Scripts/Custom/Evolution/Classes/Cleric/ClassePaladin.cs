using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClassePaladin
    {
        private static ClasseType m_Classe = ClasseType.Paladin;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Cleric;
        private static int m_Image = 305;
        private static int m_Tooltip = 0;
        private static string m_Name = "Paladin";
        private static string m_Role = "À venir";
        private static AlignementB m_Alignement = AlignementB.Bon;

        private static String[] m_Noms = new String[]
            {
                "Mirmillon",
                "Fanatique",
                "Templier",
                "Paladin"
            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.DispenseComposante, 1),
                new ClasseAptitudes(NAptitude.PortArmeMagique, 1),
                new ClasseAptitudes(NAptitude.Thaumaturgie, 1),
                new ClasseAptitudes(NAptitude.PortArmure, 2),
                new ClasseAptitudes(NAptitude.PortArme, 2),
                new ClasseAptitudes(NAptitude.PortBouclier, 1)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.DispenseComposante, 1),
                new ClasseAptitudes(NAptitude.PortArmeMagique, 2),
                new ClasseAptitudes(NAptitude.Thaumaturgie, 2),
                new ClasseAptitudes(NAptitude.PortArmure, 3),
                new ClasseAptitudes(NAptitude.PortArme, 3),
                new ClasseAptitudes(NAptitude.PortBouclier, 2)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.DispenseComposante, 1),
                new ClasseAptitudes(NAptitude.PortArmeMagique, 3),
                new ClasseAptitudes(NAptitude.Thaumaturgie, 3),
                new ClasseAptitudes(NAptitude.PortArmure, 4),
                new ClasseAptitudes(NAptitude.PortArme, 4),
                new ClasseAptitudes(NAptitude.PortBouclier, 3)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.DispenseComposante, 1),
                new ClasseAptitudes(NAptitude.PortArmeMagique, 3),
                new ClasseAptitudes(NAptitude.Thaumaturgie, 4),
                new ClasseAptitudes(NAptitude.PortArmure, 5),
                new ClasseAptitudes(NAptitude.PortArme, 5),
                new ClasseAptitudes(NAptitude.PortBouclier, 4)
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
