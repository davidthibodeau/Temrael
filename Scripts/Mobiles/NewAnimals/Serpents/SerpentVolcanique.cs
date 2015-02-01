    using System;
    using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de serpent volcanique")]
    public class SerpentVolcanique : BaseCreature
    {

        [Constructable]
        public SerpentVolcanique()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Serpent Volcanique";
            Body = 21;
            Hue = 2375;
            BaseSoundID = 219;

            PlayersAreEnemies = true;
            MaxRange = 1;

            SetStr(90);
            SetDex(120);
            SetInt(10);

            SetHits(250);
            SetMana(20);
            SetStam(250);
            SetArme(12, 17, 40, Poison.Regular);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.Empoisonnement, 90);
            SetSkill(SkillName.ArmureNaturelle, 90);
            SetSkill(SkillName.Tactiques, 80);
            SetSkill(SkillName.Epee, 80);
            SetSkill(SkillName.Anatomie, 80);
            SetSkill(SkillName.CoupCritique, 80);
        }


        public override int Hides { get { return 5; } }
        public override HideType HideType { get { return HideType.Volcanique; } }

        public SerpentVolcanique(Serial serial)
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