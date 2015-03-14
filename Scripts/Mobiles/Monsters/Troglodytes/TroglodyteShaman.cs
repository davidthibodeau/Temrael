    using System;
    using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de troglodyte")]
    public class TroglodyteShaman : BaseCreature
    {
        [Constructable]
        public TroglodyteShaman()
            : base(AIType.AI_Melee, FightMode.Closest, 11, 1, 0.2, 0.4)
        {
            Name = "Troglodyte Shaman";
            Body = 154;
            BaseSoundID = 442;

            PlayersAreEnemies = true;

            SetStr(80);
            SetDex(80);
            SetInt(80);

            SetHits(220);
            SetMana(160);
            SetStam(100);
            SetArme(14, 21, 40);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magical, 30);

            SetSkill(SkillName.ArmureNaturelle, 86);
            SetSkill(SkillName.Tactiques, 86);
            SetSkill(SkillName.Epee, 86);
            SetSkill(SkillName.ArtMagique, 86);
            SetSkill(SkillName.Alteration, 86);
            SetSkill(SkillName.Thaumaturgie, 86);
            SetSkill(SkillName.Parer, 44);
        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Food);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.NecroRegs);
            AddLoot(LootPack.NecroRegs);
        }

        public override int Bones { get { return 3; } }
        public override BoneType BoneType { get { return BoneType.Maritime; } }


        public TroglodyteShaman(Serial serial)
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