using System;
using System.Collections;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("a Crawler")]
    public class GiantCrawler : BaseCreature
    {
        [Constructable]
        public GiantCrawler()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Giant Crawler";
            Body = 180;
            BaseSoundID = 959;

            SetStr(196, 220);
            SetDex(101, 125);
            SetInt(36, 60);

            SetHits(300, 600);

            SetDamage(20, 40);

            SetDamageType(ResistanceType.Physical, 80);
            SetDamageType(ResistanceType.Perforant, 20);

            SetResistance(ResistanceType.Physical, 20, 35);
            SetResistance(ResistanceType.Contondant, 20, 35);
            SetResistance(ResistanceType.Tranchant, 10, 25);
            SetResistance(ResistanceType.Perforant, 20, 35);
            SetResistance(ResistanceType.Magie, 10, 25);

            SetSkill(SkillName.Concentration, 60.0);
            SetSkill(SkillName.Tactiques, 80.0);
            SetSkill(SkillName.Anatomie, 80.0);

            Fame = 3000;
            Karma = -3000;
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.5; } }

        /*public override int GetAngerSound()
        {
            return 0xB5;
        }

        public override int GetIdleSound()
        {
            return 0xB5;
        }

        public override int GetAttackSound()
        {
            return 0x289;
        }

        public override int GetHurtSound()
        {
            return 0xBC;
        }

        public override int GetDeathSound()
        {
            return 0xE4;
        }*/

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
        }

        public GiantCrawler(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)1);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}