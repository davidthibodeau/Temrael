    using System;
    using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre d'Ostard")]
    public class Ostard3 : BaseCreature
    {
        [Constructable]
        public Ostard3()
            : base(AIType.AI_Melee, FightMode.Closest, 8, 1, 0.2, 0.4)
        {
            Name = "Ostard";
            Body = 259;
            Hue = 0;
            BaseSoundID = 624;

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

            SetSkill(SkillName.Infiltration, 90);
            SetSkill(SkillName.ArmureNaturelle, 90);
            SetSkill(SkillName.Tactiques, 90);
            SetSkill(SkillName.Epee, 90);
            SetSkill(SkillName.Anatomie, 80);
            SetSkill(SkillName.Poursuite, 90);
            SetSkill(SkillName.CoupCritique, 75);
        }

        public override int Hides { get { return 5; } }
        public override HideType HideType { get { return HideType.Geant; } }

        public Ostard3(Serial serial)
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