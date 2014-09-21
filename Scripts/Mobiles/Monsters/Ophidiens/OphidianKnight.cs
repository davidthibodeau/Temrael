using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an ophidian corpse" )]
	[TypeAlias( "Server.Mobiles.OphidianAvenger" )]
	public class OphidianKnight : BaseCreature
	{
		[Constructable]
		public OphidianKnight() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Chevalier Ophidien";
			Body = 86;
			BaseSoundID = 634;

			SetStr( 417, 595 );
			SetDex( 166, 175 );
			SetInt( 46, 70 );

			SetHits( 400, 800 );
			SetMana( 0 );

			SetDamage( 20, 40 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 20, 40);
            
            
            
            SetResistance(ResistanceType.Magie, 20, 40);

			SetSkill( SkillName.Empoisonnement, 60.1, 80.0 );
			SetSkill( SkillName.Concentration, 65.1, 80.0 );
			SetSkill( SkillName.Tactiques, 90.1, 100.0 );
			SetSkill( SkillName.Anatomie, 90.1, 100.0 );

			PackItem( new LesserPoisonPotion() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override int Meat{ get{ return 2; } }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }
        public override int Bones { get { return 9; } }
        public override int Hides { get { return 9; } }
        public override HideType HideType { get { return HideType.Ophidien; } }
        public override BoneType BoneType { get { return BoneType.Ophidien; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.TerathansAndOphidians; }
		}

		public OphidianKnight( Serial serial ) : base( serial )
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