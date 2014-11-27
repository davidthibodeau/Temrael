using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de feu follet")]
    public class FeuFollet : BaseCreature
    {
        [Constructable]
        public FeuFollet()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Feu Follet";
            Body = 58;
            BaseSoundID = 1136;

            PlayersAreEnemies = true;

            SetStr(60);
            SetDex(60);
            SetInt(120);

            SetHits(200);
            SetMana(300);
            SetStam(140);
            SetArme(5, 10, 40);

            SetResistance(ResistanceType.Physical, 10);
            SetResistance(ResistanceType.Magie, 50);

            SetSkill(SkillName.ArtMagique, 60);
            SetSkill(SkillName.Evocation, 60);
            SetSkill(SkillName.Epee, 30);
            SetSkill(SkillName.Tactiques, 30);
            SetSkill(SkillName.Alteration, 60);
            SetSkill(SkillName.MagieDeGuerre, 48);
        }

        public override void GenerateLoot()
        {

            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);
            AddLoot(LootPack.Regs);

            Tourmaline tourmaline = new Tourmaline(1);
            AddToBackpack(tourmaline);
            AddToBackpack(tourmaline);
        }


        public FeuFollet(Serial serial)
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