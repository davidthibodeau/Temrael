using System;
using System.Collections;
using Server;

namespace Server.Mobiles
{
	public class WarriorGuildmaster : BaseGuildmaster
	{
		public override NpcGuild NpcGuild{ get{ return NpcGuild.WarriorsGuild; } }

		[Constructable]
		public WarriorGuildmaster() : base( "warrior" )
		{
			//SetSkill( SkillName.ArmsLore, 75.0, 98.0 );
			SetSkill( SkillName.Parer, 85.0, 100.0 );
			SetSkill( SkillName.Concentration, 60.0, 83.0 );
			SetSkill( SkillName.Tactiques, 85.0, 100.0 );
			SetSkill( SkillName.ArmeTranchante, 90.0, 100.0 );
			SetSkill( SkillName.ArmeContondante, 60.0, 83.0 );
			SetSkill( SkillName.ArmePerforante, 60.0, 83.0 );
		}

		public WarriorGuildmaster( Serial serial ) : base( serial )
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