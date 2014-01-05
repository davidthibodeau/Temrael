using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class Poignard : BaseKnife
    {
        public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Dague_Force1; } }
        public override int AosMinDamage { get { return Dague_MinDam1; } }
        public override int AosMaxDamage { get { return Dague_MaxDam1; } }
        public override double AosSpeed { get { return Dague_Vitesse; } }
        public override float MlSpeed { get { return 2.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 8; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 35; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Poignard()
            : base(0x2988)
        {
            Weight = 6.0;
            Name = "Poignard";
        }

        public Poignard(Serial serial)
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
    public class Dracourbe : BaseKnife
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Dague_Force6; } }
        public override int AosMinDamage { get { return Dague_MinDam6; } }
        public override int AosMaxDamage { get { return Dague_MaxDam6; } }
        public override double AosSpeed { get { return Dague_Vitesse; } }
        public override float MlSpeed { get { return 2.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 8; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 35; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Dracourbe()
            : base(0x2989)
        {
            Weight = 6.0;
            Name = "Dracourbe";
        }

        public Dracourbe(Serial serial)
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
    public class Ecorchette : BaseKnife
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Dague_Force6; } }
        public override int AosMinDamage { get { return Dague_MinDam6; } }
        public override int AosMaxDamage { get { return Dague_MaxDam6; } }
        public override double AosSpeed { get { return Dague_Vitesse; } }
        public override float MlSpeed { get { return 2.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 8; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 35; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Ecorchette()
            : base(0x298A)
        {
            Weight = 6.0;
            Name = "Ecorchette";
        }

        public Ecorchette(Serial serial)
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
    public class Safrine : BaseKnife
    {
        public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Dague_Force1; } }
        public override int AosMinDamage { get { return Dague_MinDam1; } }
        public override int AosMaxDamage { get { return Dague_MaxDam1; } }
        public override double AosSpeed { get { return Dague_Vitesse; } }
        public override float MlSpeed { get { return 2.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 8; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 35; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Safrine()
            : base(0x298B)
        {
            Weight = 6.0;
            Name = "Safrine";
        }

        public Safrine(Serial serial)
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
    public class Dentsombre : BaseKnife
    {
        public override int NiveauAttirail { get { return 2; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Dague_Force2; } }
        public override int AosMinDamage { get { return Dague_MinDam2; } }
        public override int AosMaxDamage { get { return Dague_MaxDam2; } }
        public override double AosSpeed { get { return Dague_Vitesse; } }
        public override float MlSpeed { get { return 2.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 8; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 35; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Dentsombre()
            : base(0x298C)
        {
            Weight = 6.0;
            Name = "Dentsombre";
        }

        public Dentsombre(Serial serial)
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
 /*3*/   public class Eblame : BaseKnife
    {
        public override int NiveauAttirail { get { return 3; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Dague_Force3; } }
        public override int AosMinDamage { get { return Dague_MinDam3; } }
        public override int AosMaxDamage { get { return Dague_MaxDam3; } }
        public override double AosSpeed { get { return Dague_Vitesse; } }
        public override float MlSpeed { get { return 2.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 8; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 35; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Eblame()
            : base(0x298D)
        {
            Weight = 6.0;
            Name = "Eblame";
        }

        public Eblame(Serial serial)
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
 /*3*/   public class Lozure : BaseKnife
    {
        public override int NiveauAttirail { get { return 3; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Dague_Force3; } }
        public override int AosMinDamage { get { return Dague_MinDam3; } }
        public override int AosMaxDamage { get { return Dague_MaxDam3; } }
        public override double AosSpeed { get { return Dague_Vitesse; } }
        public override float MlSpeed { get { return 2.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 8; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 35; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Lozure()
            : base(0x298E)
        {
            Weight = 6.0;
            Name = "Lozure";
        }

        public Lozure(Serial serial)
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
    public class Serpentine : BaseKnife
    {
        public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Dague_Force4; } }
        public override int AosMinDamage { get { return Dague_MinDam4; } }
        public override int AosMaxDamage { get { return Dague_MaxDam4; } }
        public override double AosSpeed { get { return Dague_Vitesse; } }
        public override float MlSpeed { get { return 2.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 8; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 35; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Serpentine()
            : base(0x298F)
        {
            Weight = 6.0;
            Name = "Serpentine";
        }

        public Serpentine(Serial serial)
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
    public class Brillaume : BaseKnife
    {
        public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Dague_Force5; } }
        public override int AosMinDamage { get { return Dague_MinDam5; } }
        public override int AosMaxDamage { get { return Dague_MaxDam5; } }
        public override double AosSpeed { get { return Dague_Vitesse; } }
        public override float MlSpeed { get { return 2.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 8; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 35; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Brillaume()
            : base(0x2990)
        {
            Weight = 6.0;
            Name = "Brillaume";
        }

        public Brillaume(Serial serial)
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
    public class Imperlame : BaseKnife
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Dague_Force6; } }
        public override int AosMinDamage { get { return Dague_MinDam6; } }
        public override int AosMaxDamage { get { return Dague_MaxDam6; } }
        public override double AosSpeed { get { return Dague_Vitesse; } }
        public override float MlSpeed { get { return 2.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 8; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 35; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Imperlame()
            : base(0x2991)
        {
            Weight = 6.0;
            Name = "Imperlame";
            Layer = Layer.OneHanded;
        }

        public Imperlame(Serial serial)
            : base(serial)
        {
            Layer = Layer.OneHanded;
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
 /*3*/   public class Basilarda : BaseKnife
    {
        public override int NiveauAttirail { get { return 3; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Dague_Force3; } }
        public override int AosMinDamage { get { return Dague_MinDam3; } }
        public override int AosMaxDamage { get { return Dague_MaxDam3; } }
        public override double AosSpeed { get { return Dague_Vitesse; } }
        public override float MlSpeed { get { return 2.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 8; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 35; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Basilarda()
            : base(0x2D1E)
        {
            Weight = 6.0;
            Name = "Basilarda";
        }

        public Basilarda(Serial serial)
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
    public class Osseuse : BaseKnife
    {
        public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Dague_Force4; } }
        public override int AosMinDamage { get { return Dague_MinDam4; } }
        public override int AosMaxDamage { get { return Dague_MaxDam4; } }
        public override double AosSpeed { get { return Dague_Vitesse; } }
        public override float MlSpeed { get { return 2.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 8; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 35; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Osseuse()
            : base(0x2D1F)
        {
            Weight = 6.0;
            Name = "Osseuse";
        }

        public Osseuse(Serial serial)
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
    public class Spadasine : BaseKnife
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Dague_Force6; } }
        public override int AosMinDamage { get { return Dague_MinDam6; } }
        public override int AosMaxDamage { get { return Dague_MaxDam6; } }
        public override double AosSpeed { get { return Dague_Vitesse; } }
        public override float MlSpeed { get { return 2.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 8; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 35; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Spadasine()
            : base(0x2D20)
        {
            Weight = 6.0;
            Name = "Spadasine";
        }

        public Spadasine(Serial serial)
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
    public class Elvine : BaseKnife
    {
        public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Dague_Force5; } }
        public override int AosMinDamage { get { return Dague_MinDam5; } }
        public override int AosMaxDamage { get { return Dague_MaxDam5; } }
        public override double AosSpeed { get { return Dague_Vitesse; } }
        public override float MlSpeed { get { return 2.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 8; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 35; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 70; } }

        [Constructable]
        public Elvine()
            : base(0x2D21)
        {
            Weight = 6.0;
            Name = "Elvine";
        }

        public Elvine(Serial serial)
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
