using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Mobiles.Monsters
{
    public class TestMonstre : BaseCreature
    {		
        [Constructable]
		public TestMonstre() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Guerrier Ophidien";
			Body = 86;
			BaseSoundID = 634;

			SetStr( 150, 320 );
			SetDex( 94, 190 );
			SetInt( 64, 160 );

			SetHits( 200, 400 );
			SetMana( 0 );

			SetDamage( 5, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			SetSkill( SkillName.Concentration, 70.1, 85.0 );
			SetSkill( SkillName.Epee, 60.1, 85.0 );
			SetSkill( SkillName.Tactiques, 75.1, 90.0 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
    	}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override int Meat{ get{ return 1; } }
        public override int Bones { get { return 6; } }
        public override int Hides { get { return 4; } }
        public override HideType HideType { get { return HideType.Ophidien; } }
        public override BoneType BoneType { get { return BoneType.Ophidien; } }

		public TestMonstre( Serial serial ) : base( serial )
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
