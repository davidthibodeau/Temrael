using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an air elemental corpse" )]
	public class SummonedAirElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 50; } }
		public override double DispelFocus{ get{ return 30.0; } }
        public override bool DeleteCorpseOnDeath { get { return true; } }

		[Constructable]
		public SummonedAirElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Name = "un elemental d'air";
            Body = 13;
            Hue = 0x4001;
            BaseSoundID = 655;

            SetStr(126, 155);
            SetDex(166, 185);
            SetInt(101, 125);

            SetHits(160, 180);

            SetDamage(60, 70);

            //SetSkill(SkillName.EvalInt, 60.1, 75.0);
            //SetSkill(SkillName.Magery, 60.1, 75.0);
            //SetSkill(SkillName.MagicResist, 60.1, 75.0);
            SetSkill(SkillName.Tactiques, 60.1, 80.0);
            SetSkill(SkillName.Anatomie, 60.1, 80.0);

            VirtualArmor = 40;
            ControlSlots = 3;
		}

		public SummonedAirElemental( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 263 )
				BaseSoundID = 655;
		}
	}
}