    using System;
    using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Cyclope")]
    public class CyclopeShaman : BaseCreature
    {
        [Constructable]
        public CyclopeShaman()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 2, 0.2, 0.4)
        {
            Name = "Cyclope Shaman";
            Body = 75;
            BaseSoundID = 768;

            PlayersAreEnemies = true;
            MaxRange = 2;

            SetStr(30);
            SetDex(30);
            SetInt(100);

            SetHits(250);
            SetMana(250);
            SetStam(60);
            SetArme(13, 20, 60);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArtMagique, 94);
            SetSkill(SkillName.Evocation, 94);
            SetSkill(SkillName.MagieDeGuerre, 94);
            SetSkill(SkillName.Ensorcellement, 94);
            SetSkill(SkillName.Epee, 70);
            SetSkill(SkillName.Tactiques, 84);
        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Food);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.NecroRegs);
            AddLoot(LootPack.NecroRegs);

        }

        public override int Bones { get { return 8; } }
        public override BoneType BoneType { get { return BoneType.Geant; } }

        public CyclopeShaman(Serial serial)
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