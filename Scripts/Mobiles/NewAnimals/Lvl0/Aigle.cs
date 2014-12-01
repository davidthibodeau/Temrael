using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre d'aigle")]
    public class Aigle : BaseCreature
    {
        [Constructable]
        public Aigle()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.3)
        {
            Name = "Un aigle";
            Body = 5;
            BaseSoundID = 750;

            SetStr(10);
            SetDex(35);
            SetInt(5);

            SetHits(50);
            SetMana(0);
            SetStam(70);

            SetArme(2, 6, 30);

            SetResistance(ResistanceType.Physical, 1, 5);
            SetResistance(ResistanceType.Magie, 1, 5);

            SetSkill(SkillName.Anatomie, 10);
            SetSkill(SkillName.Tactiques, 10);
            SetSkill(SkillName.Epee, 10);

            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 10;
        }

        public override int Meat { get { return 1; } }
        public override MeatType MeatType { get { return MeatType.Bird; } }

        public override int Feathers { get { return 6; } }

        public Aigle(Serial serial)
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