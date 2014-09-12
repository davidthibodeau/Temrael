using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Gargouille" )]
	public class Gargoyle : BaseCreature
	{
		[Constructable]
		public Gargoyle() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Gargouille";
			Body = 4;
			BaseSoundID = 372;

			SetStr( 146, 175 );
			SetDex( 76, 95 );
			SetInt( 81, 105 );

			SetHits( 300, 600 );

			SetDamage( 15, 30 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

			//SetSkill( SkillName.EvalInt, 70.1, 85.0 );
			SetSkill( SkillName.ArtMagique, 70.1, 85.0 );
			SetSkill( SkillName.Concentration, 70.1, 85.0 );
			SetSkill( SkillName.Tactiques, 50.1, 70.0 );
			SetSkill( SkillName.Anatomie, 40.1, 80.0 );

            PackItem(new EclatDeVolcan(1));
		}

		public override void GenerateLoot()
		{
            AddLoot(LootPack.Average);
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
		//public override int TreasureMapLevel{ get{ return 1; } }
		public override int Meat{ get{ return 1; } }

		public Gargoyle( Serial serial ) : base( serial )
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