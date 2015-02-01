using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Furret")]
    public class Furret : BaseCreature
    {
        [Constructable]
        public Furret()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Furret";

            Body = 0xDC;
            BaseSoundID = 0xCB;

            VirtualArmor = Utility.RandomMinMax(0, 6);

            SetStr(10);
            SetDex(25, 35);
            SetInt(10);

            SetDamage(1);

            SetDamageType(ResistanceType.Physical, 100);

            SetSkill(SkillName.Anatomie, 4.2, 6.4);
            SetSkill(SkillName.Tactiques, 4.0, 6.0);
            SetSkill(SkillName.Concentration, 4.0, 5.0);

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 10.0;
        }

        public override double AttackSpeed { get { return 2.0; } }
        public override MeatType MeatType { get { return MeatType.Bird; } }
        public override int Meat { get { return 1; } }
        public override int Hides { get { return 1; } }
        public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

        public Furret(Serial serial)
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