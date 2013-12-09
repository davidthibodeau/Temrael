using System;
using Server;
using Server.Items;

namespace Server.Engines.BulkOrders
{
	public enum BulkMaterialType
	{
		None,
        Fer,
        Cuivre,
        Bronze,
        Acier,
        Argent,
        Or,
        Mytheril,
        Luminium,
        Obscurium,
        Mystirium,
        Dominium,
        Eclarium,
        Venarium,
        Athenium,
        Umbrarium,
        Barbed,
        Horned,
        Spined
	}

	public enum BulkGenericType
	{
		Iron,
		Cloth,
		Leather
	}

	public class BGTClassifier
	{
		public static BulkGenericType Classify( BODType deedType, Type itemType )
		{
			if ( deedType == BODType.Tailor )
			{
				if ( itemType == null || itemType.IsSubclassOf( typeof( BaseArmor ) ) || itemType.IsSubclassOf( typeof( BaseShoes ) ) )
					return BulkGenericType.Leather;

				return BulkGenericType.Cloth;
			}

			return BulkGenericType.Iron;
		}
	}
}