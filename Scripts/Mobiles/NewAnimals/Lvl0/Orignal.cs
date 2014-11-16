using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre d'orignal")]
    public class Orignal : BaseCreature
    {
        [Constructable]
        public Orignal()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.3)
        {
            Name = "Un Orignal";
            Body = 234;
            BaseSoundID = 0;

            SetStr(40);
            SetDex(15);
            SetInt(5);

            SetHits(80);
            SetMana(0);
            SetStam(30);

            SetArme(1, 5, 30);

            SetResistance(ResistanceType.Physical, 1, 5);
            SetResistance(ResistanceType.Magie, 1, 5);

            SetSkill(SkillName.Concentration, 4.0);
            SetSkill(SkillName.Tactiques, 7.0);
            SetSkill(SkillName.Epee, 7.0);

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 5;
        }

        public override int Meat { get { return 15; } }
        public override MeatType MeatType { get { return MeatType.Ribs; } }
        public override int Hides { get { return 3; } }
        public override HideType HideType { get { return HideType.Regular; } }

        public Orignal(Serial serial)
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