using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x2B6B, 0x3162 )]
	public class WoodlandLegs : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseContondantResistance{ get{ return 3; } }
		public override int BaseTranchantResistance{ get{ return 2; } }
		public override int BasePerforantResistance{ get{ return 3; } }
		public override int BaseMagieResistance{ get{ return 2; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 65; } }

		public override int AosStrReq{ get{ return 90; } }
		public override int OldStrReq{ get{ return 90; } }

		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }
		public override Race RequiredRace { get { return Race.Elf; } }

		[Constructable]
		public WoodlandLegs() : base( 0x2B6B )
		{
			Weight = 8.0;
		}

		public WoodlandLegs( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}