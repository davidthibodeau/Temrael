using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
    [CorpseName("Gobelin")]
    public class GobelinRider : BaseCreature
    {
        public override InhumanSpeech SpeechType { get { return InhumanSpeech.Orc; } }

        [Constructable]
        public GobelinRider()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Ritter Gobelin";
            Body = 247;
            BaseSoundID = 0x45A;

            SetStr(111, 145);
            SetDex(101, 135);
            SetInt(86, 110);

            SetHits(150, 400);

            SetDamage(20, 40);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

            SetSkill(SkillName.Concentration, 70.1, 85.0);
            SetSkill(SkillName.ArmeTranchante, 70.1, 95.0);
            SetSkill(SkillName.Tactiques, 85.1, 100.0);

            Fame = 2500;
            Karma = -2500;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
        public override bool CanRummageCorpses { get { return true; } }
        public override int Meat { get { return 1; } }
        public override int Bones { get { return 10; } }
        public override int Hides { get { return 1; } }
        public override HideType HideType { get { return HideType.Regular; } }
        public override BoneType BoneType { get { return BoneType.Gobelin; } }

        public override OppositionGroup OppositionGroup
        {
            get { return OppositionGroup.SavagesAndOrcs; }
        }

        public GobelinRider(Serial serial)
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