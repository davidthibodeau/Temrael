using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de troll")]
    public class Troll : BaseCreature
    {
        [Constructable]
        public Troll()
            : base(AIType.AI_Melee, FightMode.Closest, 11, 1, 0.2, 0.4)
        {
            Name = "Troll";
            Body = 54;
            BaseSoundID = 427;

            PlayersAreEnemies = true;

            SetStr(100);
            SetDex(40);
            SetInt(25);

            SetHits(250);
            SetMana(50);
            SetStam(80);
            SetArme(13, 20, 40);

            SetResistance(ResistanceType.Physical, 20);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArmureNaturelle, 76);
            SetSkill(SkillName.Tactiques, 76);
            SetSkill(SkillName.Epee, 76);
            SetSkill(SkillName.Penetration, 76);
            SetSkill(SkillName.Anatomie, 40);
            SetSkill(SkillName.CoupCritique, 76);
            SetSkill(SkillName.Parer, 40);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Food);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Junk);
        }

        public override int Bones { get { return 2; } }
        public override BoneType BoneType { get { return BoneType.Volcanique; } }

        public Troll(Serial serial)
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