using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x2B76, 0x316D )]
	public class HideGorget : BaseArmor
	{

		public override int BasePhysicalResistance{ get{ return 3; } }
		public override int BaseContondantResistance{ get{ return 3; } }
		public override int BaseTranchantResistance{ get{ return 4; } }
		public override int BasePerforantResistance{ get{ return 3; } }
		public override int BaseMagieResistance{ get{ return 2; } }

		public override int InitMinHits{ get{ return 35; } }
		public override int InitMaxHits{ get{ return 45; } }

		public override int AosStrReq{ get{ return 15; } }
		public override int OldStrReq{ get{ return 15; } }

		public override int ArmorBase{ get{ return 15; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Studded; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

        public override ArmorMeditationAllowance DefMedAllowance { get { return ArmorMeditationAllowance.All; } }

		[Constructable]
		public HideGorget() : base( 0x2B76 )
		{
			Weight = 3.0;
		}

		public HideGorget( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( Weight == 2.0 )
				Weight = 1.0;
		}
	}
}