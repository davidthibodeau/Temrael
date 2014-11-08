using System;
using Server;

namespace Server.Items
{
	interface IDurability
	{
		int InitMinHits { get; }
		int InitMaxHits { get; }

		int Durability { get; set; }
		int MaxDurability { get; set; }

		void ScaleDurability();
		void UnscaleDurability();
	}

	interface IWearableDurability : IDurability
	{
		int OnHit( BaseWeapon weapon, int damageTaken );
	}
}