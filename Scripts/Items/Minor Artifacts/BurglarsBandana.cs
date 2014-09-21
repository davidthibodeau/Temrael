using System;
using Server;

namespace Server.Items
{
	public class BurglarsBandana : Bandana
	{
		public override int LabelNumber{ get{ return 1063473; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public BurglarsBandana()
		{
			Hue = Utility.RandomBool() ? 0x58C : 0x10;

			SkillBonuses.SetValues( 0, SkillName.Vol, 10.0 );
			SkillBonuses.SetValues( 1, SkillName.Infiltration, 10.0 );
			SkillBonuses.SetValues( 2, SkillName.Fouille, 10.0 );

			Attributes.BonusDex = 5;
		}

		public BurglarsBandana( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
            base.Serialize(writer);

            writer.Write((int)0);
		}
		
		public override void Deserialize(GenericReader reader)
		{
            base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}