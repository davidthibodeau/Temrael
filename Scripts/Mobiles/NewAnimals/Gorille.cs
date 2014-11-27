using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Mobiles.NewAnimals
{

    [CorpseName("Cadavre de gorille")]
    public class Gorille : BaseCreature
    {
        [Constructable]
        public Gorille()
            : base(AIType.AI_Melee, FightMode.Aggressor, 8, 1, 0.2, 0.4)
        {
            Name = "Gorille";
            Body = 29;
            BaseSoundID = 0x09F;

            PlayersAreEnemies = true;

            SetStr(30);
            SetDex(20);
            SetInt(5);

            SetHits(80);
            SetMana(10);
            SetStam(40);
            SetArme(4, 7, 40);

            SetResistance(ResistanceType.Physical, 0);
            SetResistance(ResistanceType.Magie, 0);

            SetSkill(SkillName.ArmureNaturelle, 46);
            SetSkill(SkillName.Tactiques, 46);
            SetSkill(SkillName.Epee, 46);
            SetSkill(SkillName.Anatomie, 22);


        }

        public override int Hide { get { return 3; } }
        public override HideType HideType { get { return HideType.Regular; } }

        public Gorille(Serial serial)
            : base(serial)
        {
        }

        public override int Meat { get { return 2; } }
        public override MeatType MeatType { get { return MeatType.Ribs; } }

        public Gorille(Serial serial)
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
