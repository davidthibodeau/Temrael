    using System;
    using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de troglodyte")]
    public class Troglodyte : BaseCreature
    {
        [Constructable]
        public Troglodyte()
            : base(AIType.AI_Melee, FightMode.Closest, 11, 1, 0.2, 0.4)
        {
            Name = "Troglodyte";
            Body = 149;
            BaseSoundID = 442;

            PlayersAreEnemies = true;

            SetStr(80);
            SetDex(80);
            SetInt(25);

            SetHits(200);
            SetMana(50);
            SetStam(160);
            SetArme(14, 22, 40);

            SetResistance(ResistanceType.Physical, 20);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArmureNaturelle, 84);
            SetSkill(SkillName.Tactiques, 84);
            SetSkill(SkillName.Epee, 84);
            SetSkill(SkillName.Detection, 100);
            SetSkill(SkillName.Anatomie, 40);
            SetSkill(SkillName.CoupCritique, 84);
            SetSkill(SkillName.Parer, 14);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Food);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Junk);
        }

        public override int Bones { get { return 2; } }
        public override BoneType BoneType { get { return BoneType.Maritime; } }


        public Troglodyte(Serial serial)
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
    