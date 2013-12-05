using System;
using Server;

namespace Server.Items
{
	public class IronwoodCrown : RavenHelm
	{
		public override int LabelNumber{ get{ return 1072924; } } // Ironwood Crown

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseContondantResistance{ get{ return 6; } }
		public override int BaseTranchantResistance{ get{ return 7; } }
		public override int BasePerforantResistance{ get{ return 7; } }
		public override int BaseMagieResistance{ get{ return 10; } }

		[Constructable]
		public IronwoodCrown()
		{
			Hue = 0x1;

			ArmorAttributes.SelfRepair = 3;

			Attributes.BonusStr = 5;
			Attributes.BonusDex = 5;
			Attributes.BonusInt = 5;
		}

		public IronwoodCrown( Serial serial ) : base( serial )
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