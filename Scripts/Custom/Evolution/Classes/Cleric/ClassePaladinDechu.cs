using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClassePaladinDechu
    {
        private static ClasseType m_Classe = ClasseType.PaladinDechu;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Cleric;
        private static int m_Image = 320;
        private static int m_Tooltip = 0;
        private static string m_Name = "Paladin Dechu";
        private static string m_Role = "À venir";
        private static AlignementB m_Alignement = AlignementB.Mauvais;

        private static String[] m_Noms = new String[]
            {
                "Sbire",
                "Cavalier Errant",
                "Chevalier Noir",
                "Paladin Dechu"
            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.DispenseComposante, 1),
                new ClasseAptitudes(NAptitude.PortArmeMagique, 1),
                new ClasseAptitudes(NAptitude.Necromancie, 1),
                new ClasseAptitudes(NAptitude.PortArmure, 2),
                new ClasseAptitudes(NAptitude.PortArme, 2),
                new ClasseAptitudes(NAptitude.PortBouclier, 1)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.DispenseComposante, 1),
                new ClasseAptitudes(NAptitude.PortArmeMagique, 2),
                new ClasseAptitudes(NAptitude.Necromancie, 2),
                new ClasseAptitudes(NAptitude.PortArmure, 3),
                new ClasseAptitudes(NAptitude.PortArme, 3),
                new ClasseAptitudes(NAptitude.PortBouclier, 2)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.DispenseComposante, 1),
                new ClasseAptitudes(NAptitude.PortArmeMagique, 3),
                new ClasseAptitudes(NAptitude.Necromancie, 3),
                new ClasseAptitudes(NAptitude.PortArmure, 4),
                new ClasseAptitudes(NAptitude.PortArme, 4),
                new ClasseAptitudes(NAptitude.PortBouclier, 3)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.DispenseComposante, 1),
                new ClasseAptitudes(NAptitude.PortArmeMagique, 3),
                new ClasseAptitudes(NAptitude.Necromancie, 4),
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
