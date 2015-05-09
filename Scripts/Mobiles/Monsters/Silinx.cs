    using System;
    using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Silinx")]
    public class Silinx : BaseCreature
    {
        [Constructable]
        public Silinx()
            : base(AIType.AI_Mage, FightMode.Closest, 11, 2, 0.2, 0.4)
        {
            Name = "Silinx";
            Body = 8;
            BaseSoundID = 443;

            MaxRange = 4;

            PlayersAreEnemies = true;

            SetStr(80);
            SetDex(100);
            SetInt(80);

            SetHits(325);
            SetMana(35);
            SetStam(100);
            SetArme(12, 18, 40);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArmureNaturelle, 75);
            SetSkill(SkillName.Tactiques, 75);
            SetSkill(SkillName.Epee, 75);
            SetSkill(SkillName.ArtMagique, 80);
            SetSkill(SkillName.ResistanceMagique, 50);
            SetSkill(SkillName.Parer, 50);
            SetSkill(SkillName.Immuabilite, 100);
            SetSkill(SkillName.CoupCritique, 40);


        }

        public override void GenerateLoot()
        {

            Emerald emerald = new Emerald(1);
            AddToBackpack(emerald);

            emerald = new Emerald(1);
            AddToBackpack(emerald);
        }


        public Silinx(Serial serial)
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