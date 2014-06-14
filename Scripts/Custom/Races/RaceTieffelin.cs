using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server.Mobiles
{
    public class RaceTieffelin : BaseRace
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
        public override string Name { get { return "Tieffelin"; } }
        public override string NameF { get { return "Tieffeline"; } }
        #endregion

        #region Caract
        public override int Str { get { return 75; } }
        public override int Con { get { return 70; } }
        public override int Dex { get { return 85; } }
        public override int Cha { get { return 90; } }
        public override int Int { get { return 100; } }
        #endregion

        #region Gump
        public override int Image { get { return 447; } }
        public override int Tooltip { get { return 3006426; } }
        public override string Description { get { return "Vous êtes nés là où personne n'a osé mettre les pieds. Là où, lorsque vous levez vos yeux vers le Nord, vous voyez, comme horizon, une large construction militaire d'où vous devinez milles yeux posés sur vous et les vôtres. Ils vous guettent. Ils vous veillent, ils vous craignent de cette crainte qui anime le cœur des Inquisiteurs. Il n'y a qu'une seule légende à propos de ces terres où vous habitez, légende effroyable qui peuple les nuits d'enfants et d'adultes. Cette légende, c'est vous."; } }
        #endregion

        #region Bonus
        public override Aptitude Bonus { get { return Aptitude.Deguisement; } }
        public override int BonusNbr { get { return 1; } }
        public override string BonusDescr { get { return "Le tieffelin est capable de se deguiser habilement. Ceci lui procure un point automatique de deguisement."; } }
        #endregion

        #region Constructeur
        public RaceTieffelin()
        {
        }
        #endregion
    }
}