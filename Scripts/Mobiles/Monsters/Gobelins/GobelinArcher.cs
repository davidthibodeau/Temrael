using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Gobelin")]
    public class GobelinArcher : BaseCreature
    {
        [Constructable]
        public GobelinArcher()
            : base(AIType.AI_Archer, FightMode.Closest, 9, 9, 0.2, 0.4)
        {
            Name = "Gobelin Archer";
            Body = 249;
            BaseSoundID = 462;

            PlayersAreEnemies = true;
            Direction = Direction.Left;

            SetStr(30);
            SetDex(40);
            SetInt(10);

            SetHits(80);
            SetMana(20);
            SetStam(40);
            SetArme(2, 5, 30);

            SetResistance(ResistanceType.Physical, 10);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.ArmureNaturelle, 26);
            SetSkill(SkillName.Tactiques, 46);
            SetSkill(SkillName.Epee, 46);
            SetSkill(SkillName.CoupCritique, 42);

        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Junk);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Food);

            Server.Items.Arrow arrow = new Server.Items.Arrow(25);
            AddToBackpack(arrow);
        }

        public override int Bones { get { return 2; } }
        public override BoneType BoneType { get { return BoneType.Gobelin; } }

        public GobelinArcher(Serial serial)
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