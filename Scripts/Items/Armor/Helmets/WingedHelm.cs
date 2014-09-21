using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x2B73, 0x316A )]
	public class WingedHelm : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseContondantResistance{ get{ return 1; } }
		public override int BaseTranchantResistance{ get{ return 2; } }
		public override int BasePerforantResistance{ get{ return 2; } }
		public override int BaseMagieResistance{ get{ return 5; } }

		public override int InitMinHits{ get{ return 45; } }
		public override int InitMaxHits{ get{ return 55; } }

		public override int AosStrReq{ get{ return 25; } }
		public override int OldStrReq{ get{ return 25; } }

		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public WingedHelm() : base( 0x2B73 )
		{
			Weight = 5.0;
		}

		public WingedHelm( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}