using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Gobelin")]
    public class GobelinCavalier : BaseCreature
    {
        [Constructable]
        public GobelinCavalier()
            : base(AIType.AI_Berserk, FightMode.Aggressor, 8, 2, 0.1, 0.3)
        {
            Name = "Gobelin Cavalier";
            Body = 247;
            BaseSoundID = 462;

            PlayersAreEnemies = true;
            Direction = Direction.Left;

            SetStr(80);
            SetDex(80);
            SetInt(15);

            SetHits(130);
            SetMana(20);
            SetStam(160);
            SetArme(4, 8, 40);

            SetResistance(ResistanceType.Physical, 40);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.ArmureNaturelle, 50);
            SetSkill(SkillName.Tactiques, 50);
            SetSkill(SkillName.Epee, 50);
            SetSkill(SkillName.Parer, 50);

        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Food);
        }

        public override int Bones { get { return 5; } }
        public override BoneType BoneType { get { return BoneType.Gobelin; } }

        public GobelinCavalier(Serial serial)
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