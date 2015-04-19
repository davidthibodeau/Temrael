    using System;
    using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Flaque visqueuse")]
    public class GeleeGrise : BaseCreature
    {
        [Constructable]
        public GeleeGrise()
            : base(AIType.AI_Melee, FightMode.Closest, 6, 1, 0.2, 0.4)
        {
            Name = "Gelée Grise";
            Body = 51;
            BaseSoundID = 456;

            PlayersAreEnemies = true;

            SetStr(50);
            SetDex(30);
            SetInt(10);

            SetHits(150);
            SetMana(20);
            SetStam(60);
            SetArme(4, 7, 30);

            SetResistance(ResistanceType.Physical, 10);
            SetResistance(ResistanceType.Magical, 10);

            SetSkill(SkillName.Anatomie, 36);
            SetSkill(SkillName.Tactiques, 48);
            SetSkill(SkillName.Epee, 48);
            SetSkill(SkillName.Parer, 48);

        }

        public override void GenerateLoot()
        {
            Amber amber = new Amber(1);
            AddToBackpack(amber);
        }

        public GeleeGrise(Serial serial)
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