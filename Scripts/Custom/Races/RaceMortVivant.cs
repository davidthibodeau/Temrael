using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server.Mobiles
{
    public class RaceMortVivant : BaseRace
    {
        #region Apparence
        public override bool AllowHair { get { return true; } }
        public override bool AllowFacialHair { get { return true; } }

        private static int[] m_Hues = new int[]
            {
                1023,
                1002,
                1013
            };

        public override int[] Hues { get { return m_Hues; } }
        public override string Name { get { return "Mort-Vivant"; } }
        public override string NameF { get { return "Mort-Vivante"; } }
        #endregion

        #region Alignement
        public override AlignementA[] alignA
        {
            get { return new AlignementA[] { AlignementA.Aucun }; }
        }
        public override AlignementB[] alignB
        {
            get { return new AlignementB[] { AlignementB.Aucun }; }
        }
        #endregion

        #region Caract
        public override int Str { get { return 80; } }
        public override int Con { get { return 80; } }
        public override int Dex { get { return 80; } }
        public override int Cha { get { return 100; } }
        public override int Int { get { return 80; } }
        #endregion

        #region Gump
        public override int Image { get { return 342; } }
        public override int Tooltip { get { return 3006423; } }
        public override string Description { get { return "Vous êtes partout. Après quelques siècles de guerres et conquêtes, vous voilà les maîtres du monde. Ou presque. Certains obstacles se dressent toujours sur la route de l'humanité et il sera votre devoir en tant que citoyen du royaume de Temrael de les décimer. La route de la conquête fut longue et difficile et il est parfois aisé pour certains d'entres vous de regarder les autres peuples de haut. Par contre, certains d'entre vous adoptent une idée plus libertine. Une idée nouvelle de cohabitation avec les autres peuples soumis au royaume."; } }
        #endregion

        #region Bonus
        public override Aptitude Bonus { get { return Aptitude.PointSup; } }
        public override int BonusNbr { get { return 1; } }
        public override string BonusDescr { get { return ""; } }
        #endregion

        #region Constructeur
        public RaceMortVivant()
        {
        }
        #endregion
    }
}