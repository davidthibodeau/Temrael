using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre d'ours")]
    public class OursGrizzly : BaseCreature
    {
        [Constructable]
        public OursGrizzly()
            : base(AIType.AI_Melee, FightMode.Closest, 9, 1, 0.2, 0.4)
        {
            Name = "Grizzli";
            Body = 212;
            Hue = 0;
            BaseSoundID = 163;

            PlayersAreEnemies = true;
            Direction = Direction.North;

            SetStr(150);
            SetDex(60);
            SetInt(5);

            SetHits(300);
            SetMana(10);
            SetStam(120);
            SetArme(10, 14, 50);

            SetResistance(ResistanceType.Physical, 15);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArmureNaturelle, 56);
            SetSkill(SkillName.Tactiques, 56);
            SetSkill(SkillName.Epee, 56);
            SetSkill(SkillName.Anatomie, 56);
            SetSkill(SkillName.Penetration, 16);


            Tamable = true;
            ControlSlots = 4;
            MinTameSkill = 80;

        }

        public override int Hides { get { return 4; } }
        public override HideType HideType { get { return HideType.Nordique; } }
        public override int Meat { get { return 4; } }
        public override MeatType MeatType { get { return MeatType.Ribs; } }

        public OursGrizzly(Serial serial)
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