using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Gobelin")]
    public class GobelinFrancTireur : BaseCreature
    {
        [Constructable]
        public GobelinFrancTireur()
            : base(AIType.AI_Archer, FightMode.Closest, 9, 2, 0.3, 0.5)
        {
            Name = "Gobelin Franc-Tireur";
            Body = 251;
            BaseSoundID = 462;

            PlayersAreEnemies = true;
            Hidden = true;
            MaxRange = 9;

            SetStr(40);
            SetDex(60);
            SetInt(10);

            SetHits(150);
            SetMana(20);
            SetStam(120);
            SetArme(6, 9, 30);

            SetResistance(ResistanceType.Physical, 30);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.Infiltration, 36);
            SetSkill(SkillName.Tactiques, 48);
            SetSkill(SkillName.Epee, 48);
            SetSkill(SkillName.Penetration, 48);

        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Junk);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Food);

            Server.Items.Arrow arrow = new Server.Items.Arrow(30);
            AddToBackpack(arrow);
        }

        public override int Bones { get { return 3; } }
        public override BoneType BoneType { get { return BoneType.Gobelin; } }

        public GobelinFrancTireur(Serial serial)
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