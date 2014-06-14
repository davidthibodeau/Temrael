using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server.Mobiles
{
    public class RaceAasimar : BaseRace
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
        public override string Name { get { return "Aasimar"; } }
        public override string NameF { get { return "Aasimar"; } }
        #endregion

        #region Caract
        public override int Str { get { return 80; } }
        public override int Con { get { return 80; } }
        public override int Dex { get { return 80; } }
        public override int Cha { get { return 100; } }
        public override int Int { get { return 80; } }
        #endregion

        #region Gump
        public override int Image { get { return 428; } }
        public override int Tooltip { get { return 3006428; } }
        public override string Description{ get { return "Vous êtes descendants de ces terres où tout le monde souhaite mettre les pieds, ou l'âme. Là où, lorsque vous posez vos yeux d'argent ou d'or blanc sur les gens qui vous entoure, vous ne percevez qu'un délicat mélange de crainte et d'admiration. Ils vous observent, ils vous jugent et, dans votre dos peut-être, pour les moins futés d'entre eux, ils vous prient. Il y a des livres entiers sur vos ancêtres, ces mêmes livres qui animent la ferveur des prêtres du royaume."; } }
        #endregion

        #region Bonus
        public override Aptitude Bonus { get { return Aptitude.Spiritisme; } }
        public override int BonusNbr { get { return 1; } }
        public override string BonusDescr { get { return "Votre relation avec les dieux vous permet d'avoir un point bonus de spiritisme."; } }
        #endregion

        #region Constructeur
        public RaceAasimar()
        {
        }
        #endregion
    }
}