using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a Vampire")]
    public class Vampire : BaseCreature
    {
        [Constructable]
        public Vampire()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Vampire";
            Body = 90;
            BaseSoundID = 0x3E9;

            SetStr(171, 200);
            SetDex(126, 145);
            SetInt(276, 305);

            SetHits(400, 800);

            SetDamage(20, 40);

            SetDamageType(ResistanceType.Physical, 10);
            
            SetDamageType(ResistanceType.Magie, 50);

            SetResistance(ResistanceType.Physical, 30, 50);
            
            
            
            SetResistance(ResistanceType.Magie, 30, 50);


            SetSkill(SkillName.Necromancie, 89, 99.1);
            //SetSkill( SkillName.SpiritSpeak, 90.0, 99.0 );

            //SetSkill( SkillName.EvalInt, 100.0 );
            SetSkill(SkillName.ArtMagique, 70.1, 80.0);
            SetSkill(SkillName.Concentration, 85.1, 95.0);
            SetSkill(SkillName.Concentration, 80.1, 100.0);
            SetSkill(SkillName.Tactiques, 70.1, 90.0);

        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
            //AddLoot(LootPack.MedScrolls, 2);
        }

        public override OppositionGroup OppositionGroup
        {
            get { return OppositionGroup.FeyAndUndead; }
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
        public override bool CanRummageCorpses { get { return true; } }
        public override bool BleedImmune { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
        public override int TreasureMapLevel { get { return 3; } }

        public Vampire(Serial serial)
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