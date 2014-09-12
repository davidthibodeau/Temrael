using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class CanneOsseux : BaseStaff
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Baton_Force1; } }
        public override int AosMinDamage { get { return Baton_MinDam1; } }
        public override int AosMaxDamage { get { return Baton_MaxDam1; } }
        public override int DefSpeed { get { return Baton_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public CanneOsseux()
            : base(0x29C3)
        {
            Weight = 6.0;
            Name = "Canne Osseuse";
        }

        public CanneOsseux(Serial serial)
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
    public class Canne : BaseStaff
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Baton_Force0; } }
        public override int AosMinDamage { get { return Baton_MinDam0; } }
        public override int AosMaxDamage { get { return Baton_MaxDam0; } }
        public override int DefSpeed { get { return Baton_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Canne()
            : base(0x29C4)
        {
            Weight = 6.0;
            Name = "Canne";
        }

        public Canne(Serial serial)
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
    public class BatonTenebrea : BaseStaff
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Baton_Force1; } }
        public override int AosMinDamage { get { return Baton_MinDam1; } }
        public override int AosMaxDamage { get { return Baton_MaxDam1; } }
        public override int DefSpeed { get { return Baton_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public BatonTenebrea()
            : base(0x29C5)
        {
            Weight = 6.0;
            Name = "Baton Tenebrea";
        }

        public BatonTenebrea(Serial serial)
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
    public class BatonSoleil : BaseStaff
    {
        //public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Baton_Force1; } }
        public override int AosMinDamage { get { return Baton_MinDam1; } }
        public override int AosMaxDamage { get { return Baton_MaxDam1; } }
        public override int DefSpeed { get { return Baton_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public BatonSoleil()
            : base(0x29C6)
        {
            Weight = 6.0;
            Name = "Baton Soleil";
        }

        public BatonSoleil(Serial serial)
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
    public class BatonThaumaturge : BaseStaff
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Baton_Force1; } }
        public override int AosMinDamage { get { return Baton_MinDam1; } }
        public override int AosMaxDamage { get { return Baton_MaxDam1; } }
        public override int DefSpeed { get { return Baton_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public BatonThaumaturge()
            : base(0x29C7)
        {
            Weight = 6.0;
            Name = "Baton de Thaumaturgiste";
        }

        public BatonThaumaturge(Serial serial)
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
    public class BatonOsseux : BaseStaff
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Baton_Force1; } }
        public override int AosMinDamage { get { return Baton_MinDam1; } }
        public override int AosMaxDamage { get { return Baton_MaxDam1; } }
        public override int DefSpeed { get { return Baton_Vitesse; } }
        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public BatonOsseux()
            : base(0x29C8)
        {
            Weight = 6.0;
            Name = "Baton Osseux";
        }

        public BatonOsseux(Serial serial)
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
    public class BatonDruide : BaseStaff
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Baton_Force1; } }
        public override int AosMinDamage { get { return Baton_MinDam1; } }
        public override int AosMaxDamage { get { return Baton_MaxDam1; } }
        public override int DefSpeed { get { return Baton_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public BatonDruide()
            : base(0x29C9)
        {
            Weight = 6.0;
            Name = "Baton Druidique";
        }

        public BatonDruide(Serial serial)
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
    public class BatonVoyage : BaseStaff
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Baton_Force1; } }
        public override int AosMinDamage { get { return Baton_MinDam1; } }
        public override int AosMaxDamage { get { return Baton_MaxDam1; } }
        public override int DefSpeed { get { return Baton_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public BatonVoyage()
            : base(0x29CB)
        {
            Weight = 6.0;
            Name = "Baton de Voyage";
        }

        public BatonVoyage(Serial serial)
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
    public class Eteurfer : BaseStaff
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Baton_Force1; } }
        public override int AosMinDamage { get { return Baton_MinDam1; } }
        public override int AosMaxDamage { get { return Baton_MaxDam1; } }
        public override int DefSpeed { get { return Baton_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Eteurfer()
            : base(0x29CC)
        {
            Weight = 6.0;
            Name = "Eteurfer";
        }

        public Eteurfer(Serial serial)
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
    public class Boulnar : BaseStaff
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Baton_Force1; } }
        public override int AosMinDamage { get { return Baton_MinDam1; } }
        public override int AosMaxDamage { get { return Baton_MaxDam1; } }
        public override int DefSpeed { get { return Baton_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Boulnar()
            : base(0x29CD)
        {
            Weight = 6.0;
            Name = "Boulnar";
        }

        public Boulnar(Serial serial)
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
    public class Seliphore : BaseStaff
    {
        //public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Baton_Force1; } }
        public override int AosMinDamage { get { return Baton_MinDam1; } }
        public override int AosMaxDamage { get { return Baton_MaxDam1; } }
        public override int DefSpeed { get { return Baton_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Seliphore()
            : base(0x29CE)
        {
            Weight = 6.0;
            Name = "Seliphore";
        }

        public Seliphore(Serial serial)
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
    public class Crochire : BaseStaff
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Baton_Force1; } }
        public override int AosMinDamage { get { return Baton_MinDam1; } }
        public override int AosMaxDamage { get { return Baton_MaxDam1; } }
        public override int DefSpeed { get { return Baton_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Crochire()
            : base(0x29CF)
        {
            Weight = 6.0;
            Name = "Crochire";
        }

        public Crochire(Serial serial)
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
    public class BatonElfique : BaseStaff
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Baton_Force1; } }
        public override int AosMinDamage { get { return Baton_MinDam1; } }
        public override int AosMaxDamage { get { return Baton_MaxDam1; } }
        public override int DefSpeed { get { return Baton_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public BatonElfique()
            : base(0x2894)
        {
            Weight = 6.0;
            Name = "Baton Elfique";
        }

        public BatonElfique(Serial serial)
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
    public class BatonElement : BaseStaff
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Baton_Force1; } }
        public override int AosMinDamage { get { return Baton_MinDam1; } }
        public override int AosMaxDamage { get { return Baton_MaxDam1; } }
        public override int DefSpeed { get { return Baton_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public BatonElement()
            : base(0x317D)
        {
            Weight = 6.0;
            Name = "Baton d'Elementaliste";
        }

        public BatonElement(Serial serial)
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
    public class BatonSorcier : BaseStaff
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Baton_Force1; } }
        public override int AosMinDamage { get { return Baton_MinDam1; } }
        public override int AosMaxDamage { get { return Baton_MaxDam1; } }
        public override int DefSpeed { get { return Baton_Vitesse; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public BatonSorcier()
            : base(0x317E)
        {
            Weight = 6.0;
            Name = "Baton de Sorcier";
        }

        public BatonSorcier(Serial serial)
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