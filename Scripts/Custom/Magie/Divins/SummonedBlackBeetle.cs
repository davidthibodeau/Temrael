using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("un corps de scarabé")]
    public class SummonedBlackScarabee : BaseMount
    {
        public override double DispelDifficulty { get { return 80.0; } }
        public override double DispelFocus { get { return 30.0; } }

        [Constructable]
        public SummonedBlackScarabee() : base("un scarabe", 0x317, 0x3EBC, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            SetStr(46, 49);
            SetDex(41, 45);
            SetInt(52, 54);

            SetHits(66, 70);
            SetMana(0);

            SetDamage(12, 17);

            //SetSkill(SkillName.MagicResist, 6.0, 8.0);
            SetSkill(SkillName.Tactiques, 41.0, 45.0);
            SetSkill(SkillName.ArmePoing, 41.0, 45.0);

            VirtualArmor = 16;

            ControlSlots = 2;
        }

        public override int GetAngerSound()
        {
            return 0x21D;
        }

        public override int GetIdleSound()
        {
            return 0x21D;
        }

        public override int GetAttackSound()
        {
            return 0x162;
        }

        public override int GetHurtSound()
        {
            return 0x163;
        }

        public override int GetDeathSound()
        {
            return 0x21D;
        }

        public override FoodType FavoriteFood { get { return FoodType.Meat; } }

        public SummonedBlackScarabee(Serial serial) : base(serial)
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