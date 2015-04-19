    using System;
    using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de troglodyte")]
    public class TroglodyteGuerrier : BaseCreature
    {
        [Constructable]
        public TroglodyteGuerrier()
            : base(AIType.AI_Melee, FightMode.Closest, 11, 1, 0.2, 0.4)
        {
            Name = "Troglodyte Guerrier";
            Body = 154;
            BaseSoundID = 442;

            PlayersAreEnemies = true;

            SetStr(110);
            SetDex(80);
            SetInt(25);

            SetHits(250);
            SetMana(50);
            SetStam(160);
            SetArme(16, 24, 40);

            SetResistance(ResistanceType.Physical, 30);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArmureNaturelle, 86);
            SetSkill(SkillName.Tactiques, 86);
            SetSkill(SkillName.Epee, 86);
            SetSkill(SkillName.Penetration, 86);
            SetSkill(SkillName.Anatomie, 86);
            SetSkill(SkillName.CoupCritique, 86);
            SetSkill(SkillName.Parer, 54);
        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Food);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Junk);

        }

        public override int Bones { get { return 3; } }
        public override BoneType BoneType { get { return BoneType.Maritime; } }

        public TroglodyteGuerrier(Serial serial)
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