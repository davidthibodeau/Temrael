using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("corps de guepard")]
    public class Guepard : BaseCreature
    {
        [Constructable]
        public Guepard()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Guepard";
            Body = 0xD6;
            Hue = 0x863;
            BaseSoundID = 0x462;


            SetStr(61, 85);
            SetDex(86, 105);
            SetInt(26, 50);

            SetHits(37, 51);
            SetMana(0);

            SetDamage(4, 12);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 20, 25);
            SetResistance(ResistanceType.Contondant, 5, 10);
            SetResistance(ResistanceType.Tranchant, 10, 15);
            SetResistance(ResistanceType.Perforant, 5, 10);

            SetSkill(SkillName.Concentration, 15.1, 30.0);
            SetSkill(SkillName.Tactiques, 50.1, 65.0);
            SetSkill(SkillName.Anatomie, 50.1, 65.0);

            VirtualArmor = 16;

            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 55.0;
        }

        public override double AttackSpeed { get { return 2.5; } }
        public override int Meat { get { return 1; } }
        public override int Hides { get { return 6; } }
        public override HideType HideType { get { return HideType.Desertique; } }
        public override FoodType FavoriteFood { get { return FoodType.Meat | FoodType.Fish; } }
        public override PackInstinct PackInstinct { get { return PackInstinct.Feline; } }

        public Guepard(Serial serial)
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