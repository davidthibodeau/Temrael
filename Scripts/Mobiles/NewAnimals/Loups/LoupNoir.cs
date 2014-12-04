using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de loup")]
    public class LoupNoir : BaseCreature
    {
        [Constructable]
        public LoupNoir()
            : base(AIType.AI_Melee, FightMode.Closest, 8, 1, 0.2, 0.4)
        {
            Name = "Loup Noir";
            Body = 225;
            Hue = 937;
            BaseSoundID = 229;

            PlayersAreEnemies = true;
            Direction = Direction.West;
            Hidden = true;

            SetStr(50);
            SetDex(50);
            SetInt(5);

            SetHits(185);
            SetMana(10);
            SetStam(80);
            SetArme(6, 10, 40);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magical, 0);

            SetSkill(SkillName.ArmureNaturelle, 50);
            SetSkill(SkillName.Tactiques, 50);
            SetSkill(SkillName.Epee, 50);
            SetSkill(SkillName.Infiltration, 50);


            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 50;

        }

        public override int Hides { get { return 3; } }
        public override HideType HideType { get { return HideType.Lupus; } }
        public override int Meat { get { return 2; } }
        public override MeatType MeatType { get { return MeatType.Ribs; } }

        public LoupNoir(Serial serial)
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