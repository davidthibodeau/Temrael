using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de Cochon")]
    public class Cochon : BaseCreature
    {
        [Constructable]
        public Cochon()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.3)
        {
            Name = "Un Cochon";
            Body = 203;
            BaseSoundID = 196;

            SetStr(20);
            SetDex(15);
            SetInt(5);

            SetHits(40);
            SetMana(0);
            SetStam(30);

            SetArme(1, 4, 30);

            SetResistance(ResistanceType.Physical, 1, 5);
            SetResistance(ResistanceType.Magie, 1, 5);

            SetSkill(SkillName.Concentration, 4.0);
            SetSkill(SkillName.Tactiques, 7.0);
            SetSkill(SkillName.Epee, 7.0);

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 5;
        }

        public override int Meat { get { return 10; } }
        public override MeatType MeatType { get { return MeatType.Ribs; } }


        public Cochon(Serial serial)
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