using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Faucheur")]
    public class ReaperRedux : BaseCreature
    {
        [Constructable]
        public ReaperRedux()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.6, 1.2)
        {
            Name = "Faucheur";
            Body = 171;
            BaseSoundID = 445;

            SetStr(801, 900);
            SetDex(46, 65);
            SetInt(36, 50);

            SetHits(350, 700);
            SetMana(0);

            SetDamage(10, 20);

            SetDamageType(ResistanceType.Physical, 60);
            

            SetResistance(ResistanceType.Physical, 20, 40);
            
            
            
            SetResistance(ResistanceType.Magie, 20, 40);

            SetSkill(SkillName.Concentration, 90.1, 95.0);
            SetSkill(SkillName.Tactiques, 70.1, 85.0);
            SetSkill(SkillName.Anatomie, 65.1, 80.0);

            if (0.25 > Utility.RandomDouble())
                PackItem(new Board(10));
            else
                PackItem(new Log(10));

            PackReg(3);
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
        }

        public override bool BardImmune { get { return !Core.AOS; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }

        public ReaperRedux(Serial serial)
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