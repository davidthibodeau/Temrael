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

        private static ClasseCompetences[] m_classeCompetences = new ClasseCompetences[]
            {

            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_classeCompetences,
                m_Name,
                m_Noms,
                m_Role,
                m_ClasseBranche,
                m_Image,
                m_Tooltip
             );
    }
}
