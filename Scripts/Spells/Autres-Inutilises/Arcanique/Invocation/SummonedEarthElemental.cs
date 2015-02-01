using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an earth elemental corpse" )]
	public class SummonedEarthElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 40; } }
		public override double DispelFocus{ get{ return 20.0; } }
        public override bool DeleteCorpseOnDeath { get { return true; } }

		[Constructable]
		public SummonedEarthElemental() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Name = "un elemental de terre";
            Body = 14;
            BaseSoundID = 268;

            SetStr(126, 155);
            SetDex(66, 85);
            SetInt(71, 92);

            SetHits(225, 250);

            SetDamage(50, 55);

            //SetSkill(SkillName.MagicResist, 50.1, 95.0);
            SetSkill(SkillName.Tactiques, 60.1, 100.0);
            SetSkill(SkillName.Anatomie, 60.1, 100.0);

            VirtualArmor = 34;
            ControlSlots = 2;
		}

		public SummonedEarthElemental( Serial serial ) : base( serial )
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