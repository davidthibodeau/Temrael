using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class Griffes : BaseKatar
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force1; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam1; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam1; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Griffes()
            : base(0x295C)
        {
            Weight = 6.0;
            Name = "Griffes";
        }

        public Griffes(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
    public class Katar : BaseKatar
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force3; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam3; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam3; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Katar()
            : base(0x295D)
        {
            Weight = 6.0;
            Name = "Katar";
        }

        public Katar(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
    public class Katara : BaseKatar
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force6; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam6; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam6; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Katara()
            : base(0x295E)
        {
            Weight = 6.0;
            Name = "Katara";
        }

        public Katara(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
