using System;
using Server;

namespace Server.Items
{
	public class DivineCountenance : HornedTribalMask
	{
		public override int LabelNumber{ get{ return 1061289; } } // Divine Countenance

		public override int ArtifactRarity{ get{ return 11; } }

		public override int BasePhysicalResistance{ get{ return 8; } }
		public override int BaseContondantResistance{ get{ return 6; } }
		public override int BaseTranchantResistance{ get{ return 9; } }
		public override int BaseMagieResistance{ get{ return 25; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public DivineCountenance()
		{
			Hue = 0x482;

			Attributes.BonusInt = 8;
			Attributes.RegenMana = 2;
			Attributes.ReflectPhysical = 15;
			Attributes.LowerManaCost = 8;
		}

		public DivineCountenance( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					Resistances.Physical = 0;
					Resistances.Contondant = 0;
					Resistances.Tranchant = 0;
					Resistances.Perforant = 0;
					break;
				}
			}
		}
	}
}