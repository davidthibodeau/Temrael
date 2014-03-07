using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server.Mobiles
{
    public class RaceElfe : BaseRace
    {
        #region Apparence
        public override bool AllowHair { get { return true; } }
        public override bool AllowFacialHair { get { return false; } }

        private static int[] m_Hues = new int[]
            {
                1023,
                1011,
                1002
            };

        public override int[] Hues { get { return m_Hues; } }
        public override string Name { get { return "Elfe"; } }
        public override string NameF { get { return "Elfe"; } }
        #endregion

        #region Alignement
        public override AlignementA[] alignA
        {
            get { return new AlignementA[] { AlignementA.Aucun }; }
        }
        public override AlignementB[] alignB
        {
            get { return new AlignementB[] { AlignementB.Bon, AlignementB.Neutre }; }
        }
        #endregion

        #region Caract
        public override int Str { get { return 70; } }
        public override int Con { get { return 60; } }
        public override int Dex { get { return 100; } }
        public override int Cha { get { return 100; } }
        public override int Int { get { return 90; } }
        #endregion

        #region Gump
        public override int Image { get { return 174; } }
        public override int Tooltip { get { return 3006422; } }
        public override string Description { get { return "Vous vivez dans les plus vastes et secrètes forêts de Temrael, blottis sous le couvert de votre divinité nature. Depuis toujours dévoué à leur protection, par tous les moyens nécessaires, vous êtes de ces ancêtres sans temps ni âge qui subjuguent le commun des mortels. Le plus grand nombre d'entre vous, malgré les siècles qui passent, ne verrons probablement jamais l'extérieur de leur boisé. Ils sont, et vous êtes, les racines du savoir de Temrael."; } }
        #endregion

        #region Bonus
        public override Aptitude Bonus { get { return Aptitude.Receptacle; } }
        public override int BonusNbr { get { return 4; } }
        public override string BonusDescr { get { return "La grande sagesse des elfes vous procure des points bonus de receptacle et ainsi plus de mana."; } }
        #endregion

        #region Constructeur
        public RaceElfe()
        {
        }
        #endregion
    }
}