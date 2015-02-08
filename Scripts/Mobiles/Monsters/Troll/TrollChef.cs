using System;
    using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de troll")]
    public class TrollChef : BaseCreature
    {
        [Constructable]
        public TrollChef()
            : base(AIType.AI_Mage, FightMode.Closest, 11, 2, 0.2, 0.4)
        {
            Name = "Troll Chef";
            Body = 55;
            BaseSoundID = 427;

            PlayersAreEnemies = true;
            MaxRange = 2;

            SetStr(100);
            SetDex(30);
            SetInt(100);

            SetHits(600);
            SetMana(300);
            SetStam(200);
            SetArme(20, 30, 40);

            SetResistance(ResistanceType.Physical, 50);
            SetResistance(ResistanceType.Magical, 50);

            SetSkill(SkillName.ArtMagique, 100);
            SetSkill(SkillName.Evocation, 100);
            SetSkill(SkillName.Epee, 90);
            SetSkill(SkillName.Tactiques, 90);
            SetSkill(SkillName.Anatomie, 38);
            SetSkill(SkillName.MagieDeGuerre, 100);
            SetSkill(SkillName.ResistanceMagique, 72);

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
        public override BoneType BoneType { get { return BoneType.Volcanique; } }


        public TrollChef(Serial serial)
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