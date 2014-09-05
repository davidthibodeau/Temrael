using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class SummonedDragon : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 90.0; } }
		public override double DispelFocus{ get{ return 60.0; } }
        public override bool DeleteCorpseOnDeath { get { return true; } }

		[Constructable]
		public SummonedDragon () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Esprit du dragon";
            Body = Utility.RandomList(60, 61);
            BaseSoundID = 362;
            Hue = 999999;

            SetStr(350, 375);
            SetDex(180, 195);
            SetInt(240, 255);

            SetHits(400, 600);
            SetMana(240, 260);

            SetDamage(70, 80);

            //SetSkill(SkillName.EvalInt, 100.1, 105.0);
            //SetSkill(SkillName.Magery, 98.1, 100.0);
            //SetSkill(SkillName.Anatomy, 62.1, 65.0);
            //SetSkill(SkillName.MagicResist, 101.5, 103.0);
            SetSkill(SkillName.Tactiques, 85.1, 90.0);
            SetSkill(SkillName.Anatomie, 85.1, 90.0);

            VirtualArmor = 71;

            RangeFight = 1;
            ControlSlots = 8;
		}

		public override Poison PoisonImmune{ get{ return Poison.Regular; } } // TODO: Immune to poison?

		public SummonedDragon( Serial serial ) : base( serial )
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