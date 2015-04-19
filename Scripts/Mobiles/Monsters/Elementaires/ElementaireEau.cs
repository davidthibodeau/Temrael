    using System;
    using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Cadavre d'élémentaire d'eau")]
    public class ElementaireEau : BaseCreature
    {
        [Constructable]
        public ElementaireEau()
            : base(AIType.AI_Melee, FightMode.Closest, 11, 1, 0.2, 0.4)
        {
            Name = "Élémentaire d'eau";
            Body = 254;
            BaseSoundID = 279;

            PlayersAreEnemies = true;

            SetStr(120);
            SetDex(40);
            SetInt(25);

            SetHits(325);
            SetMana(50);
            SetStam(80);
            SetArme(12, 18, 50);

            SetResistance(ResistanceType.Physical, 40);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArmureNaturelle, 100);
            SetSkill(SkillName.Tactiques, 85);
            SetSkill(SkillName.Epee, 85);
            SetSkill(SkillName.Penetration, 50);
            SetSkill(SkillName.ResistanceMagique, 85);
            SetSkill(SkillName.Parer, 60);
            SetSkill(SkillName.Detection, 85);
            SetSkill(SkillName.CoupCritique, 50);


        }

        public override void GenerateLoot()
        {

            Sapphire Sapphire = new Sapphire(1);
            AddToBackpack(Sapphire);

            Sapphire = new Sapphire(1);
            AddToBackpack(Sapphire);

        }


        public ElementaireEau(Serial serial)
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