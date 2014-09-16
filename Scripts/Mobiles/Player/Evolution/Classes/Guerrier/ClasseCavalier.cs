using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClasseCavalier
    {
        private static ClasseType m_Classe = ClasseType.Cavalier;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Guerrier;
        private static int m_Image = 328;
        private static int m_Tooltip = 0;
        private static string m_Name = "Cavalier";
        private static string m_Role = "À venir";

        private static String[] m_Noms = new String[]
            {
                "Ecuyer",
                "Cavalier",
                "Jouteur",
                "Chevalier"
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
