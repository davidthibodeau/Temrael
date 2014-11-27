using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre d'aligator")]
    public class Aligator : BaseCreature
    {
        [Constructable]
        public Aligator()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.3)
        {
            Name = "Aligator";
            Body = 202;
            BaseSoundID = 0X295;
            Hue = 0;

            SetStr(90);
            SetDex(90);
            SetInt(5);

            SetHits(260);
            SetMana(180);
            SetStam(10);

            SetArme(14, 18, 40);

            SetResistance(ResistanceType.Physical, 1, 5);
            SetResistance(ResistanceType.Magie, 1, 5);

            SetSkill(SkillName.Detection, 60);
            SetSkill(SkillName.Tactiques, 60);
            SetSkill(SkillName.Epee, 60);
            SetSkill(SkillName.Anatomie, 40);
            SetSkill(SkillName.Penetration, 30);
            SetSkill(SkillName.CoupCritique, 30);

            Tamable = true;
            ControlSlots = 5;
            MinTameSkill = 100;

        }

        public override int Meat { get { return 6; } }
        public override MeatType MeatType { get { return MeatType.Ribs; } }

        public override int Hides { get { return 2; } }
        public override HideType HideType { get { return HideType.Reptilien; } }


        public Aligator(Serial serial)
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