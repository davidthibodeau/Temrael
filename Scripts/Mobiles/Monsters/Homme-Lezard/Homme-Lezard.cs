using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre d'homme-lézard")]
    public class HommeLezard : BaseCreature
    {
        [Constructable]
        public HommeLezard()
            : base(AIType.AI_Melee, FightMode.Closest, 11, 1, 0.2, 0.4)
        {
            Name = "Homme-Lézard";
            Body = 33;
            BaseSoundID = 418;

            PlayersAreEnemies = true;


            SetStr(90);
            SetDex(90);
            SetInt(20);

            SetHits(180);
            SetMana(40);
            SetStam(180);
            SetArme(5, 10, 40);

            SetResistance(ResistanceType.Physical, 5);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.Detection, 60);
            SetSkill(SkillName.Tactiques, 60);
            SetSkill(SkillName.Epee, 60);
            SetSkill(SkillName.Anatomie, 40);
            SetSkill(SkillName.ResistanceMagique, 60);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Food);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.UtilityItems);

        }

        public override int Bones { get { return 2; } }
        public override BoneType BoneType { get { return BoneType.Reptilien; } }

        public HommeLezard(Serial serial)
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