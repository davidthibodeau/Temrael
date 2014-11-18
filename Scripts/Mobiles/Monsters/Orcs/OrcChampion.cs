using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre d'orc")]
    public class OrcChampion : BaseCreature
    {
        [Constructable]
        public OrcChampion()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Orc Champion";
            Body = 7;
            BaseSoundID = 433;

            PlayersAreEnemies = true;
            Direction = Direction.West;

            SetStr(120);
            SetDex(60);
            SetInt(30);

            SetHits(200);
            SetMana(60);
            SetStam(120);
            SetArme(12, 18, 30);

            SetResistance(ResistanceType.Physical, 30);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.ArmureNaturelle, 40);
            SetSkill(SkillName.Tactiques, 58);
            SetSkill(SkillName.Epee, 60);
            SetSkill(SkillName.Anatomie, 40);
            SetSkill(SkillName.CoupCritique, 42);
            SetSkill(SkillName.ResistanceMagique, 4);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Food);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.PlateAr);
        }

        public override int Bones { get { return 5; } }
        public override BoneType BoneType { get { return BoneType.Nordique; } }

        public OrcChampion(Serial serial)
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