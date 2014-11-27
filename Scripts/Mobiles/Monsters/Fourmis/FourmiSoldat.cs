using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de fourmi")]
    public class FourmiSoldat : BaseCreature
    {
        [Constructable]
        public FourmiSoldat()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.15, 0.3)
        {
            Name = "Fourmi Soldat";
            Body = 63;
            BaseSoundID = 960;

            PlayersAreEnemies = true;

            SetStr(120);
            SetDex(80);
            SetInt(50);

            SetHits(275);
            SetMana(100);
            SetStam(160);
            SetArme(12, 18, 30);

            SetResistance(ResistanceType.Physical, 20);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.ArmureNaturelle, 70);
            SetSkill(SkillName.Tactiques, 70);
            SetSkill(SkillName.Epee, 70);
            SetSkill(SkillName.CoupCritique, 35);
            SetSkill(SkillName.Penetration, 70);
            SetSkill(SkillName.ResistanceMagique, 50);
            SetSkill(SkillName.Parer, 35);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Food);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Junk);

        }

        public override int Bones { get { return 3; } }
        public override BoneType BoneType { get { return BoneType.Desertique; } }

        public FourmiSoldat(Serial serial)
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