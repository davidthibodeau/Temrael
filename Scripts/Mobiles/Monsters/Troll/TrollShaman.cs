    using System;
    using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de troll")]
    public class TrollShaman : BaseCreature
    {
        [Constructable]
        public TrollShaman()
            : base(AIType.AI_Healer, FightMode.Closest, 11, 1, 0.2, 0.4)
        {
            Name = "Troll Shaman";
            Body = 55;
            BaseSoundID = 427;

            PlayersAreEnemies = true;

            SetStr(80);
            SetDex(30);
            SetInt(100);

            SetHits(225);
            SetMana(200);
            SetStam(80);
            SetArme(13, 20, 40);

            SetResistance(ResistanceType.Physical, 20);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArtMagique, 82);
            SetSkill(SkillName.Thaumaturgie, 82);
            SetSkill(SkillName.Epee, 82);
            SetSkill(SkillName.Tactiques, 82);
            SetSkill(SkillName.Anatomie, 38);
            SetSkill(SkillName.MagieDeGuerre, 82);
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
        }

        public override int Bones { get { return 5; } }
        public override BoneType BoneType { get { return BoneType.Volcanique; } }

        public TrollShaman(Serial serial)
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