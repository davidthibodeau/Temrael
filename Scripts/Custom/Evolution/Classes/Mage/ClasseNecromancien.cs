using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClasseNecromancien
    {
        private static ClasseType m_Classe = ClasseType.Necromancien;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Magie;
        private static int m_Image = 286;
        private static int m_Tooltip = 0;
        private static string m_Name = "Necromancien";
        private static string m_Role = "À venir";
        private static AlignementB m_Alignement = AlignementB.Aucun;

        private static String[] m_Noms = new String[]
            {
                "Thanathauste",
                "Thanatologue",
                "Necromage",
                "Necromancien"
            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmeMagique, 1),
                new ClasseAptitudes(NAptitude.Necromancie, 3),
                new ClasseAptitudes(NAptitude.Adjuration, 2),
                new ClasseAptitudes(NAptitude.PortArmure, 1),
                new ClasseAptitudes(NAptitude.PortArme, 1)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmeMagique, 1),
                new ClasseAptitudes(NAptitude.Necromancie, 6),
                new ClasseAptitudes(NAptitude.Adjuration, 5),
                new ClasseAptitudes(NAptitude.PortArmure, 1),
                new ClasseAptitudes(NAptitude.PortArme, 1)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmeMagique, 1),
                new ClasseAptitudes(NAptitude.Necromancie, 9),
                new ClasseAptitudes(NAptitude.Adjuration, 8),
                new ClasseAptitudes(NAptitude.PortArmure, 2),
                new ClasseAptitudes(NAptitude.PortArme, 1)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmeMagique, 1),
                new ClasseAptitudes(NAptitude.Necromancie, 12),
                new ClasseAptitudes(NAptitude.Adjuration, 10),
                new ClasseAptitudes(NAptitude.PortArmure, 2),
                new ClasseAptitudes(NAptitude.PortArme, 1)
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
