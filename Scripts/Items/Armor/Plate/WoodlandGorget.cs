using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x2B69, 0x3160 )]
	public class WoodlandGorget : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseContondantResistance{ get{ return 3; } }
		public override int BaseTranchantResistance{ get{ return 2; } }
		public override int BasePerforantResistance{ get{ return 3; } }
		public override int BaseMagieResistance{ get{ return 2; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 65; } }

		public override int AosStrReq{ get{ return 45; } }
		public override int OldStrReq{ get{ return 45; } }

		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public WoodlandGorget() : base( 0x2B69 )
		{
		}

		public WoodlandGorget( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			if( version == 0 )
				Weight = -1;
		}
	}
}