    using System;
    using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Bélier géant")]
    public class BelierGeant : BaseCreature
    {
        [Constructable]
        public BelierGeant()
            : base(AIType.AI_Animal, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Bélier Géant";
            Body = 245;
            Hue = 0;
            BaseSoundID = 1011;

            PlayersAreEnemies = false;
            MaxRange = 1;

            SetStr(100);
            SetDex(100);
            SetInt(10);

            SetHits(300);
            SetMana(20);
            SetStam(250);
            SetArme(14, 22, 40);

            SetResistance(ResistanceType.Physical, 10);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.Detection, 90);
            SetSkill(SkillName.ArmureNaturelle, 90);
            SetSkill(SkillName.Tactiques, 90);
            SetSkill(SkillName.Epee, 90);
            SetSkill(SkillName.Anatomie, 90);
            SetSkill(SkillName.Parer, 80);
            SetSkill(SkillName.CoupCritique, 100);
        }

        public override int Hides { get { return 4; } }
        public override HideType HideType { get { return HideType.Geant; } }

        public BelierGeant(Serial serial)
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