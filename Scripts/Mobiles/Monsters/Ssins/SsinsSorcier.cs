using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Ssins")]
    public class SsinsSorcier : BaseCreature
    {
        [Constructable]
        public SsinsSorcier()
            : base(AIType.AI_Mage, FightMode.Closest, 6, 1, 0.3, 0.5)
        {
            Name = "Ssins Sorcier";
            Body = 44;
            BaseSoundID = 393;

            PlayersAreEnemies = true;

            SetStr(20);
            SetDex(30);
            SetInt(50);

            SetHits(40);
            SetMana(100);
            SetStam(40);
            SetArme(1, 5, 40);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.ArtMagique, 50);
            SetSkill(SkillName.Evocation, 50);
            SetSkill(SkillName.Epee, 10);
            SetSkill(SkillName.Tactiques, 10);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Food);
            AddLoot(LootPack.Regs);
        }

        public override int Bones { get { return 3; } }
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