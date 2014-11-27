using Server.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Mobiles.NewAnimals
{
    [CorpseName( "Cadavre d'araignee" )]
	public class Araignee : BaseCreature
	{
		[Constructable]
		public Araignee() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "Araignee";
			Body = 93;
			BaseSoundID = 0;

			SetStr( 5 );
			SetDex( 15 );
			SetInt( 5 );

			SetHits( 15 );
			SetMana( 0 );
			SetStam( 30 );

            SetArme(1, 4, 30);

			SetResistance( ResistanceType.Physical, 1, 5 );
			SetResistance( ResistanceType.Magie, 1, 5 );

			SetSkill( SkillName.Anatomie, 5 );
			SetSkill( SkillName.Tactiques, 5 );
			SetSkill( SkillName.Epee, 5 );

		}

        public override void GenerateLoot()
        {
            SpidersSilk SpidersSilk = new SpidersSilk(3);
        }

		public Araignee(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}
