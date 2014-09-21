using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x2B71, 0x3168 )]
	public class RavenHelm : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseContondantResistance{ get{ return 1; } }
		public override int BaseTranchantResistance{ get{ return 2; } }
		public override int BasePerforantResistance{ get{ return 2; } }
		public override int BaseMagieResistance{ get{ return 5; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 65; } }

		public override int AosStrReq{ get{ return 25; } }
		public override int OldStrReq{ get{ return 25; } }

		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public RavenHelm() : base( 0x2B71 )
		{
			Weight = 5.0;
		}

		public RavenHelm( Serial serial ) : base( serial )
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