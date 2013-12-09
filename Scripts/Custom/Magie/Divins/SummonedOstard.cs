using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("un corps d'ostard")]
    public class SummonedOstard : BaseMount
    {
        public override double DispelDifficulty { get { return 80.0; } }
        public override double DispelFocus { get { return 30.0; } }

        [Constructable]
        public SummonedOstard() : base("un ostard", 0xD2, 0x3EA3, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            BaseSoundID = 0x270;

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

        public SummonedOstard(Serial serial) : base(serial)
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