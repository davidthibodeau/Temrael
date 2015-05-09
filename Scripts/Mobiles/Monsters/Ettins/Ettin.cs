    using System;
    using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre d'ettin")]
    public class Ettin : BaseCreature
    {
        [Constructable]
        public Ettin()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 2, 0.2, 0.4)
        {
            Name = "Ettin";
            Body = 2;
            BaseSoundID = 367;

            PlayersAreEnemies = true;
            MaxRange = 2;

            SetStr(100);
            SetDex(60);
            SetInt(25);

            SetHits(250);
            SetMana(50);
            SetStam(100);
            SetArme(16, 24, 60);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArmureNaturelle, 90);
            SetSkill(SkillName.Tactiques, 90);
            SetSkill(SkillName.Epee, 90);
            SetSkill(SkillName.Detection, 100);
            SetSkill(SkillName.Anatomie, 40);
            SetSkill(SkillName.CoupCritique, 50);
            SetSkill(SkillName.Parer, 84);
        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Food);
            AddLoot(LootPack.Food);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Junk);

        }

        public override int Bones { get { return 4; } }
        public override BoneType BoneType { get { return BoneType.Geant; } }

        public Ettin(Serial serial)
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