using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a daemon corpse" )]
	public class SummonedDaemon : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 100.0; } }
		public override double DispelFocus{ get{ return 70.0; } }
        public override bool DeleteCorpseOnDeath { get { return true; } }

		[Constructable]
		public SummonedDaemon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.3 )
		{
            Name = "un demon";
            Body = 10;//9
            BaseSoundID = 357;

            SetStr(300, 325);
            SetDex(160, 175);
            SetInt(240, 255);

            SetHits(600, 650);
            SetMana(440, 460);

            SetDamage(90, 100);

            SetSkill(SkillName.Goetie, 100.1, 105.0);
            SetSkill(SkillName.ArtMagique, 98.1, 100.0);
            SetSkill(SkillName.Concentration, 62.1, 65.0);
            SetSkill(SkillName.Tactiques, 85.1, 90.0);
            SetSkill(SkillName.Anatomie, 85.1, 90.0);

            VirtualArmor = 81;

            RangeFight = 2;
            ControlSlots = 15;
		}

		public override Poison PoisonImmune{ get{ return Poison.Regular; } } // TODO: Immune to poison?

		public SummonedDaemon( Serial serial ) : base( serial )
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