using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Gobelin")]
    public class GobelinGuerrier : BaseCreature
    {
        [Constructable]
        public GobelinGuerrier()
            : base(AIType.AI_Melee, FightMode.Closest, 8, 1, 0.2, 0.4)
        {
            Name = "Gobelin Guerrier";
            Body = 248;
            BaseSoundID = 462;

            PlayersAreEnemies = true;
            Direction = Direction.Left;

            SetStr(30);
            SetDex(20);
            SetInt(10);

            SetHits(150);
            SetMana(10);
            SetStam(40);
            SetArme(3, 7, 30);

            SetResistance(ResistanceType.Physical, 10);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArmureNaturelle, 30);
            SetSkill(SkillName.Tactiques, 46);
            SetSkill(SkillName.Epee, 46);
            SetSkill(SkillName.Parer, 38);

        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Junk);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Food);
        }

        public override int Bones { get { return 2; } }
        public override BoneType BoneType { get { return BoneType.Gobelin; } }

        public GobelinGuerrier(Serial serial)
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