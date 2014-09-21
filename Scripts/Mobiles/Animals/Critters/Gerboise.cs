using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("corps de gerboise")]
    public class Gerboise : BaseCreature
    {
        [Constructable]
        public Gerboise()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Gerboise";
            Body = 238;
            BaseSoundID = 0xCC;
            Hue = 2357;

            SetStr(9);
            SetDex(35);
            SetInt(5);

            SetHits(6);
            SetMana(0);

            SetDamage(1, 2);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 5, 10);

            SetSkill(SkillName.Concentration, 4.0);
            SetSkill(SkillName.Tactiques, 4.0);
            SetSkill(SkillName.Anatomie, 4.0);

            VirtualArmor = 6;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 0.0;
        }

        public override void GenerateLoot()
        {
        }

        public override double AttackSpeed { get { return 2.0; } }
        public override int Meat { get { return 1; } }
        public override FoodType FavoriteFood { get { return FoodType.Meat | FoodType.Fish | FoodType.Eggs | FoodType.GrainsAndHay; } }

        public Gerboise(Serial serial)
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