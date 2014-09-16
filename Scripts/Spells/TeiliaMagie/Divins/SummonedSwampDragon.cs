using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("un corps de dragon des marais")]
    public class SummonedDragonMarais : BaseMount
    {
        public override double DispelDifficulty { get { return 80.0; } }
        public override double DispelFocus { get { return 30.0; } }

        [Constructable]
        public SummonedDragonMarais() : base("un dragon des marais", 0x31A, 0x3EBD, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            BaseSoundID = 0x16A;

            SetStr(46, 49);
            SetDex(41, 45);
            SetInt(52, 54);

            SetHits(66, 70);
            SetMana(0);

            SetDamage(12, 17);

            //SetSkill(SkillName.MagicResist, 6.0, 8.0);
            SetSkill(SkillName.Anatomie, 41.0, 45.0);
            SetSkill(SkillName.Tactiques, 41.0, 45.0);

            VirtualArmor = 16;

            ControlSlots = 2;
        }

        public override int GetIdleSound()
        {
            return 0x2CE;
        }

        public override int GetDeathSound()
        {
            return 0x2CC;
        }

        public override int GetHurtSound()
        {
            return 0x2D1;
        }

        public override int GetAttackSound()
        {
            return 0x2C8;
        }

        public SummonedDragonMarais(Serial serial) : base(serial)
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