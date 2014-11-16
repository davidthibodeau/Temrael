using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de chien")]
    public class Chien : BaseCreature
    {
        [Constructable]
        public Chien()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Un chien";
            Body = 217;
            BaseSoundID = 133;

            SetStr(5);
            SetDex(15);
            SetInt(5);

            SetHits(15);
            SetMana(0);
            SetStam(30);

            SetArme(1, 5, 40);

            SetResistance(ResistanceType.Physical, 1, 5);
            SetResistance(ResistanceType.Magie, 1, 5);

            SetSkill(SkillName.Anatomie, 5);
            SetSkill(SkillName.Tactiques, 5);
            SetSkill(SkillName.Epee, 5);

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 5;
        }


        public Chien(Serial serial)
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