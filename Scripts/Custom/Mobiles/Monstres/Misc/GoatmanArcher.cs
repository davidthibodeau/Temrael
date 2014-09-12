using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
    [CorpseName("Corps d'Homme-Chèvre")]
    public class GoatmanArcher : BaseCreature
    {
        [Constructable]
        public GoatmanArcher()
            : base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Homme-Chèvre Archer";
            Body = 178;

            SetStr(6, 10);
            SetDex(26, 38);
            SetInt(6, 14);

            SetHits(75, 125);
            SetMana(0);

            SetDamage(10, 15);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 0, 10);
            SetResistance(ResistanceType.Contondant, 0, 10);
            SetResistance(ResistanceType.Tranchant, 0, 10);
            SetResistance(ResistanceType.Perforant, 0, 10);
            SetResistance(ResistanceType.Magie, 0, 10);

            SetSkill(SkillName.Concentration, 5.1, 14.0);
            SetSkill(SkillName.Tactiques, 5.1, 10.0);
            SetSkill(SkillName.Anatomie, 5.1, 10.0);

            PackItem(new Arrow(Utility.RandomMinMax(1, 8))); // OSI it is different: in a sub backpack, this is probably just a limitation of their engine
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Poor);
        }

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
        public override int Meat { get { return 1; } }
        public override FoodType FavoriteFood { get { return FoodType.Meat; } }

        public GoatmanArcher(Serial serial)
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