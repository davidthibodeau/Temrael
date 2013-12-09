using System;
using Server;

namespace Server.Items
{
	public class PoisonedGlasses : ElvenGlasses
	{
		public override int LabelNumber{ get{ return 1073376; } } //Poisoned Reading Glasses

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseContondantResistance{ get{ return 10; } }
		public override int BaseTranchantResistance{ get{ return 10; } }
		public override int BasePerforantResistance{ get{ return 30; } }
		public override int BaseMagieResistance{ get{ return 10; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public PoisonedGlasses()
		{
			Attributes.BonusStam = 3;
			Attributes.RegenStam = 4;
		}
		public PoisonedGlasses( Serial serial ) : base( serial )
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
