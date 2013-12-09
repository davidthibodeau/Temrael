using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server.Mobiles
{
    public class RaceNomade : BaseRace
    {
        #region Apparence
        public override bool AllowHair { get { return true; } }
        public override bool AllowFacialHair { get { return true; } }

        private static int[] m_Hues = new int[]
            {
                1044,
                1142,
                1881
            };

        public override int[] Hues { get { return m_Hues; } }
        public override string Name { get { return "Nomade"; } }
        public override string NameF { get { return "Nomade"; } }
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
        public override int Str { get { return 75; } }
        public override int Con { get { return 75; } }
        public override int Dex { get { return 90; } }
        public override int Cha { get { return 90; } }
        public override int Int { get { return 90; } }
        #endregion

        #region Gump
        public override int Image { get { return 310; } }
        public override int Tooltip { get { return 3006424; } }
        public override string Description { get { return "Vous êtes nés dans les profondeurs d'un désert aride, et vous avez vécu où le vent vous apportait. Vous êtes de ces gens aux traditions riches et diversifiées, même au sein de votre propre peuple, offrant à chacun de vos clans un aspect unique particulier. Vos traditions ne sont racontés que par vous seuls, ou par les miettes que vous laissez de villes en villes. Vous êtes une source infatigable de cette liberté dont rêve les citadins qui peuplent vos voyages."; } }
        #endregion

        #region Bonus
        public override NAptitude Bonus { get { return NAptitude.LibreDeplacement; } }
        public override int BonusNbr { get { return 2; } }
        public override string BonusDescr { get { return "Vous avez surveccu les plus arides des deserts. L'habitude aux habitats rudes vous procure quelques points de libre deplacement."; } }
        #endregion

        #region Constructeur
        public RaceNomade()
        {
        }
        #endregion
    }
}