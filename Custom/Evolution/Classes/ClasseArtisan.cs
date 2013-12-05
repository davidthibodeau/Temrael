using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server
{
    public class ClasseArtisan
    {
        private static ClasseType m_Classe = ClasseType.Artisan;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Artisan;
        private static int m_Image = 171;
        private static int m_Tooltip = 0;
        private static string m_Name = "Artisan";
        private static string m_Role = "À venir";
        private static AlignementB m_Alignement = AlignementB.Aucun;

        private static String[] m_Noms = new String[]
            {
                "Apprenti",
                "Compagnon",
                "Artisan",
                "Maitre Artisan"
            };

        private static ClasseAptitudes[] m_firstApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.Commerce, 1),

                new ClasseAptitudes(NAptitude.Polissage, 2),
                new ClasseAptitudes(NAptitude.Fignolage, 2),

                new ClasseAptitudes(NAptitude.Broderie, 2),
                new ClasseAptitudes(NAptitude.Metallurgie, 2),
                new ClasseAptitudes(NAptitude.Ebenisterie, 2),
                new ClasseAptitudes(NAptitude.Invention, 2),

                new ClasseAptitudes(NAptitude.PortArme, 1),
                new ClasseAptitudes(NAptitude.PortArmure, 1)
            };

        private static ClasseAptitudes[] m_secondApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.Commerce, 1),

                new ClasseAptitudes(NAptitude.Polissage, 4),
                new ClasseAptitudes(NAptitude.Fignolage, 4),

                new ClasseAptitudes(NAptitude.Broderie, 3),
                new ClasseAptitudes(NAptitude.Metallurgie, 3),
                new ClasseAptitudes(NAptitude.Ebenisterie, 3),
                new ClasseAptitudes(NAptitude.Invention, 3),

                new ClasseAptitudes(NAptitude.PortArme, 1),
                new ClasseAptitudes(NAptitude.PortArmure, 1)
            };

        private static ClasseAptitudes[] m_thirdApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.Commerce, 1),

                new ClasseAptitudes(NAptitude.Polissage, 6),
                new ClasseAptitudes(NAptitude.Fignolage, 6),

                new ClasseAptitudes(NAptitude.Broderie, 4),
                new ClasseAptitudes(NAptitude.Metallurgie, 4),
                new ClasseAptitudes(NAptitude.Ebenisterie, 4),
                new ClasseAptitudes(NAptitude.Invention, 4),

                new ClasseAptitudes(NAptitude.PortArme, 1),
                new ClasseAptitudes(NAptitude.PortArmure, 1)
            };

        private static ClasseAptitudes[] m_fourthApt = new ClasseAptitudes[]
            {
                new ClasseAptitudes(NAptitude.Commerce, 1),

                new ClasseAptitudes(NAptitude.Polissage, 8),
                new ClasseAptitudes(NAptitude.Fignolage, 8),

                new ClasseAptitudes(NAptitude.Broderie, 5),
                new ClasseAptitudes(NAptitude.Metallurgie, 5),
                new ClasseAptitudes(NAptitude.Ebenisterie, 5),
                new ClasseAptitudes(NAptitude.Invention, 5),

                new ClasseAptitudes(NAptitude.PortArme, 1),
                new ClasseAptitudes(NAptitude.PortArmure, 2)
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
                m_Tooltip,
                m_Alignement
            );
    }
}
