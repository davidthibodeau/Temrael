using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a crystal elemental corpse" )]
	public class SummonedCrystalElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 100; } }
		public override double DispelFocus{ get{ return 80.0; } }
        public override bool DeleteCorpseOnDeath { get { return true; } }

		[Constructable]
		public SummonedCrystalElemental () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Un elementaire de cristal";
            Body = 300;
            BaseSoundID = 278;
            Hue = 2052;

            SetStr(400, 425);
            SetDex(160, 175);
            SetInt(240, 255);

            SetHits(1000, 1250);

            SetDamage(40, 45);

            //SetSkill(SkillName.EvalInt, 90.1, 105.0);
            //SetSkill(SkillName.Magery, 90.1, 105.0);
            //SetSkill(SkillName.MagicResist, 100.1, 115.0);
            SetSkill(SkillName.Tactiques, 90.1, 100.0);
            SetSkill(SkillName.Anatomie, 90.1, 100.0);

            VirtualArmor = 140;
            ControlSlots = 12;
		}

        public SummonedCrystalElemental(Serial serial)
            : base(serial)
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