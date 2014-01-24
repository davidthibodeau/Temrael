using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
    [CorpseName("Gobelin")]
    public class GobelinElite : BaseCreature
    {
        public override InhumanSpeech SpeechType { get { return InhumanSpeech.Orc; } }

        [Constructable]
        public GobelinElite()
            : base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Body = 251;
            Name = "Gobelin Elite";
            BaseSoundID = 0x45A;

            SetStr(147, 215);
            SetDex(91, 115);
            SetInt(61, 85);

            SetHits(150, 300);

            SetDamage(15, 30);

            SetDamageType(ResistanceType.Physical, 75);
            SetDamageType(ResistanceType.Contondant, 25);

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Contondant, 10, 30);
            SetResistance(ResistanceType.Tranchant, 10, 30);
            SetResistance(ResistanceType.Perforant, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

            SetSkill(SkillName.Concentration, 70.1, 85.0);
            SetSkill(SkillName.ArmeTranchante, 60.1, 85.0);
            SetSkill(SkillName.Tactiques, 75.1, 90.0);
            SetSkill(SkillName.ArmePoing, 60.1, 85.0);

            Fame = 2500;
            Karma = -2500;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager);
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.0; } }
        public override bool CanRummageCorpses { get { return true; } }
        public override int Bones { get { return 3; } }
        public override int Hides { get { return 1; } }
        public override HideType HideType { get { return HideType.Regular; } }
        public override BoneType BoneType { get { return BoneType.Gobelin; } }

        public override OppositionGroup OppositionGroup
        {
            get { return OppositionGroup.SavagesAndOrcs; }
        }

        public GobelinElite(Serial serial)
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
