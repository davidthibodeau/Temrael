using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Corps de Gazer")]
    public class Gazer : BaseCreature
    {
        public override bool InitialInnocent { get { return true; } }

        [Constructable]
        public Gazer()
            : base(AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4)
        {
            Name = "Gazer";
            Body = 22;
            BaseSoundID = 382;

            SetStr(96, 125);
            SetDex(86, 105);
            SetInt(141, 165);

            SetHits(150, 300);

            SetDamage(10, 20);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

            //SetSkill( SkillName.EvalInt, 50.1, 65.0 );
            SetSkill(SkillName.ArtMagique, 50.1, 65.0);
            SetSkill(SkillName.Concentration, 60.1, 75.0);
            SetSkill(SkillName.Tactiques, 50.1, 70.0);
            SetSkill(SkillName.ArmePoing, 50.1, 70.0);

            Fame = 3500;
            Karma = -3500;

            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 60.0;

            PackItem(new Nightshade(4));
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
            AddLoot(LootPack.Potions);
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
        public override int Meat { get { return 1; } }
        public override int Bones { get { return 2; } }
        public override int Hides { get { return 6; } }
        public override HideType HideType { get { return HideType.Magique; } }
        public override BoneType BoneType { get { return BoneType.Magique; } }

        public Gazer(Serial serial)
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