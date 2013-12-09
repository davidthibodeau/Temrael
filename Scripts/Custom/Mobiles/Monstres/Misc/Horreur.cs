using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Corps d'Horreur")]
    public class Horreur : BaseCreature
    {
        [Constructable]
        public Horreur()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.6, 1.2)
        {
            Name = "Horreur";
            Body = 144;

            SetStr(801, 900);
            SetDex(46, 65);
            SetInt(36, 50);

            SetHits(500, 600);
            SetMana(0);

            SetDamage(10, 25);

            SetDamageType(ResistanceType.Physical, 60);
            SetDamageType(ResistanceType.Perforant, 40);

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

            SetSkill(SkillName.Concentration, 90.1, 95.0);
            SetSkill(SkillName.Tactiques, 70.1, 85.0);
            SetSkill(SkillName.ArmePoing, 65.1, 80.0);

            Fame = 8000;
            Karma = -8000;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average, 1);
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
        public override bool BardImmune { get { return !Core.AOS; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }

        public Horreur(Serial serial)
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