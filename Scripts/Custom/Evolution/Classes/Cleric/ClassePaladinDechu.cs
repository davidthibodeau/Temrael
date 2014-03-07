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
                new ClasseAptitudes(Aptitude.DispenseComposante, 1),
                new ClasseAptitudes(Aptitude.PortArmeMagique, 1),
                new ClasseAptitudes(Aptitude.Necromancie, 1),
                new ClasseAptitudes(Aptitude.PortArmure, 2),
                new ClasseAptitudes(Aptitude.PortArme, 2),
                new ClasseAptitudes(Aptitude.PortBouclier, 1)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.DispenseComposante, 1),
                new ClasseAptitudes(Aptitude.PortArmeMagique, 2),
                new ClasseAptitudes(Aptitude.Necromancie, 2),
                new ClasseAptitudes(Aptitude.PortArmure, 3),
                new ClasseAptitudes(Aptitude.PortArme, 3),
                new ClasseAptitudes(Aptitude.PortBouclier, 2)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.DispenseComposante, 1),
                new ClasseAptitudes(Aptitude.PortArmeMagique, 3),
                new ClasseAptitudes(Aptitude.Necromancie, 3),
                new ClasseAptitudes(Aptitude.PortArmure, 4),
                new ClasseAptitudes(Aptitude.PortArme, 4),
                new ClasseAptitudes(Aptitude.PortBouclier, 3)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.DispenseComposante, 1),
                new ClasseAptitudes(Aptitude.PortArmeMagique, 3),
                new ClasseAptitudes(Aptitude.Necromancie, 4),
                new ClasseAptitudes(Aptitude.PortArmure, 5),
                new ClasseAptitudes(Aptitude.PortArme, 5),
                new ClasseAptitudes(Aptitude.PortBouclier, 4)
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
