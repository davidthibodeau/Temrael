using System;
using Server;

namespace Server.Items
{
	public class WoodenShield : BaseShield
	{
        public override int NiveauAttirail { get { return 0; } }

		public override int BasePhysicalResistance{ get{ return 0; } }
		public override int BaseContondantResistance{ get{ return 0; } }
		public override int BaseTranchantResistance{ get{ return 0; } }
		public override int BasePerforantResistance{ get{ return 0; } }
		public override int BaseMagieResistance{ get{ return 1; } }

		public override int InitMinHits{ get{ return 20; } }
		public override int InitMaxHits{ get{ return 25; } }

		public override int AosStrReq{ get{ return 20; } }

		public override int ArmorBase{ get{ return 8; } }

		[Constructable]
		public WoodenShield() : base( 0x1B7A )
		{
			Weight = 5.0;
		}

		public WoodenShield( Serial serial ) : base(serial)
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
