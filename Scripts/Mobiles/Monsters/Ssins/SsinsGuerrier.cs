using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Ssins")]
    public class SsinsGuerrier : BaseCreature
    {
        [Constructable]
        public SsinsGuerrier()
            : base(AIType.AI_Melee, FightMode.Closest, 7, 1, 0.3, 0.5)
        {
            Name = "Ssins Guerrier";
            Body = 45;
            BaseSoundID = 393;

            PlayersAreEnemies = true;

            SetStr(50);
            SetDex(20);
            SetInt(10);

            SetHits(150);
            SetMana(10);
            SetStam(40);
            SetArme(3, 7, 40);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.ArmureNaturelle, 40);
            SetSkill(SkillName.Tactiques, 40);
            SetSkill(SkillName.Epee, 40);

        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Junk);
            AddLoot(LootPack.Food);
            AddLoot(LootPack.Food);
        }

        public override int Bones { get { return 2; } }
        public override BoneType BoneType { get { return BoneType.Regular; } }

        public SsinsGuerrier(Serial serial)
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