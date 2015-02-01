using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de fourmi")]
    public class FourmiMatriarche : BaseCreature
    {
        [Constructable]
        public FourmiMatriarche()
            : base(AIType.AI_Mage, FightMode.Weakest, 14, 2, 0.4, 0.5)
        {
            Name = "Fourmi Matriarche";
            Body = 64;
            BaseSoundID = 960;

            PlayersAreEnemies = true;
            MaxRange = 2;

            SetStr(100);
            SetDex(30);
            SetInt(100);

            SetHits(400);
            SetMana(300);
            SetStam(100);
            SetArme(14, 20, 40);

            SetResistance(ResistanceType.Physical, 20);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArmureNaturelle, 68);
            SetSkill(SkillName.Tactiques, 50);
            SetSkill(SkillName.Epee, 50);
            SetSkill(SkillName.MagieDeGuerre, 50);
            SetSkill(SkillName.ArtMagique, 74);
            SetSkill(SkillName.Evocation, 74);
            SetSkill(SkillName.ResistanceMagique, 74);

        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.NecroRegs);

        }

        public override int Bones { get { return 7; } }
        public override BoneType BoneType { get { return BoneType.Desertique; } }

        public FourmiMatriarche(Serial serial)
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