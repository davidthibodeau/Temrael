using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server.Mobiles
{
    public class RaceDrow : BaseRace
    {
        #region Apparence
        public override bool AllowHair { get { return true; } }
        public override bool AllowFacialHair { get { return true; } }

        private static int[] m_Hues = new int[]
            {
                2410,
                2412,
                1908
            };

        public override int[] Hues { get { return m_Hues; } }
        public override string Name { get { return "Elfe Noir"; } }
        public override string NameF { get { return "Elfe Noire"; } }

        #endregion

        #region Caract
        public override int Str { get { return 75; } }
        public override int Con { get { return 70; } }
        public override int Dex { get { return 100; } }
        public override int Cha { get { return 75; } }
        public override int Int { get { return 100; } }
        #endregion

        #region Gump
        public override int Image { get { return 178; } }
        public override int Tooltip { get { return 3006421; } }
        public override string Description { get { return "Vous avez vécu toute votre vie dans l'ombre et la noirceur. Le continent gauche ne vous effraie plus, il est votre terre. Vous partagez vos pas auprès de créatures tout aussi fourbes que vos personnes, et vous survivez avec magnificience. Mais contrairement à eux, vous êtes partie intégrante du Royaume de Temrael. Gouverné par un Roi humain, gouverné par la religion humaine, qu'en dites-vous ?"; } }
        #endregion

        #region Bonus
        public override Aptitude Bonus { get { return Aptitude.Resilience; } }
        public override int BonusNbr { get { return 4; } }
        public override string BonusDescr { get { return "Votre vie passe dans les cavernes du monde de Temrael vous permet de vous mouvoir plus longtemps et agilement."; } }
        #endregion

        #region Constructeur
        public RaceDrow()
        {
        }
        #endregion
    }
}