using System;
using System.Collections;
using Server;

namespace Server.Mobiles
{
	public class RangerGuildmaster : BaseGuildmaster
	{
		public override NpcGuild NpcGuild{ get{ return NpcGuild.RangersGuild; } }

		[Constructable]
		public RangerGuildmaster() : base( "ranger" )
		{
			//SetSkill( SkillName.AnimalLore, 64.0, 100.0 );
			SetSkill( SkillName.Survie, 75.0, 98.0 );
			SetSkill( SkillName.Discretion, 75.0, 98.0 );
			SetSkill( SkillName.Concentration, 75.0, 98.0 );
			SetSkill( SkillName.Tactiques, 65.0, 88.0 );
			SetSkill( SkillName.ArmeDistance, 90.0, 100.0 );
			SetSkill( SkillName.Poursuite, 90.0, 100.0 );
			SetSkill( SkillName.Infiltration, 60.0, 83.0 );
			SetSkill( SkillName.ArmePerforante, 36.0, 68.0 );
			SetSkill( SkillName.Elevage, 36.0, 68.0 );
			SetSkill( SkillName.ArmeTranchante, 45.0, 68.0 );
		}

		public RangerGuildmaster( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}