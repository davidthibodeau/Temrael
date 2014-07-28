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
 
        private static String[] m_Noms = new String[]
            {
                "Moine",
                "Pretre",
                "Clerc",
                "Archidiacre"
            };

        private static ClasseCompetences[] m_classeCompetences = new ClasseCompetences[]
            {

            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.DispenseComposante, 1),
                new ClasseAptitudes(Aptitude.Thaumaturgie, 3),
                new ClasseAptitudes(Aptitude.Incantation, 1),
                new ClasseAptitudes(Aptitude.Spiritisme, 2),
                new ClasseAptitudes(Aptitude.PortArmure, 1),
                new ClasseAptitudes(Aptitude.PortArme, 1)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.DispenseComposante, 1),
                new ClasseAptitudes(Aptitude.Thaumaturgie, 6),
                new ClasseAptitudes(Aptitude.Incantation, 2),
                new ClasseAptitudes(Aptitude.Spiritisme, 4),
                new ClasseAptitudes(Aptitude.PortArmure, 1),
                new ClasseAptitudes(Aptitude.PortArme, 2)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.DispenseComposante, 1),
                new ClasseAptitudes(Aptitude.PortArmeMagique, 1),
                new ClasseAptitudes(Aptitude.Thaumaturgie, 9),
                new ClasseAptitudes(Aptitude.Incantation, 3),
                new ClasseAptitudes(Aptitude.Spiritisme, 5),
                new ClasseAptitudes(Aptitude.PortArmure, 2),
                new ClasseAptitudes(Aptitude.PortArme, 2)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.DispenseComposante, 1),
                new ClasseAptitudes(Aptitude.PortArmeMagique, 1),
                new ClasseAptitudes(Aptitude.Thaumaturgie, 12),
                new ClasseAptitudes(Aptitude.Incantation, 4),
                new ClasseAptitudes(Aptitude.Spiritisme, 6),
                new ClasseAptitudes(Aptitude.PortArmure, 2),
                new ClasseAptitudes(Aptitude.PortArme, 2)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_classeCompetences,
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
