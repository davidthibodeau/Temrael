using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
    [CorpseName("Scorpion")]
    public class SmallScorpion : BaseCreature
    {
        [Constructable]
        public SmallScorpion()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Scorpion";
            Body = 96;
            BaseSoundID = 397;

            SetStr(30, 40);
            SetDex(75, 105);
            SetInt(15, 30);

            SetHits(30, 60);
            SetMana(0);

            SetDamage(5, 10);

            SetDamageType(ResistanceType.Physical, 60);
            SetDamageType(ResistanceType.Perforant, 40);

            SetResistance(ResistanceType.Physical, 20, 25);
            SetResistance(ResistanceType.Contondant, 10, 15);
            SetResistance(ResistanceType.Tranchant, 20, 25);
            SetResistance(ResistanceType.Perforant, 40, 50);
            SetResistance(ResistanceType.Magie, 0, 5);

            SetSkill(SkillName.Empoisonnement, 80.0, 100.0);
            //SetSkill(SkillName.Concentration, 30.1, 35.0);
            SetSkill(SkillName.Tactiques, 20.0, 40.0);
            SetSkill(SkillName.Anatomie, 10.0, 30.0);

            Fame = 150;
            Karma = 0;

            VirtualArmor = 0;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 0.0;

            PackItem(new Nightshade());
        }

        public override double AttackSpeed { get { return 4.0; } }
        public override int Meat { get { return 1; } }
        public override FoodType FavoriteFood { get { return FoodType.Meat; } }
        public override PackInstinct PackInstinct { get { return PackInstinct.Canine; } }
        public override Poison PoisonImmune { get { return Poison.Greater; } }
        public override Poison HitPoison { get { return Poison.Lesser; } }
        public override int Bones { get { return 1; } }
        public override int Hides { get { return 1; } }
        public override HideType HideType { get { return HideType.Desertique; } }
        public override BoneType BoneType { get { return BoneType.Desertique; } }

        public SmallScorpion(Serial serial)
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