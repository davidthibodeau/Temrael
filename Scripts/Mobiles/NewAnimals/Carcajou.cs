using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Mobiles.Animals
{
    [CorpseName("Cadavre de carcajou")]
    public class Carcajou : BaseCreature
    {
        [Constructable]
        public Carcajou()
            : base(AIType.AI_Animal, FightMode.Closest, 13, 1, 0.2, 0.4)
        {
            Name = "Carcajou";
            Body = 291;
            Hue = 2435;
            BaseSoundID = 115;

            PlayersAreEnemies = true;


            SetStr(110);
            SetDex(120);
            SetInt(5);

            SetHits(280);
            SetMana(10);
            SetStam(240);
            SetArme(13, 17, 40);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArmureNaturelle, 60);
            SetSkill(SkillName.Tactiques, 60);
            SetSkill(SkillName.Epee, 60);
            SetSkill(SkillName.Anatomie, 60);
            SetSkill(SkillName.ResistanceMagique, 40);


            Tamable = true;
            ControlSlots = 5;
            MinTameSkill = 100;

        }

        public override int Hides { get { return 5; } }
        public override HideType HideType { get { return HideType.Nordique; } }

        public Carcajou(Serial serial)
            : base(serial)
        {
        }

        public override int Meat { get { return 2; } }
        public override MeatType MeatType { get { return MeatType.Ribs; } }

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
