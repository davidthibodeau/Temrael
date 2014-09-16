using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class BaseClasse
    {
        private static ClasseType m_Classe = ClasseType.None;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Aucun;
        private static int m_Image = 0;
        private static int m_Tooltip = 0;
        private static string m_Name = "Aucune";
        private static string m_Role = string.Empty;
 
        private static String[] m_Noms = new String[]
            {
                "",
                "",
                "",
                ""
            };

        private static ClasseCompetences[] m_classeCompetences = new ClasseCompetences[]
            {
                //new ClasseCompetences(SkillName.Identification)
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
