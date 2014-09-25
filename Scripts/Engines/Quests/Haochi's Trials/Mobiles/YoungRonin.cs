using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.Quests.Samurai
{
	[CorpseName( "a young ronin's corpse" )]
	public class YoungRonin : BaseCreature
	{
		[Constructable]
		public YoungRonin() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			InitStats( 45, 30, 5 );
			SetHits( 10, 20 );

			Hue = Utility.RandomSkinHue();
			Body = 0x190;
			Name = "a young ronin";

			Utility.AssignRandomHair( this );
			Utility.AssignRandomFacialHair( this );

			AddItem( new Bandana( Utility.RandomNondyedHue() ) );


			SetSkill( SkillName.ArmeTranchante, 50.0 );
			SetSkill( SkillName.Tactiques, 50.0 );
		}

		public override bool AlwaysMurderer{ get{ return true; } }

		public YoungRonin( Serial serial ) : base( serial )
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