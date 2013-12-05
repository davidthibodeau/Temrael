using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Corps d'Archange")]
    public class Archange : BaseCreature
    {
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

        public override double DispelDifficulty { get { return 125.0; } }
        public override double DispelFocus { get { return 45.0; } }

        [Constructable]
        public Archange()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Archange";
            Body = 124;

            SetStr(986, 1185);
            SetDex(177, 255);
            SetInt(151, 250);

            SetHits(700, 1400);

            SetDamage(30, 60);

            SetDamageType(ResistanceType.Physical, 50);
            SetDamageType(ResistanceType.Contondant, 25);
            SetDamageType(ResistanceType.Magie, 25);

            SetResistance(ResistanceType.Physical, 40, 60);
            SetResistance(ResistanceType.Contondant, 40, 60);
            SetResistance(ResistanceType.Tranchant, 40, 60);
            SetResistance(ResistanceType.Perforant, 40, 60);
            SetResistance(ResistanceType.Magie, 40, 60);

            //SetSkill( SkillName.Anatomy, 25.1, 50.0 );
            //SetSkill( SkillName.EvalInt, 90.1, 100.0 );
            SetSkill(SkillName.ArtMagique, 95.5, 100.0);
            SetSkill(SkillName.Concentration, 25.1, 50.0);
            SetSkill(SkillName.Concentration, 100.5, 150.0);
            SetSkill(SkillName.Tactiques, 90.1, 100.0);
            SetSkill(SkillName.ArmePoing, 90.1, 100.0);

            Fame = 24000;
            Karma = -24000;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich);
            AddLoot(LootPack.Rich);
            AddLoot(LootPack.MedScrolls, 2);
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
        public override bool CanRummageCorpses { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Deadly; } }
        //public override int TreasureMapLevel { get { return 5; } }
        public override int Meat { get { return 1; } }
        public override int Bones { get { return 18; } }
        public override int Hides { get { return 12; } }
        public override HideType HideType { get { return HideType.Magique; } }
        public override BoneType BoneType { get { return BoneType.Magique; } }

        public Archange(Serial serial)
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