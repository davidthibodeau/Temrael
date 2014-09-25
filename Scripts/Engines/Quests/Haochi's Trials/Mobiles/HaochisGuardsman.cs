using System;
using Server;
using Server.Mobiles;
using Server.Gumps;
using Server.Items;

namespace Server.Engines.Quests.Samurai
{
	public class HaochisGuardsman : BaseQuester
	{
		[Constructable]
		public HaochisGuardsman() : base( "the Guardsman of Daimyo Haochi" )
		{
		}

		public override void InitBody()
		{
			InitStats( 100, 100, 25 );

			Female = false;
			Body = 0x190;
			Name = NameList.RandomName( "male" );
		}

		public override void InitOutfit()
		{
			Utility.AssignRandomHair( this );
		}

		public override int TalkNumber{ get	{ return -1; } }

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
		}

		public HaochisGuardsman( Serial serial ) : base( serial )
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