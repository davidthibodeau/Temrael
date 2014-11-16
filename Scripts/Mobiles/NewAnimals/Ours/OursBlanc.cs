using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre d'ours")]
    public class OursBlanc : BaseCreature
    {
        [Constructable]
        public OursBlanc()
            : base(AIType.AI_Melee, FightMode.Closest, 9, 1, 0.2, 0.4)
        {
            Name = "Ours Blanc";
            Body = 213;
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
            SetArme(10, 15, 40);

            SetResistance(ResistanceType.Physical, 15);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.ArmureNaturelle, 60);
            SetSkill(SkillName.Tactiques, 60);
            SetSkill(SkillName.Epee, 60);
            SetSkill(SkillName.Anatomie, 60);
            SetSkill(SkillName.ResistanceMagique, 40);


            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 45;

        }

        public override int Hides { get { return 8; } }
        public override HideType HideType { get { return HideType.Nordique; } }
        public override int Meat { get { return 20; } }
        public override MeatType MeatType { get { return MeatType.Ribs; } }

        public OursBlanc(Serial serial)
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