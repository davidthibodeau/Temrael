using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x2FC5, 0x317B )]
	public class LeafChest : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 2; } }
		public override int BaseContondantResistance{ get{ return 3; } }
		public override int BaseTranchantResistance{ get{ return 2; } }
		public override int BasePerforantResistance{ get{ return 4; } }
		public override int BaseMagieResistance{ get{ return 4; } }

		public override int InitMinHits{ get{ return 30; } }
		public override int InitMaxHits{ get{ return 40; } }

		public override int AosStrReq{ get{ return 20; } }
		public override int OldStrReq{ get{ return 20; } }

		public override int ArmorBase{ get{ return 13; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		[Constructable]
		public LeafChest() : base( 0x2FC5 )
		{
			Weight = 2.0;
		}

		public LeafChest( Serial serial ) : base( serial )
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