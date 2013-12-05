using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Corps de Tarenlune")]
    public class Tarenlune : BaseCreature
    {
        [Constructable]
        public Tarenlune()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Tarenlune";
            Body = 89;
            BaseSoundID = 1170;

            SetStr(196, 220);
            SetDex(126, 145);
            SetInt(286, 310);

            SetHits(500, 900);

            SetDamage(20, 40);

            SetDamageType(ResistanceType.Physical, 20);
            SetDamageType(ResistanceType.Perforant, 80);

            SetResistance(ResistanceType.Physical, 30, 50);
            SetResistance(ResistanceType.Contondant, 30, 50);
            SetResistance(ResistanceType.Tranchant, 30, 50);
            SetResistance(ResistanceType.Perforant, 30, 50);
            SetResistance(ResistanceType.Magie, 30, 50);

            SetSkill(SkillName.ArtMagique, 80.0, 100.0);
            SetSkill(SkillName.Concentration, 80.0, 100.0);
            SetSkill(SkillName.Tactiques, 70.0, 90.0);
            SetSkill(SkillName.ArmePoing, 70.0, 90.0);

            Fame = 5000;
            Karma = -5000;

            Tamable = true;
            ControlSlots = 5;
            MinTameSkill = 90.0;

            PackItem(new SpidersSilk(8));
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.0; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
        public override Poison HitPoison { get { return Poison.Lethal; } }
        //public override int TreasureMapLevel { get { return 3; } }
        public override int Bones { get { return 5; } }
        public override int Hides { get { return 5; } }
        public override HideType HideType { get { return HideType.Arachnide; } }
        public override BoneType BoneType { get { return BoneType.Arachnide; } }

        public Tarenlune(Serial serial)
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

            if (BaseSoundID == 263)
                BaseSoundID = 1170;
        }
    }
}