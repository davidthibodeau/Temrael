using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("un corps de cheval")]
    public class SummonedHorse : BaseMount
    {
        public override double DispelDifficulty { get { return 80.0; } }
        public override double DispelFocus { get { return 30.0; } }

        private static int[] m_IDs = new int[]
			{
				0xC8, 0x3E9F,
				0xE2, 0x3EA0,
				0xE4, 0x3EA1,
				0xCC, 0x3EA2
			};

        [Constructable]
        public SummonedHorse() : base("un cheval", 0xE2, 0x3EA0, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            int random = Utility.Random(4);

            Body = m_IDs[random * 2];
            ItemID = m_IDs[random * 2 + 1];
            BaseSoundID = 0xA8;

            SetStr(46, 49);
            SetDex(41, 45);
            SetInt(52, 54);

            SetHits(66, 70);
            SetMana(0);

            SetDamage(12, 17);

            //SetSkill(SkillName.MagicResist, 6.0, 8.0);
            SetSkill(SkillName.ArmePoing, 41.0, 45.0);
            SetSkill(SkillName.Tactiques, 41.0, 45.0);

            VirtualArmor = 16;

            ControlSlots = 2;
        }

        public SummonedHorse(Serial serial) : base(serial)
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