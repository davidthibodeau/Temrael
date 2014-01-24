using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
    [CorpseName("Rat Géant")]
    public class GiantRatman : BaseCreature
    {
        public override InhumanSpeech SpeechType { get { return InhumanSpeech.Ratman; } }

        [Constructable]
        public GiantRatman()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Rat Géant";
            Body = 175;
            BaseSoundID = 437;

            SetStr(96, 120);
            SetDex(81, 100);
            SetInt(36, 60);

            SetHits(400, 800);

            SetDamage(20, 40);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

            SetSkill(SkillName.Concentration, 35.1, 60.0);
            SetSkill(SkillName.Tactiques, 50.1, 65);
            SetSkill(SkillName.ArmePoing, 50.1, 65);

            Fame = 1500;
            Karma = -1500;

            VirtualArmor = 85;
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 4.0; } }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
            // TODO: weapon, misc
        }

        public override bool CanRummageCorpses { get { return true; } }

        public GiantRatman(Serial serial)
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