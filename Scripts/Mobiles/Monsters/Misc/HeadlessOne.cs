using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Sans-Tête" )]
	public class HeadlessOne : BaseCreature
	{
		[Constructable]
		public HeadlessOne() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Sans-tête";
			Body = 31;
			Hue = Utility.RandomSkinHue() & 0x7FFF;
			BaseSoundID = 0x39D;

			SetStr( 26, 50 );
			SetDex( 36, 55 );
			SetInt( 16, 30 );

			SetHits( 50, 125 );

			SetDamage( 5, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 0, 10);
            
            
            
            SetResistance(ResistanceType.Magie, 0, 10);

			SetSkill( SkillName.Concentration, 15.1, 20.0 );
			SetSkill( SkillName.Tactiques, 25.1, 40.0 );
			SetSkill( SkillName.Anatomie, 25.1, 40.0 );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
			// TODO: body parts
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.0; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }

		public HeadlessOne( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}