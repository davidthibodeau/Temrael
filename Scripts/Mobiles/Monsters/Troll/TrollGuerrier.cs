    using System;
    using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de troll")]
    public class TrollGuerrier : BaseCreature
    {
        [Constructable]
        public TrollGuerrier()
            : base(AIType.AI_Melee, FightMode.Closest, 11, 1, 0.2, 0.4)
        {
            Name = "Troll Guerrier";
            Body = 53;
            BaseSoundID = 427;

            PlayersAreEnemies = true;

            SetStr(120);
            SetDex(40);
            SetInt(25);

            SetHits(300);
            SetMana(50);
            SetStam(80);
            SetArme(15, 23, 40);

            SetResistance(ResistanceType.Physical, 30);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.Tactiques, 80);
            SetSkill(SkillName.Epee, 80);
            SetSkill(SkillName.Penetration, 80);
            SetSkill(SkillName.Anatomie, 80);
            SetSkill(SkillName.CoupCritique, 80);
            SetSkill(SkillName.Parer, 80);
            SetSkill(SkillName.Concentration, 20);
        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Food);
            AddLoot(LootPack.Food);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.UtilityItems);


        }

        public override int Bones { get { return 4; } }
        public override BoneType BoneType { get { return BoneType.Volcanique; } }



        public TrollGuerrier(Serial serial)
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