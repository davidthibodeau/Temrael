using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
    [CorpseName("a skeletal")]
    public class SkeletonArcher : BaseCreature
    {
        [Constructable]
        public SkeletonArcher()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Squelette Archer";
            Body = 246;
            BaseSoundID = 0x48D;

            SetStr(56, 80);
            SetDex(56, 75);
            SetInt(16, 40);

            SetHits(100, 200);

            SetDamage(10, 15);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 0, 10);
            SetResistance(ResistanceType.Contondant, 0, 10);
            SetResistance(ResistanceType.Tranchant, 0, 10);
            SetResistance(ResistanceType.Perforant, 0, 10);
            SetResistance(ResistanceType.Magie, 0, 10);

            SetSkill(SkillName.Tactiques, 40.0, 60.0);
            SetSkill(SkillName.Anatomie, 40.0, 60.0);

            switch (Utility.Random(5))
            {
                case 0: PackItem(new BoneArms()); break;
                case 1: PackItem(new BoneChest()); break;
                case 2: PackItem(new BoneGloves()); break;
                case 3: PackItem(new BoneLegs()); break;
                case 4: PackItem(new BoneHelm()); break;
            }
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Poor);
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
        public override bool BleedImmune { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lesser; } }

        public SkeletonArcher(Serial serial)
            : base(serial)
        {
        }

        public override OppositionGroup OppositionGroup
        {
            get { return OppositionGroup.FeyAndUndead; }
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
