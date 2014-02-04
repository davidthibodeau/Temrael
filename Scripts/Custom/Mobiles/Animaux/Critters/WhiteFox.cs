using System;
using System.Collections;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Items;
using Server.ContextMenus;

namespace Server.Mobiles
{
    [CorpseName("Corps de renard polaire")]
    public class WhiteFox : BaseCreature
    {
        [Constructable]
        public WhiteFox()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Renard polaire";
            Body = 2059;
            //BaseSoundID = 0xA8;

            SetStr(10);
            SetDex(25, 35);
            SetInt(10);

            SetDamage(1);

            SetDamageType(ResistanceType.Physical, 100);

            SetSkill(SkillName.ArmePoing, 4.2, 6.4);
            SetSkill(SkillName.Tactiques, 4.0, 6.0);
            SetSkill(SkillName.Concentration, 4.0, 5.0);

            Fame = 0;
            Karma = 200;

            VirtualArmor = 10;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 5.0;
        }

        public override double AttackSpeed { get { return 2.0; } }
        public override int Meat { get { return 3; } }
        public override int Hides { get { return 1; } }
        public override HideType HideType { get { return HideType.Nordique; } }
        public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

        public WhiteFox(Serial serial)
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