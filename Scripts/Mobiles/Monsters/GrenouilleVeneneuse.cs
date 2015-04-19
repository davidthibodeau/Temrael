    using System;
    using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de grenouille")]
    public class GrenouilleVeneneuse : BaseCreature
    {
        [Constructable]
        public GrenouilleVeneneuse()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Grenouille Vénéneuse";
            Body = 80;
            Hue = 0;
            BaseSoundID = 614;

            PlayersAreEnemies = false;
            MaxRange = 1;

            SetStr(90);
            SetDex(120);
            SetInt(10);

            SetHits(200);
            SetMana(20);
            SetStam(250);
            SetArme(10, 16, 40, Poison.Greater);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.Empoisonnement, 95);
            SetSkill(SkillName.ArmureNaturelle, 50);
            SetSkill(SkillName.Tactiques, 90);
            SetSkill(SkillName.Epee, 90);
            SetSkill(SkillName.Anatomie, 50);
            SetSkill(SkillName.Detection, 100);
            SetSkill(SkillName.ResistanceMagique, 50);

        }


        public override void GenerateLoot()
        {
        }

        public override int Hides { get { return 3; } }
        public override HideType HideType { get { return HideType.Maritime; } }

        public GrenouilleVeneneuse(Serial serial)
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