    using System;
    using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de ver charognard")]
    public class VerCharognard : BaseCreature
    {
        [Constructable]
        public VerCharognard()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Ver Charognard";
            Body = 179;
            BaseSoundID = 844;

            PlayersAreEnemies = true;

            SetStr(60);
            SetDex(60);
            SetInt(90);

            SetHits(200);
            SetMana(180);
            SetStam(140);
            SetArme(5, 10, 40);

            SetResistance(ResistanceType.Physical, 10);
            SetResistance(ResistanceType.Magical, 10);

            SetSkill(SkillName.ArtMagique, 60);
            SetSkill(SkillName.Immuabilite, 100);
            SetSkill(SkillName.Epee, 50);
            SetSkill(SkillName.Tactiques, 50);
            SetSkill(SkillName.MagieDeGuerre, 48);
        }

        public override void GenerateLoot()
        {
            Tourmaline tourmaline = new Tourmaline(1);
            AddToBackpack(tourmaline);
        }


        public VerCharognard(Serial serial)
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