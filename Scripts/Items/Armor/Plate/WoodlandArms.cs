using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x2B6C, 0x3163 )]
	public class WoodlandArms : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseContondantResistance{ get{ return 3; } }
		public override int BaseTranchantResistance{ get{ return 2; } }
		public override int BasePerforantResistance{ get{ return 3; } }
		public override int BaseMagieResistance{ get{ return 2; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 65; } }

		public override int AosStrReq{ get{ return 80; } }
		public override int OldStrReq{ get{ return 80; } }

		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }
		public override Race RequiredRace { get { return Race.Elf; } }

		[Constructable]
		public WoodlandArms() : base( 0x2B6C )
		{
			Weight = 5.0;
		}

		public WoodlandArms( Serial serial ) : base( serial )
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