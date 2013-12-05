using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Corps de Gazer Ancient")]
    public class AncientGazer : BaseCreature
    {
        public override bool InitialInnocent { get { return true; } }

        [Constructable]
        public AncientGazer()
            : base(AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4)
        {
            Name = "Ancient Gazer";
            Body = 78;
            BaseSoundID = 382;

            SetStr(96, 125);
            SetDex(86, 105);
            SetInt(141, 165);

            SetHits(200, 500);

            SetDamage(15, 25);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 30, 50);
            SetResistance(ResistanceType.Contondant, 30, 50);
            SetResistance(ResistanceType.Tranchant, 30, 50);
            SetResistance(ResistanceType.Perforant, 30, 50);
            SetResistance(ResistanceType.Magie, 30, 50);

            //SetSkill( SkillName.EvalInt, 50.1, 65.0 );
            SetSkill(SkillName.ArtMagique, 80.0, 105.0);
            SetSkill(SkillName.Concentration, 90.0, 125.0);
            SetSkill(SkillName.Tactiques, 70.0, 100.0);
            SetSkill(SkillName.ArmePoing, 80.0, 90.0);

            Fame = 3500;
            Karma = -3500;

            Tamable = true;
            ControlSlots = 5;
            MinTameSkill = 80.0;

            PackItem(new Nightshade(4));
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
            AddLoot(LootPack.Potions);
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
        public override int Meat { get { return 1; } }
        public override int Bones { get { return 3; } }
        public override int Hides { get { return 1; } }
        public override HideType HideType { get { return HideType.Ancien; } }
        public override BoneType BoneType { get { return BoneType.Ancien; } }

        public AncientGazer(Serial serial)
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