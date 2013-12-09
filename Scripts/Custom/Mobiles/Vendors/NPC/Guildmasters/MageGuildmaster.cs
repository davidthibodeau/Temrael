using System;
using System.Collections;
using Server;

namespace Server.Mobiles
{
	public class MageGuildmaster : BaseGuildmaster
	{
		public override NpcGuild NpcGuild{ get{ return NpcGuild.MagesGuild; } }

		[Constructable]
		public MageGuildmaster() : base( "mage" )
		{
			//SetSkill( SkillName.EvalInt, 85.0, 100.0 );
			SetSkill( SkillName.Inscription, 65.0, 88.0 );
			SetSkill( SkillName.Concentration, 64.0, 100.0 );
			SetSkill( SkillName.ArtMagique, 90.0, 100.0 );
			SetSkill( SkillName.ArmePoing, 60.0, 83.0 );
			//SetSkill( SkillName.Concentration, 85.0, 100.0 );
			SetSkill( SkillName.ArmeContondante, 36.0, 68.0 );
		}

		public override VendorShoeType ShoeType
		{
			get{ return Utility.RandomBool() ? VendorShoeType.Shoes : VendorShoeType.Sandals; }
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.Robe( Utility.RandomBlueHue() ) );
			AddItem( new Server.Items.GnarledStaff() );
		}

		public MageGuildmaster( Serial serial ) : base( serial )
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