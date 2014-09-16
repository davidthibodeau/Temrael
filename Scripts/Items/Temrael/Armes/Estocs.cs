using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class Estoc : BaseKnife
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Rapiere_Force5; } }
        public override int AosMinDamage { get { return Rapiere_MinDam5; } }
        public override int AosMaxDamage { get { return Rapiere_MaxDam5; } }
        public override int DefSpeed { get { return Rapiere_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Estoc()
            : base(0x2992)
        {
            Weight = 6.0;
            Name = "Estoc";
        }

        public Estoc(Serial serial)
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
    public class Brette : BaseKnife
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Rapiere_Force6; } }
        public override int AosMinDamage { get { return Rapiere_MinDam6; } }
        public override int AosMaxDamage { get { return Rapiere_MaxDam6; } }
        public override int DefSpeed { get { return Rapiere_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Brette()
            : base(0x2993)
        {
            Weight = 6.0;
            Name = "Brette";
        }

        public Brette(Serial serial)
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
    public class Fleuret : BaseKnife
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Rapiere_Force0; } }
        public override int AosMinDamage { get { return Rapiere_MinDam0; } }
        public override int AosMaxDamage { get { return Rapiere_MaxDam0; } }
        public override int DefSpeed { get { return Rapiere_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Fleuret()
            : base(0x2994)
        {
            Weight = 6.0;
            Name = "Fleuret";
        }

        public Fleuret(Serial serial)
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
    public class Rapiere : BaseKnife
    {
        //public override int NiveauAttirail { get { return 2; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Rapiere_Force2; } }
        public override int AosMinDamage { get { return Rapiere_MinDam2; } }
        public override int AosMaxDamage { get { return Rapiere_MaxDam2; } }
        public override int DefSpeed { get { return Rapiere_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Rapiere()
            : base(0x2995)
        {
            Weight = 6.0;
            Name = "Rapiere";
        }

        public Rapiere(Serial serial)
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
    public class Lyzardese : BaseKnife
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Rapiere_Force4; } }
        public override int AosMinDamage { get { return Rapiere_MinDam4; } }
        public override int AosMaxDamage { get { return Rapiere_MaxDam4; } }
        public override int DefSpeed { get { return Rapiere_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Lyzardese()
            : base(0x2996)
        {
            Weight = 6.0;
            Name = "Lyzardese";
        }

        public Lyzardese(Serial serial)
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
    public class Musareche : BaseKnife
    {
        //public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Rapiere_Force6; } }
        public override int AosMinDamage { get { return Rapiere_MinDam6; } }
        public override int AosMaxDamage { get { return Rapiere_MaxDam6; } }
        public override int DefSpeed { get { return Rapiere_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Musareche()
            : base(0x2997)
        {
            Weight = 6.0;
            Name = "Musareche";
        }

        public Musareche(Serial serial)
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
    public class Percille : BaseKnife
    {
        //public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Rapiere_Force1; } }
        public override int AosMinDamage { get { return Rapiere_MinDam1; } }
        public override int AosMaxDamage { get { return Rapiere_MaxDam1; } }
        public override int DefSpeed { get { return Rapiere_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Percille()
            : base(0x2998)
        {
            Weight = 6.0;
            Name = "Percille";
        }

        public Percille(Serial serial)
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
    public class Cuivardise : BaseKnife
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Rapiere_Force3; } }
        public override int AosMinDamage { get { return Rapiere_MinDam3; } }
        public override int AosMaxDamage { get { return Rapiere_MaxDam3; } }
        public override int DefSpeed { get { return Rapiere_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Cuivardise()
            : base(0x2999)
        {
            Weight = 6.0;
            Name = "Cuivardise";
        }

        public Cuivardise(Serial serial)
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
