using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de renard")]
    public class Renard : BaseCreature
    {
        [Constructable]
        public Renard()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.3)
        {
            Name = "Un renard";
            Body = 291;
            BaseSoundID = 0;

            SetStr(5);
            SetDex(15);
            SetInt(5);

            SetHits(20);
            SetMana(0);

            SetArme(1, 5, 30);

            SetResistance(ResistanceType.Physical, 1, 5);
            SetResistance(ResistanceType.Magie, 1, 5);

            SetSkill(SkillName.Concentration, 4.0);
            SetSkill(SkillName.Tactiques, 5.0);
            SetSkill(SkillName.Anatomie, 5.0);

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 5;
        }

        public override int Meat { get { return 1; } }
        public override MeatType MeatType { get { return MeatType.Ribs; } }
        public override int Hides { get { return 1; } }
        public override HideType HideType { get { return HideType.Regular; } }

        public Renard(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}