using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server.Mobiles
{
    public class RaceNain : BaseRace
    {
        #region Apparence
        public override bool AllowHair { get { return true; } }
        public override bool AllowFacialHair { get { return true; } }

        private static int[] m_Hues = new int[]
            {
                1054,
                1052,
                1057
            };

        public override int[] Hues { get { return m_Hues; } }
        public override string Name { get { return "Nain"; } }
        public override string NameF { get { return "Naine"; } }
        #endregion

        #region Caract
        public override int Str { get { return 90; } }
        public override int Con { get { return 90; } }
        public override int Dex { get { return 80; } }
        public override int Cha { get { return 70; } }
        public override int Int { get { return 90; } }
        #endregion

        #region Gump
        public override int Image { get { return 269; } }
        public override int Tooltip { get { return 3006425; } }
        public override string Description { get { return "Vous êtes du peuple des montagnes, du roc et des minéraux. Contrairement à ces grands pics vous n'êtes pas majestueux. Mais, tout comme ces grandes collines le peuple nain renferme lui aussi un secret. Depuis des siècles, la langue ancienne des nains ainsi que la technique de leurs forgerons demeurent un mystère aux autres peuples de Temrael. Malgré toute votre réserve, vous savez être jovial et un très bon compagnon de route lors d'aventures."; } }
        #endregion

        #region Bonus
        public override Aptitude Bonus { get { return Aptitude.Polissage; } }
        public override int BonusNbr { get { return 1; } }
        public override string BonusDescr { get { return "Votre tradition de voyageur et de maitres artisans vous procurent un point de polissage vous permettant de creer plus souvent des objets exceptionnels."; } }
        #endregion

        #region Constructeur
        public RaceNain()
        {
        }
        #endregion
    }
}