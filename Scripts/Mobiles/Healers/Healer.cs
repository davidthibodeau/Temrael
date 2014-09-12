using System;
using Server;

namespace Server.Mobiles
{
	public class Healer : BaseHealer
	{
		public override bool CanTeach{ get{ return true; } }

		//public override bool CheckTeach( SkillName skill, Mobile from )
		//{
		//	if ( !base.CheckTeach( skill, from ) )
		//		return false;
        //
		//	return ( skill == SkillName.Forensics )
		//		|| ( skill == SkillName.Soins )
		//		|| ( skill == SkillName.SpiritSpeak )
		//		|| ( skill == SkillName.ArmeTranchante );
		//}

		[Constructable]
		public Healer()
		{
			Title = "the healer";

			if ( !Core.AOS )
				NameHue = 0x35;

			//SetSkill( SkillName.Forensics, 80.0, 100.0 );
			SetSkill( SkillName.Soins, 80.0, 100.0 );
			SetSkill( SkillName.ArmeTranchante, 80.0, 100.0 );
		}

		public override bool IsActiveVendor{ get{ return true; } }
		public override bool IsInvulnerable{ get{ return true; } }

		public override void InitSBInfo()
		{
			SBInfos.Add( new SBHealer() );
		}



		public Healer( Serial serial ) : base( serial )
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

			if ( Core.AOS && NameHue == 0x35 )
				NameHue = -1;
		}
	}
}