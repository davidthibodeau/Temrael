using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a ghostly corpse" )]
	public class Wraith : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		[Constructable]
		public Wraith() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a wraith";
			Body = 100;
			//Hue = 0x4001;
			BaseSoundID = 0x482;

			SetStr( 76, 100 );
			SetDex( 76, 95 );
			SetInt( 36, 60 );

			SetHits( 400, 800 );

			SetDamage( 40, 80 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Tranchant, 50 );

            SetResistance(ResistanceType.Physical, 50, 70);
            SetResistance(ResistanceType.Contondant, 50, 70);
            SetResistance(ResistanceType.Tranchant, 50, 70);
            SetResistance(ResistanceType.Perforant, 50, 70);
            SetResistance(ResistanceType.Magie, 50, 70);

			//SetSkill( SkillName.EvalInt, 55.1, 70.0 );
			SetSkill( SkillName.ArtMagique, 55.1, 70.0 );
			SetSkill( SkillName.Concentration, 55.1, 70.0 );
			SetSkill( SkillName.Tactiques, 45.1, 60.0 );
			SetSkill( SkillName.Anatomie, 45.1, 55.0 );

			PackReg( 10 );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
		}
		
		public override bool BleedImmune{ get{ return true; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public Wraith( Serial serial ) : base( serial )
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