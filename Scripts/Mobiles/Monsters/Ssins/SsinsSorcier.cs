using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Ssins")]
    public class SsinsSorcier : BaseCreature
    {
        [Constructable]
        public SsinsSorcier()
            : base(AIType.AI_Mage, FightMode.Closest, 9, 1, 0.2, 0.4)
        {
            Name = "SsinsSorcier";
            Body = 44;
            BaseSoundID = 0x189;



            PlayersAreEnemies = true;

            SetStr(20);
            SetDex(30);
            SetInt(50);

            SetHits(115);
            SetMana(100);
            SetStam(40);
            SetArme(2, 6, 40);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArtMagique, 55);
            SetSkill(SkillName.Evocation, 55);
            SetSkill(SkillName.Epee, 10);
            SetSkill(SkillName.Tactiques, 10);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);

            AddLoot(LootPack.Junk);
            AddLoot(LootPack.Food);
        }

        public override int Bones { get { return 4; } }
        public override BoneType BoneType { get { return BoneType.Regular; } }

        public SsinsSorcier(Serial serial)
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