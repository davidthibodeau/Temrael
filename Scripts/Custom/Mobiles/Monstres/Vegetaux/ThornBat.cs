using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Corps de Chauve-Souris")]
    public class ThornBat : BaseCreature
    {
        [Constructable]
        public ThornBat()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Chauve-Souris de Foret";
            Body = 168;

            SetStr(96, 120);
            SetDex(91, 115);
            SetInt(21, 45);

            SetHits(50, 100);

            SetDamage(5, 10);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 0, 10);
            SetResistance(ResistanceType.Contondant, 0, 10);
            SetResistance(ResistanceType.Tranchant, 0, 10);
            SetResistance(ResistanceType.Perforant, 0, 10);
            SetResistance(ResistanceType.Magie, 0, 10);

            SetSkill(SkillName.Concentration, 75.1, 100.0);
            SetSkill(SkillName.Tactiques, 55.1, 80.0);
            SetSkill(SkillName.ArmePoing, 55.1, 75.0);

            Fame = 450;
            Karma = -450;
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Poor);
        }

        public override int Hides { get { return 6; } }
        public override int Meat { get { return 1; } }

        public ThornBat(Serial serial)
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