using System;
using Server;

namespace Server.Items
{
	public class ShroudOfDeciet : BoneChest
	{
		public override int LabelNumber{ get{ return 1094914; } } // Shroud of Deceit [Replica]

		public override double BasePhysicalResistance{ get{ return 11; } }
		public override double BaseMagieResistance{ get{ return 13; } }

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		[Constructable]
		public ShroudOfDeciet()
		{
			Hue = 0x38F;

			Attributes.RegenHits = 3;
		}

		public ShroudOfDeciet( Serial serial ) : base( serial )
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
		}
	}
}
