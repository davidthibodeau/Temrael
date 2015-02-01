using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClasseEspion
    {
        private static ClasseType m_Classe = ClasseType.Espion;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Roublard;
        private static int m_Image = 185;
        private static int m_Tooltip = 0;
        private static string m_Name = "Espion";
        private static string m_Role = "À venir";

        private static String[] m_Noms = new String[]
            {
                "Charlatan",
                "Imposteur",
                "Espion",
                "Ombre"
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
