using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a lich corpse" )]
	public class SummonedLich : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 90; } }
		public override double DispelFocus{ get{ return 70.0; } }
        public override bool DeleteCorpseOnDeath { get { return true; } }

		[Constructable]
		public SummonedLich () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Name = "une liche";
            Body = 24;
            BaseSoundID = 0x3E9;

            SetStr(200, 225);
            SetDex(190, 140);
            SetInt(220, 240);

            SetHits(200, 250);

            SetDamage(50, 55);

            SetSkill(SkillName.Necromancie, 83.1, 85.5);
            SetSkill(SkillName.ArtMagique, 83.0, 85.5);
            SetSkill(SkillName.Concentration, 73.1, 75.0);
            SetSkill(SkillName.Tactiques, 62.1, 64.0);
            SetSkill(SkillName.Anatomie, 62.1, 64.0);
            SetSkill(SkillName.Evocation, 45.1, 50.0);

            VirtualArmor = 71;

            ControlSlots = 4;
		}

		public SummonedLich( Serial serial ) : base( serial )
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