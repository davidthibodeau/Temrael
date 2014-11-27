using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de loup")]
    public class LoupBrun : BaseCreature
    {
        [Constructable]
        public LoupBrun()
            : base(AIType.AI_Melee, FightMode.Closest, 8, 1, 0.2, 0.4)
        {
            Name = "Loup Brun";
            Body = 225;
            BaseSoundID = 229;

            PlayersAreEnemies = true;
            Direction = Direction.West;

            SetStr(30);
            SetDex(20);
            SetInt(5);

            SetHits(150);
            SetMana(10);
            SetStam(40);
            SetArme(4, 8, 40);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.ArmureNaturelle, 46);
            SetSkill(SkillName.Tactiques, 46);
            SetSkill(SkillName.Epee, 46);
            SetSkill(SkillName.Anatomie, 22);

            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 30;

        }

        public override int Hides { get { return 2; } }
        public override HideType HideType { get { return HideType.Lupus; } }
        public override int Meat { get { return 2; } }
        public override MeatType MeatType { get { return MeatType.Ribs; } }

        public LoupBrun(Serial serial)
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