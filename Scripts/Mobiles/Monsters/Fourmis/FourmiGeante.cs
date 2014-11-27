using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de fourmi")]
    public class FourmiGeante : BaseCreature
    {
        [Constructable]
        public FourmiGeante()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Fourmi Géante";
            Body = 62;
            BaseSoundID = 960;

            PlayersAreEnemies = true;

            SetStr(100);
            SetDex(80);
            SetInt(50);

            SetHits(200);
            SetMana(100);
            SetStam(160);
            SetArme(10, 16, 30);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.ArmureNaturelle, 68);
            SetSkill(SkillName.Tactiques, 68);
            SetSkill(SkillName.Epee, 68);
            SetSkill(SkillName.Detection, 68);
            SetSkill(SkillName.Penetration, 40);
            SetSkill(SkillName.ResistanceMagique, 68);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Food);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Junk);

        }

        public override int Bones { get { return 2; } }
        public override BoneType BoneType { get { return BoneType.Desertique; } }

        public FourmiGeante(Serial serial)
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