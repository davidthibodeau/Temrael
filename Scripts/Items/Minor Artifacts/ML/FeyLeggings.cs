using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class FeyLeggings : ChainLegs
	{
		public override int LabelNumber{ get{ return 1075041; } } // Fey Leggings

		public override double BasePhysicalResistance{ get{ return 12; } }
		public override double BaseMagieResistance{ get{ return 19; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get { return 255; } }


		[Constructable]
		public FeyLeggings()
		{
			Attributes.BonusHits = 6;
			Attributes.DefendChance = 20;

			ArmorAttributes.MageArmor = 1;
		}


		public FeyLeggings( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}