using System;
using Server;

namespace Server.Items
{
	public class CaptainJohnsHat : TricorneHat
	{
		public override int LabelNumber{ get{ return 1094911; } } // Captain John's Hat [Replica]

		public override int BasePhysicalResistance{ get{ return 2; } }
		public override int BaseContondantResistance{ get{ return 6; } }
		public override int BaseTranchantResistance{ get{ return 9; } }
		public override int BasePerforantResistance{ get{ return 7; } }
		public override int BaseMagieResistance{ get{ return 23; } }

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public CaptainJohnsHat()
		{
			Hue = 0x455;

			Attributes.BonusDex = 8;
			Attributes.NightSight = 1;
			Attributes.AttackChance = 15;

			SkillBonuses.Skill_1_Name = SkillName.ArmeTranchante;
			SkillBonuses.Skill_1_Value = 20;
		}

		public CaptainJohnsHat( Serial serial ) : base( serial )
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
