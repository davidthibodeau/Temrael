using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Ssins")]
    public class Ssins : BaseCreature
    {
        [Constructable]
        public Ssins()
            : base(AIType.AI_Thief, FightMode.Closest, 5, 1, 0.3, 0.5)
        {
            Name = "Ssins";
            Body = 42;
            BaseSoundID = 393;

            PlayersAreEnemies = true;

            SetStr(20);
            SetDex(30);
            SetInt(10);

            SetHits(30);
            SetMana(10);
            SetStam(40);
            SetArme(1, 5, 40);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.Vol, 60);
            SetSkill(SkillName.Tactiques, 30);
            SetSkill(SkillName.Epee, 30);

        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Junk);
            AddLoot(LootPack.Food);
            AddLoot(LootPack.Food);
        }

        public override int Bones { get { return 1; } }
        public override BoneType BoneType { get { return BoneType.Regular; } }

        public Ssins(Serial serial)
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