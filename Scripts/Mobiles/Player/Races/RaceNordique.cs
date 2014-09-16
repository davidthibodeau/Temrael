using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server.Mobiles
{
    public class RaceNordique : BaseRace
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
        public override string Name { get { return "Nordique"; } }
        public override string NameF { get { return "Nordique"; } }
        #endregion

        #region Caract
        public override int Str { get { return 90; } }
        public override int Con { get { return 90; } }
        public override int Dex { get { return 85; } }
        public override int Cha { get { return 75; } }
        public override int Int { get { return 80; } }
        #endregion

        #region Gump
        public override int Image { get { return 416; } }
        public override int Tooltip { get { return 3006420; } }
        public override string Description { get { return "Vous êtes nés, ou vous avez vécu dans les Terres Blanches, hostiles et glaciales où des créatures improbables rôdent au détour de chaque montagne. Les pires légendes courent sur ce pays de neige et de glaces, où seule la force permet de survivre, mais votre sang glacé fait de vous un héritier des anciens héros qui combattirent les démons, et apportèrent Paix et Prospérité au Nord."; } }
        #endregion

        #region Bonus
        public override Aptitude Bonus { get { return Aptitude.LibreDeplacement; } }
        public override int BonusNbr { get { return 2; } }
        public override string BonusDescr { get { return "Vous avez surveccu les plus rudes hivers du nord. L'habitude aux habitats rudes vous procure quelques points de libre deplacement."; } }
        #endregion

        #region Constructeur
        public RaceNordique()
        {
        }
        #endregion
    }
}