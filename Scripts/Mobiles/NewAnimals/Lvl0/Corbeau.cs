using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de corbeau")]
    public class Corbeau : BaseCreature
    {
        [Constructable]
        public Corbeau()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.3)
        {
            Name = "Un Corbeau";
            Body = 219;
            BaseSoundID = 203;

            SetStr(10);
            SetDex(35);
            SetInt(5);

            SetHits(15);
            SetMana(0);
            SetStam(70);

            SetArme(1, 5, 30);

            SetResistance(ResistanceType.Physical, 1, 5);
            SetResistance(ResistanceType.Magie, 1, 5);

            SetSkill(SkillName.Anatomie, 7);
            SetSkill(SkillName.Tactiques, 7);
            SetSkill(SkillName.Epee, 7);

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 7;
        }

        public override int Meat { get { return 1; } }
        public override MeatType MeatType { get { return MeatType.Bird; } }

        public override int Feathers { get { return 15; } }

        public Corbeau(Serial serial)
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