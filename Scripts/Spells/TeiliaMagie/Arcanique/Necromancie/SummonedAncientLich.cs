using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a lich corpse" )]
	public class SummonedAncientLich : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 100; } }
		public override double DispelFocus{ get{ return 80.0; } }
        public override bool DeleteCorpseOnDeath { get { return true; } }

		[Constructable]
		public SummonedAncientLich () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Name = "une liche ancestrale";
            Body = 78;
            BaseSoundID = 412;

            SetStr(216, 305);
            SetDex(96, 115);
            SetInt(200, 300);

            SetHits(300, 350);

            SetDamage(60, 70);

            SetSkill(SkillName.Goetie, 100.1, 110.0);
            SetSkill(SkillName.ArtMagique, 100.1, 110.0);
            SetSkill(SkillName.Concentration, 100.1, 101.0);
            SetSkill(SkillName.Empoisonnement, 100.1, 101.0);
            SetSkill(SkillName.Destruction, 105.2, 125.0);
            SetSkill(SkillName.Tactiques, 90.1, 100.0);
            SetSkill(SkillName.Anatomie, 75.1, 100.0);

            VirtualArmor = 81;

            ControlSlots = 5;
		}

        public SummonedAncientLich(Serial serial)
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