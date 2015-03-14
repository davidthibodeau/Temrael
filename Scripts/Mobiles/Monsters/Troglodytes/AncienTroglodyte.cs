    using System;
    using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de troglodyte")]
    public class TroglodyteGeant : BaseCreature
    {
        [Constructable]
        public TroglodyteGeant()
            : base(AIType.AI_Mage, FightMode.Closest, 11, 1, 0.2, 0.4)
        {
            Name = "Troglodyte Ancien";
            Body = 153;
            BaseSoundID = 442;
            MaxRange = 2;

            PlayersAreEnemies = true;

            SetStr(140);
            SetDex(80);
            SetInt(100);

            SetHits(3000);
            SetMana(1000);
            SetStam(100);
            SetArme(20, 28, 40);

            SetResistance(ResistanceType.Physical, 40);
            SetResistance(ResistanceType.Magical, 30);

            SetSkill(SkillName.Anatomie, 88);
            SetSkill(SkillName.Tactiques, 88);
            SetSkill(SkillName.Epee, 88);
            SetSkill(SkillName.ArtMagique, 88);
            SetSkill(SkillName.Alteration, 88);
            SetSkill(SkillName.CoupCritique, 88);
            SetSkill(SkillName.Parer, 40);
        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Food);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.UtilityItems);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.NecroRegs);
            AddLoot(LootPack.NecroRegs);

            Sapphire Sapphire = new Sapphire(1);
            AddToBackpack(Sapphire);

            Sapphire = new Sapphire(1);
            AddToBackpack(Sapphire);

            Sapphire = new Sapphire(1);
            AddToBackpack(Sapphire);

            MytherilIngot MytherilIngot = new MytherilIngot(1);
            AddToBackpack(MytherilIngot);

            MytherilIngot = new MytherilIngot(1);
            AddToBackpack(MytherilIngot);

            MytherilIngot = new MytherilIngot(1);
            AddToBackpack(MytherilIngot);
        }

        public override int Bones { get { return 9; } }
        public override BoneType BoneType { get { return BoneType.Maritime; } }


        public TroglodyteGeant(Serial serial)
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