using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a water elemental corpse" )]
	public class SummonedWaterElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 80; } }
		public override double DispelFocus{ get{ return 60.0; } }
        public override bool DeleteCorpseOnDeath { get { return true; } }

		[Constructable]
		public SummonedWaterElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Name = "un elemental d'eau";
            Body = 16;
            BaseSoundID = 278;

            SetStr(126, 155);
            SetDex(166, 185);
            SetInt(301, 325);

            SetHits(400, 450);

            SetDamage(80, 90);

            //SetSkill(SkillName.EvalInt, 60.1, 75.0);
            //SetSkill(SkillName.Magery, 100.1, 115.0);
            //SetSkill(SkillName.MagicResist, 100.1, 115.0);
            SetSkill(SkillName.Tactiques, 50.1, 70.0);
            SetSkill(SkillName.ArmePoing, 50.1, 70.0);

            VirtualArmor = 60;
            ControlSlots = 6;
            CanSwim = true;
		}

		public SummonedWaterElemental( Serial serial ) : base( serial )
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