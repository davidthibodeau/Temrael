using System;
using Server;

namespace Server.Items
{
	public class ShroudOfDeciet : BoneChest
	{
		public override int LabelNumber{ get{ return 1094914; } } // Shroud of Deceit [Replica]

		public override int BasePhysicalResistance{ get{ return 11; } }
		public override int BaseContondantResistance{ get{ return 6; } }
		public override int BaseTranchantResistance{ get{ return 18; } }
		public override int BasePerforantResistance{ get{ return 15; } }
		public override int BaseMagieResistance{ get{ return 13; } }

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public ShroudOfDeciet()
		{
			Hue = 0x38F;

			Attributes.RegenHits = 3;

			ArmorAttributes.MageArmor = 1;

			SkillBonuses.Skill_1_Name = SkillName.Concentration;
			SkillBonuses.Skill_1_Value = 10;
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
