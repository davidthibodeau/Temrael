using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "Cadavre de Grenouille" )]
	public class Grenouille : BaseCreature
	{
        [Constructable]
        public Grenouille()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Grenouille";
            Body = 94;
            BaseSoundID = 614;
            Hue = 1434;

            SetStr(5);
            SetDex(15);
            SetInt(5);

            SetHits(3);
            SetMana(0);

            SetArme(1, 3, 40);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.Concentration, 4.0);
            SetSkill(SkillName.Tactiques, 5.0);
            SetSkill(SkillName.Epee, 5.0);

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 5;
        }

		public Grenouille(Serial serial) : base(serial)
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