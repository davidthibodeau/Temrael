using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre d'orc")]
    public class OrcGuerrier : BaseCreature
    {
        [Constructable]
        public OrcGuerrier()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Orc Guerrier";
            Body = 41;
            BaseSoundID = 433;

            PlayersAreEnemies = true;
            Direction = Direction.West;

            SetStr(100);
            SetDex(60);
            SetInt(10);

            SetHits(150);
            SetMana(10);
            SetStam(120);
            SetArme(6, 10, 40);

            SetResistance(ResistanceType.Physical, 20);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.ArmureNaturelle, 40);
            SetSkill(SkillName.Tactiques, 54);
            SetSkill(SkillName.Epee, 60);
            SetSkill(SkillName.Anatomie, 40);
            SetSkill(SkillName.CoupCritique, 46);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.RingAr);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Food);
        }

        public override int Bones { get { return 3; } }
        public override BoneType BoneType { get { return BoneType.Nordique; } }

        public OrcGuerrier(Serial serial)
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