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
 
        private static String[] m_Noms = new String[]
            {
                "Thanathauste",
                "Thanatologue",
                "Necromage",
                "Necromancien"
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
