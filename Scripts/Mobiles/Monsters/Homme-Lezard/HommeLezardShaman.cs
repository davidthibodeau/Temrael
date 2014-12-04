using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre d'homme-lézard")]
    public class HommeLezardShaman : BaseCreature
    {
        [Constructable]
        public HommeLezardShaman()
            : base(AIType.AI_Healer, FightMode.Closest, 11, 1, 0.2, 0.4)
        {
            Name = "Homme-Lézard Shaman";
            Body = 36;
            BaseSoundID = 418;

            PlayersAreEnemies = true;

            SetStr(60);
            SetDex(60);
            SetInt(120);

            SetHits(110);
            SetMana(120);
            SetStam(140);
            SetArme(7, 12, 40);

            SetResistance(ResistanceType.Physical, 10);
            SetResistance(ResistanceType.Magical, 20);

            SetSkill(SkillName.ArtMagique, 64);
            SetSkill(SkillName.Evocation, 64);
            SetSkill(SkillName.Epee, 50);
            SetSkill(SkillName.Tactiques, 50);
            SetSkill(SkillName.Thaumaturgie, 64);
            SetSkill(SkillName.MagieDeGuerre, 48);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Food);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.NecroRegs);

        }

        public override int Bones { get { return 5; } }
        public override BoneType BoneType { get { return BoneType.Reptilien; } }

        public HommeLezardShaman(Serial serial)
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