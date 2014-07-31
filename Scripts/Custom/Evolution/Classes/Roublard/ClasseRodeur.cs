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

        private static String[] m_Noms = new String[]
            {
                "Forestier",
                "Pisteur",
                "Eclaireur",
                "Rodeur"
            };

        private static ClasseCompetences[] m_classeCompetences = new ClasseCompetences[]
            {

            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 2),
                new ClasseAptitudes(Aptitude.PortBouclier, 1),
                new ClasseAptitudes(Aptitude.PortArme, 2),
                new ClasseAptitudes(Aptitude.PortArmeDistance, 2),
                new ClasseAptitudes(Aptitude.LibreDeplacement, 2),
                new ClasseAptitudes(Aptitude.Depistage, 1),
                new ClasseAptitudes(Aptitude.Resilience, 1),
                new ClasseAptitudes(Aptitude.Familier, 1)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 2),
                new ClasseAptitudes(Aptitude.PortBouclier, 1),
                new ClasseAptitudes(Aptitude.PortArme, 3),
                new ClasseAptitudes(Aptitude.PortArmeDistance, 3),
                new ClasseAptitudes(Aptitude.LibreDeplacement, 5),
                new ClasseAptitudes(Aptitude.Depistage, 2),
                new ClasseAptitudes(Aptitude.Resilience, 2),
                new ClasseAptitudes(Aptitude.Familier, 3)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 2),
                new ClasseAptitudes(Aptitude.PortBouclier, 2),
                new ClasseAptitudes(Aptitude.PortArme, 3),
                new ClasseAptitudes(Aptitude.PortArmeDistance, 4),
                new ClasseAptitudes(Aptitude.LibreDeplacement, 7),
                new ClasseAptitudes(Aptitude.Depistage, 3),
                new ClasseAptitudes(Aptitude.Resilience, 3),
                new ClasseAptitudes(Aptitude.Familier, 4)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 3),
                new ClasseAptitudes(Aptitude.PortBouclier, 2),
                new ClasseAptitudes(Aptitude.PortArme, 4),
                new ClasseAptitudes(Aptitude.PortArmeDistance, 5),
                new ClasseAptitudes(Aptitude.LibreDeplacement, 10),
                new ClasseAptitudes(Aptitude.Depistage, 4),
                new ClasseAptitudes(Aptitude.Resilience, 4),
                new ClasseAptitudes(Aptitude.Familier, 6)
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
