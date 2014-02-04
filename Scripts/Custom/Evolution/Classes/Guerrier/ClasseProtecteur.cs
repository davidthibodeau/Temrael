using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClasseProtecteur
    {
        private static ClasseType m_Classe = ClasseType.Protecteur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Guerrier;
        private static int m_Image = 332;
        private static int m_Tooltip = 0;
        private static string m_Name = "Protecteur";
        private static string m_Role = "À venir";
        private static AlignementB m_Alignement = AlignementB.Aucun;

        private static String[] m_Noms = new String[]
            {
                "Garde du Corps",
                "Devoue",
                "Gardien",
                "Protecteur"
            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 4),
                new ClasseAptitudes(NAptitude.PortArme, 2),
                new ClasseAptitudes(NAptitude.PortBouclier, 2),
                new ClasseAptitudes(NAptitude.Resistance, 1),
                new ClasseAptitudes(NAptitude.Robustesse, 1)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 5),
                new ClasseAptitudes(NAptitude.PortArme, 3),
                new ClasseAptitudes(NAptitude.PortBouclier, 4),
                new ClasseAptitudes(NAptitude.Resistance, 3),
                new ClasseAptitudes(NAptitude.Robustesse, 3)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 6),
                new ClasseAptitudes(NAptitude.PortArme, 3),
                new ClasseAptitudes(NAptitude.PortBouclier, 5),
                new ClasseAptitudes(NAptitude.Resistance, 4),
                new ClasseAptitudes(NAptitude.Robustesse, 4)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.PortArmure, 6),
                new ClasseAptitudes(NAptitude.PortArme, 4),
                new ClasseAptitudes(NAptitude.PortBouclier, 6),
                new ClasseAptitudes(NAptitude.Resistance, 6),
                new ClasseAptitudes(NAptitude.Robustesse, 6)
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
