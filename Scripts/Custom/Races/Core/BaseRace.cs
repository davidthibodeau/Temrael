using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server.Mobiles
{
	public abstract class BaseRace
    {
        #region Accessors
        public abstract string Name{get;}
		public abstract string NameF{get;}
        public abstract bool AllowHair { get;}
        public abstract bool AllowFacialHair { get;}

        public abstract int[] Hues { get;}

        //Bonus aux stats
		public abstract int Str{get;}
		public abstract int Dex{get;}
		public abstract int Int{get;}
        public abstract int Con{get;}
        public abstract int Cha{get;}

        public abstract AlignementA[] alignA { get; }
        public abstract AlignementB[] alignB { get; }

        public abstract string Description { get; }
        public abstract NAptitude Bonus { get; }
        public abstract int BonusNbr { get; }
        public abstract string BonusDescr { get; }
        public abstract int Image { get; }
        public abstract int Tooltip { get; }
        #endregion
    }
}