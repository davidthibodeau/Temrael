using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a fire elemental corpse" )]
	public class SummonedFireElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 60; } }
		public override double DispelFocus{ get{ return 50.0; } }
        public override bool DeleteCorpseOnDeath { get { return true; } }

		[Constructable]
		public SummonedFireElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Name = "un elemental de feu";
            Body = 15;
            BaseSoundID = 838;

            SetStr(126, 155);
            SetDex(166, 185);
            SetInt(101, 125);

            SetHits(300, 350);

            SetDamage(70, 80);

            //SetSkill(SkillName.EvalInt, 60.1, 75.0);
            //SetSkill(SkillName.Magery, 60.1, 75.0);
            //SetSkill(SkillName.MagicResist, 75.2, 105.0);
            SetSkill(SkillName.Tactiques, 80.1, 100.0);
            SetSkill(SkillName.ArmePoing, 70.1, 100.0);

            VirtualArmor = 40;
            ControlSlots = 4;

            AddItem(new LightSource());
		}

		public SummonedFireElemental( Serial serial ) : base( serial )
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
