using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre d'ours")]
    public class OursNoir : BaseCreature
    {
        [Constructable]
        public OursNoir()
            : base(AIType.AI_Melee, FightMode.Closest, 9, 1, 0.2, 0.4)
        {
            Name = "Ours Noir";
            Body = 211;
            Hue = 0;
            BaseSoundID = 163;

            PlayersAreEnemies = true;
            Direction = Direction.North;

            SetStr(150);
            SetDex(60);
            SetInt(5);

            SetHits(200);
            SetMana(10);
            SetStam(120);
            SetArme(8, 12, 50);

            SetResistance(ResistanceType.Physical, 15);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArmureNaturelle, 52);
            SetSkill(SkillName.Tactiques, 52);
            SetSkill(SkillName.Epee, 52);
            SetSkill(SkillName.Anatomie, 52);
            SetSkill(SkillName.Penetration, 10);


            Tamable = true;
            ControlSlots = 4;
            MinTameSkill = 60;

        }

        public override int Hides { get { return 12; } }
        public override HideType HideType { get { return HideType.Regular; } }
        public override int Meat { get { return 6; } }
        public override MeatType MeatType { get { return MeatType.Ribs; } }

        public OursNoir(Serial serial)
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