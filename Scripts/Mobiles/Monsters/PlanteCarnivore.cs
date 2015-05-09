    using System;
    using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de plante carnivore")]
    public class PlanteCarnivore : BaseCreature
    {
        [Constructable]
        public PlanteCarnivore()
            : base(AIType.AI_Melee, FightMode.Closest, 11, 1, 0.2, 0.4)
        {
            Name = "Plante Carnivore";
            Body = 161;
            BaseSoundID = 1302;

            PlayersAreEnemies = true;

            SetStr(120);
            SetDex(40);
            SetInt(25);

            SetHits(325);
            SetMana(20);
            SetStam(80);
            SetArme(12, 18, 50);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArmureNaturelle, 100);
            SetSkill(SkillName.Tactiques, 90);
            SetSkill(SkillName.Epee, 90);
            SetSkill(SkillName.Penetration, 60);
            SetSkill(SkillName.ResistanceMagique, 90);
            SetSkill(SkillName.Parer, 60);
            SetSkill(SkillName.Detection, 100);
            SetSkill(SkillName.CoupCritique, 50);


        }

        public override void GenerateLoot()
        {

            Emerald emerald = new Emerald(1);
            AddToBackpack(emerald);

            emerald = new Emerald(1);
            AddToBackpack(emerald);

            emerald = new Emerald(1);
            AddToBackpack(emerald);
        }


        public PlanteCarnivore(Serial serial)
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