using System;
using Server;
using Server.Misc;

namespace Server.Mobiles
{
    [CorpseName("Corps de Dryad")]
    public class ForestDryad : BaseCreature
    {
        public override bool InitialInnocent { get { return true; } }

        [Constructable]
        public ForestDryad()
            : base(AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4)
        {
            Name = "Dryad";
            Body = 141;
            BaseSoundID = 0x57B;

            SetStr(21, 30);
            SetDex(301, 400);
            SetInt(201, 250);

            SetHits(200, 400);

            SetDamage(10, 20);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

            //SetSkill( SkillName.EvalInt, 90.1, 100.0 );
            SetSkill(SkillName.ArtMagique, 90.1, 100.0);
            SetSkill(SkillName.Concentration, 90.1, 100.0);
            SetSkill(SkillName.Concentration, 100.5, 150.0);
            SetSkill(SkillName.Tactiques, 10.1, 20.0);
            SetSkill(SkillName.ArmePoing, 10.1, 12.5);

            Fame = 7000;
            Karma = 7000;
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }

        public override void GenerateLoot()
        {
            //AddLoot(LootPack.LowScrolls);
            AddLoot(LootPack.Gems, 2);
        }

        public override int Meat { get { return 1; } }
        public override int Bones { get { return 6; } }
        public override int Hides { get { return 8; } }
        public override HideType HideType { get { return HideType.Magique; } }
        public override BoneType BoneType { get { return BoneType.Magique; } }

        public ForestDryad(Serial serial)
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