using System;
using Server.Items;
using Server.Targeting;
using System.Collections;

namespace Server.Mobiles
{
    [CorpseName("a giant spider")]
    public class Spider : BaseCreature
    {
        [Constructable]
        public Spider()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Araignee";
            Body = 93;
            BaseSoundID = 0x388;

            SetStr(76, 100);
            SetDex(76, 95);
            SetInt(36, 60);

            SetHits(46, 60);
            SetMana(0);

            SetDamage(5, 13);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 15, 20);
            SetResistance(ResistanceType.Perforant, 25, 35);

            SetSkill(SkillName.Empoisonnement, 40.0, 80.0);
            //SetSkill(SkillName.Concentration, 25.1, 40.0);
            SetSkill(SkillName.Tactiques, 0.0, 20.0);
            SetSkill(SkillName.Anatomie, 10.0, 30.0);

            Fame = 150;
            Karma = 0;

            VirtualArmor = 16;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = -5.0;

            PackItem(new SpidersSilk(1));
        }

        public override double AttackSpeed { get { return 4.0; } }
        public override FoodType FavoriteFood { get { return FoodType.Meat; } }
        public override PackInstinct PackInstinct { get { return PackInstinct.Canine; } }
        public override Poison PoisonImmune { get { return Poison.Regular; } }
        public override Poison HitPoison { get { return Poison.Lesser; } }

        public Spider(Serial serial)
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