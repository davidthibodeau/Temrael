using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Corps d'Andariel")]
    public class Andariel : BaseCreature
    {
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

        [Constructable]
        public Andariel()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Andariel";
            Body = 176;

            SetStr(401, 430);
            SetDex(133, 152);
            SetInt(101, 140);

            SetHits(500, 800);

            SetDamage(30, 60);

            SetDamageType(ResistanceType.Physical, 80);
            SetDamageType(ResistanceType.Contondant, 20);

            SetResistance(ResistanceType.Physical, 30, 50);
            SetResistance(ResistanceType.Contondant, 30, 50);
            SetResistance(ResistanceType.Tranchant, 30, 50);
            SetResistance(ResistanceType.Perforant, 30, 50);
            SetResistance(ResistanceType.Magie, 30, 50);

            SetSkill(SkillName.Concentration, 65.1, 80.0);
            SetSkill(SkillName.Tactiques, 65.1, 90.0);
            SetSkill(SkillName.ArmePoing, 65.1, 80.0);

            Fame = 5500;
            Karma = -5500;

            PackReg(3);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
            //AddLoot(LootPack.MedScrolls, 2);
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
        public override bool ReacquireOnMovement { get { return true; } }
        public override bool HasBreath { get { return true; } } // fire breath enabled
        //public override int TreasureMapLevel { get { return 2; } }
        public override int Meat { get { return 10; } }

        public Andariel(Serial serial)
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