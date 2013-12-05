using System;
using Server;

namespace Server.Items
{
	public class FoldedSteelGlasses : ElvenGlasses
	{
		public override int LabelNumber{ get{ return 1073380; } } //Folded Steel Reading Glasses

		public override int BasePhysicalResistance{ get{ return 20; } }
		public override int BaseContondantResistance{ get{ return 10; } }
		public override int BaseTranchantResistance{ get{ return 10; } }
		public override int BasePerforantResistance{ get{ return 10; } }
		public override int BaseMagieResistance{ get{ return 10; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public FoldedSteelGlasses()
		{
			Attributes.BonusStr = 8;
			Attributes.NightSight = 1;
			Attributes.DefendChance = 15;
		}
		public FoldedSteelGlasses( Serial serial ) : base( serial )
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
