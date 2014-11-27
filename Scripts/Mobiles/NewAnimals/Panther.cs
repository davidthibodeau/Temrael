using System;
using Server.Mobiles;

namespace Server.Mobiles
{           
    [CorpseName("un corps de panthere")]
    public class Panthere : BaseCreature
    {
        [Constructable]
        public Panthere()
            : base(AIType.AI_Thief, FightMode.Aggressor, 8, 1, 0.2, 0.4)
        {
            Name = "Une panthere";

            PlayersAreEnemies = true;
            Direction = Direction.West;
            Hidden = true;

            SetStr(45);
            SetDex(40);
            SetInt(5);

            SetHits(175);
            SetMana(10);
            SetStam(80);
            SetArme(5, 9, 40);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.ArmureNaturelle, 48);
            SetSkill(SkillName.Tactiques, 48);
            SetSkill(SkillName.Epee, 48);
            SetSkill(SkillName.Infiltration, 36);


            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 40;

        }

        public override int Hides { get { return 2; } }
        public override HideType HideType { get { return HideType.Regular; } }

        public override int Meat { get { return 2; } }
        public override MeatType MeatType { get { return MeatType.Ribs; } }

        public Panthere(Serial serial)
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