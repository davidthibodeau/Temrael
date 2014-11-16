using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Gobelin")]
    public class GobelinChampion : BaseCreature
    {
        [Constructable]
        public GobelinChampion()
            : base(AIType.AI_Thief, FightMode.Closest, 8, 1, 0.2, 0.4)
        {
            Name = "Gobelin Champion";
            Body = 250;
            BaseSoundID = 462;

            PlayersAreEnemies = true;
            Hidden = true;
            Direction = Direction.Left;

            SetStr(50);
            SetDex(30);
            SetInt(10);

            SetHits(100);
            SetMana(20);
            SetStam(60);
            SetArme(4, 7, 30);

            SetResistance(ResistanceType.Physical, 30);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.Infiltration, 36);
            SetSkill(SkillName.Tactiques, 48);
            SetSkill(SkillName.Epee, 48);
            SetSkill(SkillName.Parer, 48);

        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Junk);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Food);
        }

        public override int Bones { get { return 3; } }
        public override BoneType BoneType { get { return BoneType.Gobelin; } }

        public GobelinChampion(Serial serial)
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