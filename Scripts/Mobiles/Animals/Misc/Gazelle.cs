using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("corps de gazelle")]
    public class Gazelle : BaseCreature
    {
        [Constructable]
        public Gazelle()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Gazelle";
            Body = 0xED;
            Hue = 2171;

            SetStr(21, 51);
            SetDex(47, 77);
            SetInt(17, 47);

            SetHits(15, 29);
            SetMana(0);

            SetDamage(4);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 5, 15);

            SetSkill(SkillName.Concentration, 15.0);
            SetSkill(SkillName.Tactiques, 19.0);
            SetSkill(SkillName.Anatomie, 26.0);

            VirtualArmor = 8;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 28.0;
        }

        public override double AttackSpeed { get { return 2.5; } }
        public override int Meat { get { return 3; } }
        public override int Hides { get { return 2; } }
        public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

        public Gazelle(Serial serial)
            : base(serial)
        {
        }

        public override int GetAttackSound()
        {
            return 0x82;
        }

        public override int GetHurtSound()
        {
            return 0x83;
        }

        public override int GetDeathSound()
        {
            return 0x84;
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