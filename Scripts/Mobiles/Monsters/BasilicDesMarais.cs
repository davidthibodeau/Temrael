    using System;
    using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Basilic des marais")]
    public class BasilicDesMarais : BaseCreature
    {
        [Constructable]
        public BasilicDesMarais()
            : base(AIType.AI_Melee, FightMode.Closest, 7, 1, 0.2, 0.4)
        {
            Name = "BasilicDesMarais";
            Body = 206;
            Hue = 2464;
            BaseSoundID = 660;

            PlayersAreEnemies = true;
            MaxRange = 1;
            Hidden = true;

            SetStr(100);
            SetDex(100);
            SetInt(10);

            SetHits(275);
            SetMana(20);
            SetStam(250);
            SetArme(14, 22, 40);

            SetResistance(ResistanceType.Physical, 10);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.Infiltration, 80);
            SetSkill(SkillName.ArmureNaturelle, 90);
            SetSkill(SkillName.Tactiques, 80);
            SetSkill(SkillName.Epee, 80);
            SetSkill(SkillName.Anatomie, 80);
            SetSkill(SkillName.Poursuite, 80);
            SetSkill(SkillName.CoupCritique, 60);
        }


        public override void GenerateLoot()
        {
        }

        public override int Hide { get { return 5; } }
        public override HideType HideType { get { return HideType.Maritime; } }

        public BasilicDesMarais(Serial serial)
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