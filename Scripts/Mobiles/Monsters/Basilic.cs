    using System;
    using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Basilic")]
    public class Basilic : BaseCreature
    {
        [Constructable]
        public Basilic()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Basilic";
            Body = 206;
            Hue = 0;
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
            SetArme(15, 23, 40);

            SetResistance(ResistanceType.Physical, 20);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.Infiltration, 90);
            SetSkill(SkillName.ArmureNaturelle, 90);
            SetSkill(SkillName.Tactiques, 80);
            SetSkill(SkillName.Epee, 80);
            SetSkill(SkillName.Anatomie, 80);
            SetSkill(SkillName.Poursuite, 80);

        }

        public override int Hides { get { return 5; } }
        public override HideType HideType { get { return HideType.Volcanique; } }

        public Basilic(Serial serial)
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