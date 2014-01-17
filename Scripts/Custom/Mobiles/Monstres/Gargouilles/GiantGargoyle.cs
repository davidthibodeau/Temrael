using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Corps de Roi Gargouille")]
    public class GiantGargoyle : BaseCreature
    {
        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.WhirlwindAttack;
        }

        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

        [Constructable]
        public GiantGargoyle()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Roi Gargouille";
            Body = 69;
            BaseSoundID = 0x174;

            SetStr(850, 950);
            SetDex(150, 200);
            SetInt(152, 200);

            SetHits(1000, 2000);

            SetDamage(40, 80);

            SetResistance(ResistanceType.Physical, 50, 70);
            SetResistance(ResistanceType.Contondant, 50, 70);
            SetResistance(ResistanceType.Tranchant, 50, 70);
            SetResistance(ResistanceType.Perforant, 50, 70);
            SetResistance(ResistanceType.Magie, 50, 70);

            SetSkill(SkillName.Tactiques, 110.0, 160.0);
            SetSkill(SkillName.ArmePoing, 120.0, 150.0);
            SetSkill(SkillName.ArmeTranchante, 80.1, 90.0);
            //SetSkill( SkillName.Anatomy, 70.1, 80.0 );
            SetSkill(SkillName.ArtMagique, 100.0, 120.0);
            //SetSkill( SkillName.EvalInt, 70.3, 100.0 );
            SetSkill(SkillName.Concentration, 90.0, 130.0);

            Fame = 5000;
            Karma = -5000;

            PackItem(new EclatDeVolcan(5));
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich);
            //AddLoot(LootPack.HighScrolls);
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 4.0; } }
        public override int Meat { get { return 1; } }
        public override int Bones { get { return 18; } }
        public override int Hides { get { return 22; } }
        public override HideType HideType { get { return HideType.Volcanique; } }
        public override BoneType BoneType { get { return BoneType.Volcanique; } }

        public GiantGargoyle(Serial serial)
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