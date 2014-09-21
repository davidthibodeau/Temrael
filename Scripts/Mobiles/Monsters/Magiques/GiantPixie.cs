using System;
using Server;
using Server.Misc;

namespace Server.Mobiles
{
    [CorpseName("Pixie Géante")]
    public class GiantPixie : BaseCreature
    {
        public override bool InitialInnocent { get { return true; } }

        [Constructable]
        public GiantPixie()
            : base(AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4)
        {
            Name = "Pixie Géante";
            Body = 46;
            BaseSoundID = 0x467;

            SetStr(21, 30);
            SetDex(301, 400);
            SetInt(201, 250);

            SetHits(400, 800);

            SetDamage(20, 40);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 30, 50);
            
            
            
            SetResistance(ResistanceType.Magie, 30, 50);

            //SetSkill( SkillName.EvalInt, 90.1, 100.0 );
            SetSkill(SkillName.ArtMagique, 90.1, 100.0);
            SetSkill(SkillName.Concentration, 90.1, 100.0);
            SetSkill(SkillName.Concentration, 100.5, 150.0);
            SetSkill(SkillName.Tactiques, 10.1, 20.0);
            SetSkill(SkillName.Anatomie, 10.1, 12.5);

            Tamable = true;
            ControlSlots = 8;
            MinTameSkill = 90.0;
        }

        public override void GenerateLoot()
        {
            //AddLoot(LootPack.LowScrolls);
            AddLoot(LootPack.Rich);
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
        public override int Meat { get { return 1; } }
        public override int Bones { get { return 3; } }
        public override int Hides { get { return 9; } }
        public override HideType HideType { get { return HideType.Magique; } }
        public override BoneType BoneType { get { return BoneType.Magique; } }

        public GiantPixie(Serial serial)
            : base(serial)
        {
        }

        public override OppositionGroup OppositionGroup
        {
            get { return OppositionGroup.FeyAndUndead; }
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