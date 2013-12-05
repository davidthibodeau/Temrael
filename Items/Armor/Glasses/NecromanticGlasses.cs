using System;
using Server;

namespace Server.Items
{
	public class NecromanticGlasses : ElvenGlasses
	{
		public override int LabelNumber{ get{ return 1073377; } } //Necromantic Reading Glasses

		public override int BasePhysicalResistance{ get{ return 0; } }
		public override int BaseContondantResistance{ get{ return 0; } }
		public override int BaseTranchantResistance{ get{ return 0; } }
		public override int BasePerforantResistance{ get{ return 0; } }
		public override int BaseMagieResistance{ get{ return 0; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public NecromanticGlasses()
		{
			Attributes.LowerManaCost = 15;
			Attributes.LowerRegCost = 30;
		}
		public NecromanticGlasses( Serial serial ) : base( serial )
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
