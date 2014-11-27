using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Mobiles.NewAnimals
{
    [CorpseName( "Cadavre de taureau" )]
	public class Taureau : BaseCreature
	{
		[Constructable]
		public Taureau() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.3 )
		{
			Name = "Taureau";
			Body = 233;
			BaseSoundID = 0X065;

			SetStr( 50 );
			SetDex( 15 );
			SetInt( 5 );

			SetHits( 100 );
			SetMana( 0 );
			SetStam( 30 );

                        SetArme(1, 5, 30);

			SetResistance( ResistanceType.Physical, 1, 5 );
			SetResistance( ResistanceType.Magie, 1, 5 );

			SetSkill( SkillName.Concentration, 4.0 );
			SetSkill( SkillName.Tactiques, 10.0 );
			SetSkill( SkillName.Epee, 10.0 );

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 10;
		}

		public override int Meat{ get{ return 20; } }
		public override MeatType MeatType{ get{ return MeatType.Ribs; } }
                public override int Hides { get { return 2; } }
                public override HideType HideType { get { return HideType.Regular; } }

		public Taureau(Serial serial) : base(serial)
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
