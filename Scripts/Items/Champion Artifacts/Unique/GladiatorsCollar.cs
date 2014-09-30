using System;
using Server;

namespace Server.Items
{
	public class GladiatorsCollar : PlateGorget
	{
		public override int LabelNumber{ get{ return 1094917; } } // Gladiator's Collar [Replica]

		public override double BasePhysicalResistance{ get{ return 18; } }
		public override double BaseMagieResistance{ get{ return 16; } }

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public GladiatorsCollar()
		{
			Hue = 0x26d;

			Attributes.BonusHits = 10;
			Attributes.AttackChance = 10;

			ArmorAttributes.MageArmor = 1;
		}

		public GladiatorsCollar( Serial serial ) : base( serial )
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
