using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Corps de Cheval")]
    [TypeAlias("Server.Mobiles.BrownHorse", "Server.Mobiles.DirtyHorse", "Server.Mobiles.GrayHorse", "Server.Mobiles.TanHorse")]
    public class HorseScelle : BaseMount
    {
        private static int[] m_IDs = new int[]
			{
				255, 0x3E43,
				256, 0x3E44,
				257, 0x3E45,
				258, 0x3E46
			};

        [Constructable]
        public HorseScelle()
            : this("Cheval")
        {
        }

        [Constructable]
        public HorseScelle(string name)
            : base(name, 0xE2, 0x3EA0, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            int random = Utility.Random(4);

            Body = m_IDs[random * 2];
            ItemID = m_IDs[random * 2 + 1];
            BaseSoundID = 0xA8;

            SetStr(22, 98);
            SetDex(56, 75);
            SetInt(6, 10);

            SetHits(28, 45);
            SetMana(0);

            SetDamage(3, 4);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 15, 20);

            SetSkill(SkillName.Concentration, 25.1, 30.0);
            SetSkill(SkillName.Tactiques, 29.3, 44.0);
            SetSkill(SkillName.ArmePoing, 29.3, 44.0);

            Fame = 300;
            Karma = 300;

            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 40.0;
        }

        public override int Meat { get { return 3; } }
        public override int Hides { get { return 10; } }
        public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

        public HorseScelle(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}