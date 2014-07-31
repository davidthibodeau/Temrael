using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClasseBarde
    {
        private static ClasseType m_Classe = ClasseType.Barde;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Roublard;
        private static int m_Image = 327;
        private static int m_Tooltip = 0;
        private static string m_Name = "Barde";
        private static string m_Role = "À venir";

        private static String[] m_Noms = new String[]
            {
                "Baladin",
                "Troubadour",
                "Barde",
                "Menestrel"
            };

        private static ClasseCompetences[] m_classeCompetences = new ClasseCompetences[]
            {

            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 1),
                new ClasseAptitudes(Aptitude.PortArme, 1),
                new ClasseAptitudes(Aptitude.PortArmeDistance, 2),
                new ClasseAptitudes(Aptitude.Esquive, 2),
                new ClasseAptitudes(Aptitude.Composition, 3)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 2),
                new ClasseAptitudes(Aptitude.PortArme, 2),
                new ClasseAptitudes(Aptitude.PortArmeDistance, 2),
                new ClasseAptitudes(Aptitude.Esquive, 4),
                new ClasseAptitudes(Aptitude.Composition, 6)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 2),
                new ClasseAptitudes(Aptitude.PortArme, 3),
                new ClasseAptitudes(Aptitude.PortArmeDistance, 3),
                new ClasseAptitudes(Aptitude.Esquive, 6),
                new ClasseAptitudes(Aptitude.Composition, 9)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 3),
                new ClasseAptitudes(Aptitude.PortArme, 3),
                new ClasseAptitudes(Aptitude.PortArmeDistance, 4),
                new ClasseAptitudes(Aptitude.Esquive, 8),
                new ClasseAptitudes(Aptitude.Composition, 12)
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
