using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClassePretre
    {
        private static ClasseType m_Classe = ClasseType.Pretre;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Cleric;
        private static int m_Image = 352;
        private static int m_Tooltip = 0;
        private static string m_Name = "Pretre";
        private static string m_Role = "À venir";
        private static AlignementB m_Alignement = AlignementB.Aucun;

        private static String[] m_Noms = new String[]
            {
                "Moine",
                "Pretre",
                "Clerc",
                "Archidiacre"
            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.DispenseComposante, 1),
                new ClasseAptitudes(NAptitude.Thaumaturgie, 3),
                new ClasseAptitudes(NAptitude.Incantation, 1),
                new ClasseAptitudes(NAptitude.Spiritisme, 2),
                new ClasseAptitudes(NAptitude.PortArmure, 1),
                new ClasseAptitudes(NAptitude.PortArme, 1)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.DispenseComposante, 1),
                new ClasseAptitudes(NAptitude.Thaumaturgie, 6),
                new ClasseAptitudes(NAptitude.Incantation, 2),
                new ClasseAptitudes(NAptitude.Spiritisme, 4),
                new ClasseAptitudes(NAptitude.PortArmure, 1),
                new ClasseAptitudes(NAptitude.PortArme, 2)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.DispenseComposante, 1),
                new ClasseAptitudes(NAptitude.PortArmeMagique, 1),
                new ClasseAptitudes(NAptitude.Thaumaturgie, 9),
                new ClasseAptitudes(NAptitude.Incantation, 3),
                new ClasseAptitudes(NAptitude.Spiritisme, 5),
                new ClasseAptitudes(NAptitude.PortArmure, 2),
                new ClasseAptitudes(NAptitude.PortArme, 2)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.DispenseComposante, 1),
                new ClasseAptitudes(NAptitude.PortArmeMagique, 1),
                new ClasseAptitudes(NAptitude.Thaumaturgie, 12),
                new ClasseAptitudes(NAptitude.Incantation, 4),
                new ClasseAptitudes(NAptitude.Spiritisme, 6),
                new ClasseAptitudes(NAptitude.PortArmure, 2),
                new ClasseAptitudes(NAptitude.PortArme, 2)
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
