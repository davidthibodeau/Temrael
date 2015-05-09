    using System;
    using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Cyclope")]
    public class CyclopeGuerrier : BaseCreature
    {
        [Constructable]
        public CyclopeGuerrier()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 2, 0.2, 0.4)
        {
            Name = "Cyclope Guerrier";
            Body = 75;
            BaseSoundID = 609;

            PlayersAreEnemies = true;
            MaxRange = 2;

            SetStr(100);
            SetDex(60);
            SetInt(25);

            SetHits(300);
            SetMana(50);
            SetStam(100);
            SetArme(16, 24, 60);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArmureNaturelle, 92);
            SetSkill(SkillName.Tactiques, 92);
            SetSkill(SkillName.Epee, 92);
            SetSkill(SkillName.Anatomie, 92);
            SetSkill(SkillName.CoupCritique, 76);
            SetSkill(SkillName.Parer, 84);
        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Food);
            AddLoot(LootPack.Food);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Junk);

        }

        public override int Bones { get { return 7; } }
        public override BoneType BoneType { get { return BoneType.Geant; } }


        public CyclopeGuerrier(Serial serial)
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