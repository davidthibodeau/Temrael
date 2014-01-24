using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Grenouille")]
    [TypeAlias("Server.Mobiles.Frog")]
    public class Frog : BaseCreature
    {
        [Constructable]
        public Frog()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Grenouille";
            Body = 94;
            Hue = Utility.RandomList(0x5AC, 0x5A3, 0x59A, 0x591, 0x588, 0x57F);
            BaseSoundID = 0x266;

            SetStr(5, 10);
            SetDex(30, 60);
            SetInt(5, 10);

            SetHits(20, 30);
            SetMana(0);

            SetDamage(1, 2);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 5, 10);

            //SetSkill(SkillName.Concentration, 25.1, 40.0);
            SetSkill(SkillName.Tactiques, 0.0, 10.0);
            SetSkill(SkillName.ArmePoing, 5.0, 20.0);

            Fame = 350;
            Karma = 0;

            VirtualArmor = 6;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 0.0;
        }

        /*public override void GenerateLoot()
        {
            AddLoot( LootPack.Poor );
        }*/

        public override double AttackSpeed { get { return 2.5; } }
        public override int Meat { get { return 1; } }
        public override FoodType FavoriteFood { get { return FoodType.Fish | FoodType.Meat; } }

        public Frog(Serial serial)
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