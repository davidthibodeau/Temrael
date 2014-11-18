using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre d'homme-lézard")]
    public class HommeLezardChasseur : BaseCreature
    {
        [Constructable]
        public HommeLezardChasseur()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Homme-Lézard Chasseur";
            Body = 35;
            BaseSoundID = 418;

            PlayersAreEnemies = true;

            SetStr(100);
            SetDex(70);
            SetInt(20);

            SetHits(200);
            SetMana(40);
            SetStam(140);
            SetArme(7, 12, 40, Poison.Regular);

            SetResistance(ResistanceType.Physical, 10);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.Empoisonnement, 70);
            SetSkill(SkillName.Tactiques, 62);
            SetSkill(SkillName.Epee, 62);
            SetSkill(SkillName.Anatomie, 62);
            SetSkill(SkillName.ResistanceMagique, 30);
            SetSkill(SkillName.CoupCritique, 34);

        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Food);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.LeatherAr);

        }

        public override int Bones { get { return 4; } }
        public override BoneType BoneType { get { return BoneType.Reptilien; } }

        public HommeLezardChasseur(Serial serial)
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