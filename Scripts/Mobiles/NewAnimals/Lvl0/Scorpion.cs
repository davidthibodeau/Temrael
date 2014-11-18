using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de scorpion")]
    public class Scorpion : BaseCreature
    {
        [Constructable]
        public Scorpion()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.3)
        {
            Name = "Un Scorpion";
            Body = 96;
            BaseSoundID = 397;

            SetStr(50);
            SetDex(15);
            SetInt(5);

            SetHits(10);
            SetMana(0);
            SetStam(30);

            SetArme(1, 5, 30);

            SetResistance(ResistanceType.Physical, 1, 5);
            SetResistance(ResistanceType.Magie, 1, 5);

            SetSkill(SkillName.Infiltration, 10.0);
            SetSkill(SkillName.Tactiques, 7.0);
            SetSkill(SkillName.Epee, 7.0);
            SetSkill(SkillName.Empoisonnement, 30.0);

            Poison = Poison.Lesser;
            Hidden = true;

            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 10;
        }

        public Scorpion(Serial serial)
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