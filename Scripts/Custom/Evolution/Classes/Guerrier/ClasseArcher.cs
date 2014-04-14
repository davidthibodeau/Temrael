using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClasseArcher
    {
        private static ClasseType m_Classe = ClasseType.Archer;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Guerrier;
        private static int m_Image = 187;
        private static int m_Tooltip = 0;
        private static string m_Name = "Archer";
        private static string m_Role = "À venir";
 
        private static String[] m_Noms = new String[]
            {
                "Tireur",
                "Archer",
                "Tireur Émérite",
                "Maître Archer"
            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 1),
                new ClasseAptitudes(Aptitude.PortArme, 1),
                new ClasseAptitudes(Aptitude.PortArmeDistance, 3),
                new ClasseAptitudes(Aptitude.TirPrecis, 2),
                new ClasseAptitudes(Aptitude.CombatAuSol, 1)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 2),
                new ClasseAptitudes(Aptitude.PortArme, 1),
                new ClasseAptitudes(Aptitude.PortArmeDistance, 4),
                new ClasseAptitudes(Aptitude.TirPrecis, 4),
                new ClasseAptitudes(Aptitude.CombatAuSol, 3)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 2),
                new ClasseAptitudes(Aptitude.PortArme, 1),
                new ClasseAptitudes(Aptitude.PortArmeDistance, 5),
                new ClasseAptitudes(Aptitude.TirPrecis, 6),
                new ClasseAptitudes(Aptitude.CombatAuSol, 5)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(Aptitude.PortArmure, 3),
                new ClasseAptitudes(Aptitude.PortArme, 2),
                new ClasseAptitudes(Aptitude.PortArmeDistance, 6),
                new ClasseAptitudes(Aptitude.TirPrecis, 8),
                new ClasseAptitudes(Aptitude.CombatAuSol, 8)
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
