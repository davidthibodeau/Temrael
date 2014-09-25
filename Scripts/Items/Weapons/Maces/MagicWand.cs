using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class MagicWand : BaseBashing
	{
		public override WeaponAbility PrimaryAbility { get { return WeaponAbility.Dismount; } }
		public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Disarm; } }

		public override int DefStrengthReq{ get{ return 5; } }
		public override int DefMinDamage{ get{ return 9; } }
		public override int DefMaxDamage{ get{ return 11; } }
		public override int DefSpeed{ get{ return 40; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 110; } }

		[Constructable]
		public MagicWand() : base( 0xDF2 )
		{
			Weight = 1.0;
		}

		public MagicWand( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}