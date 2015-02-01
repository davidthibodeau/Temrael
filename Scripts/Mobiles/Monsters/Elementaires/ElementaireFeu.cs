    using System;
    using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Cadavre d'élémentaire de feu")]
    public class ElementaireFeu : BaseCreature
    {
        [Constructable]
        public ElementaireFeu()
            : base(AIType.AI_Mage, FightMode.Closest, 11, 1, 0.2, 0.4)
        {
            Name = "Élémentaire de Feu";
            Body = 15;
            BaseSoundID = 273;

            PlayersAreEnemies = true;

            SetStr(120);
            SetDex(40);
            SetInt(25);

            SetHits(275);
            SetMana(50);
            SetStam(80);
            SetArme(13, 20, 40);

            SetResistance(ResistanceType.Physical, 20);
            SetResistance(ResistanceType.Magical, 50);

            SetSkill(SkillName.ArmureNaturelle, 80);
            SetSkill(SkillName.Tactiques, 80);
            SetSkill(SkillName.Epee, 80);
            SetSkill(SkillName.ArtMagique, 80);
            SetSkill(SkillName.Evocation, 80);
            SetSkill(SkillName.CoupCritique, 50);
            SetSkill(SkillName.MagieDeGuerre, 50);
        }

        public override void GenerateLoot()
        {

            Ruby Ruby = new Ruby(1);
            AddToBackpack(Ruby);

            Ruby = new Ruby(1);
            AddToBackpack(Ruby);

        }


        public ElementaireFeu(Serial serial)
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