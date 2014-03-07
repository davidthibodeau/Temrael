using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server.Mobiles
{
    public class RaceOrcish : BaseRace
    {
        #region Apparence
        public override bool AllowHair { get { return true; } }
        public override bool AllowFacialHair { get { return true; } }

        private static int[] m_Hues = new int[]
            {
                1446,
                2207,
                1437
            };

        public override int[] Hues { get { return m_Hues; } }
        public override string Name { get { return "Orcish"; } }
        public override string NameF { get { return "Orcish"; } }
        #endregion

        #region Alignement
        public override AlignementA[] alignA
        {
            get { return new AlignementA[] { AlignementA.Chaotique }; }
        }
        public override AlignementB[] alignB
        {
            get { return new AlignementB[] { AlignementB.Aucun }; }
        }
        #endregion

        #region Caract
        public override int Str { get { return 100; } }
        public override int Con { get { return 100; } }
        public override int Dex { get { return 80; } }
        public override int Cha { get { return 70; } }
        public override int Int { get { return 70; } }
        #endregion

        #region Gump
        public override int Image { get { return 434; } }
        public override int Tooltip { get { return 3006427; } }
        public override string Description { get { return "Vous êtes né dans l'oppression. Vos pairs vous ont comptés l'histoire du grand esclavage de votre peuple. Plus jamais. Il y a déjà plusieurs décennies que votre peuple n'est plus en chaînes et c'est regroupé en plusieurs clans, toujours séparés et gouvernés par différents chefs. Depuis ce temps, vous avez été élevé à inspirer la peur chez les autres races du royaume et de les intimider à la soumission. C'est ainsi que les bêtes féroces tel que vous parvenez à survivre dans un endroit aussi civilisé que le royaume de Temrael."; } }
        #endregion

        #region Bonus
        public override Aptitude Bonus { get { return Aptitude.Endurance; } }
        public override int BonusNbr { get { return 4; } }
        public override string BonusDescr { get { return "L'Orcish possede l'un des metabolismes les plus resistant du monde de Temrael. Ceci lui procure quelques points d'endurance."; } }
        #endregion

        #region Constructeur
        public RaceOrcish()
        {
        }
        #endregion
    }
}