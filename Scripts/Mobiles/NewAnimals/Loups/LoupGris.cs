using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de loup")]
    public class LoupGris : BaseCreature
    {
        [Constructable]
        public LoupGris()
            : base(AIType.AI_Thief, FightMode.Closest, 8, 1, 0.2, 0.4)
        {
            Name = "Loup Gris";
            Body = 225;
            Hue = 960;
            BaseSoundID = 229;

            PlayersAreEnemies = true;
            Direction = Direction.West;
            Hidden = true;

            SetStr(45);
            SetDex(40);
            SetInt(5);

            SetHits(90);
            SetMana(10);
            SetStam(80);
            SetArme(5, 8, 40);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.ArmureNaturelle, 48);
            SetSkill(SkillName.Tactiques, 48);
            SetSkill(SkillName.Epee, 48);
            SetSkill(SkillName.Infiltration, 36);


            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 20;

        }

        public override int Hides { get { return 2; } }
        public override HideType HideType { get { return HideType.Lupus; } }
        public override int Meat { get { return 2; } }
        public override MeatType MeatType { get { return MeatType.Ribs; } }

        public LoupGris(Serial serial)
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