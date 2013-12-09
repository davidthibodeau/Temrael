using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "un corps de lumiere" )]
	public class WispBete : BaseCreature
	{
        //public override int TrackingDifficulty { get { return 70; } }

		[Constructable]
		public WispBete() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "une lumiere";
			Body = 58;
			BaseSoundID = 1136;

			SetStr( 90, 105 );
			SetDex( 85, 95 );
			SetInt( 100, 130 );

			SetHits( 45, 55 );

			SetDamage( 7, 9 );

			//SetSkill(SkillName.EvalInt, 70.1, 80.5);
            SetSkill(SkillName.ArtMagique, 50.0, 70.5);
            //SetSkill(SkillName.MagicResist, 20.1, 30.0);
            SetSkill(SkillName.Tactiques, 25.1, 32.0);
            SetSkill(SkillName.ArmePoing, 15.1, 18.0);
			//SetSkill(SkillName.Anatomy, 9.1, 12.0);

            VirtualArmor = 6;
		}

	public override int GetDeathSound()
		{
			return 1134;
		}

		public override void GenerateLoot()
        {
            //AddLoot(LootPack.Foods, Utility.RandomMinMax(2, 3));
            //AddLoot(LootPack.Others, Utility.RandomMinMax(2, 3));
            //AddLoot(LootPack.NormalReagents, Utility.RandomMinMax(8, 12));
            AddLoot(LootPack.LowScrolls, Utility.RandomMinMax(1, 2));

            PackGold(90, 110);
        }

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public WispBete( Serial serial ) : base( serial )
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