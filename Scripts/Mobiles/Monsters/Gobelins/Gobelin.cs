using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
    [CorpseName("Gobelin")]
    public class Gobelin : BaseCreature
    {
        public override InhumanSpeech SpeechType { get { return InhumanSpeech.Orc; } }

        [Constructable]
        public Gobelin()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Gobelin";
            Body = 248;
            BaseSoundID = 0x45A;

            SetStr(96, 120);
            SetDex(81, 105);
            SetInt(36, 60);

            SetHits(100, 200);

            SetDamage(5, 10);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 0, 10);
            
            
            
            SetResistance(ResistanceType.Magie, 0, 10);

            SetSkill(SkillName.Concentration, 50.1, 75.0);
            SetSkill(SkillName.Tactiques, 55.1, 80.0);
            SetSkill(SkillName.Anatomie, 50.1, 70.0);

        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Poor);
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.0; } }
        public override bool CanRummageCorpses { get { return true; } }
        //public override int TreasureMapLevel { get { return 1; } }
        public override int Bones { get { return 1; } }
        public override int Hides { get { return 1; } }
        public override HideType HideType { get { return HideType.Regular; } }
        public override BoneType BoneType { get { return BoneType.Gobelin; } }

        public override OppositionGroup OppositionGroup
        {
            get { return OppositionGroup.SavagesAndOrcs; }
        }

        public Gobelin(Serial serial)
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
