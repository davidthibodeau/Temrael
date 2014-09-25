using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class Percemurs : BaseArbalette
    {
        public override int EffectID { get { return 0x1BFE; } }
        public override Type AmmoType { get { return typeof(Bolt); } }
        public override Item Ammo { get { return new Bolt(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ConcussionBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int DefStrengthReq { get { return Arbalete_Force4; } }
        public override int DefMinDamage { get { return Arbalete_MinDam4; } }
        public override int DefMaxDamage { get { return Arbalete_MaxDam4; } }
        public override int DefSpeed { get { return Arbalete_Vitesse; } }

        public override int DefMaxRange { get { return 8; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public Percemurs()
            : base(0x29C1)
        {
            Weight = 7.0;
            Layer = Layer.TwoHanded;
            Name = "Percemurs";
        }

        public Percemurs(Serial serial)
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
    public class Arbavive : BaseArbalette
    {
        public override int EffectID { get { return 0x1BFE; } }
        public override Type AmmoType { get { return typeof(Bolt); } }
        public override Item Ammo { get { return new Bolt(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ConcussionBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int DefStrengthReq { get { return Arbalete_Force5; } }
        public override int DefMinDamage { get { return Arbalete_MinDam5; } }
        public override int DefMaxDamage { get { return Arbalete_MaxDam5; } }
        public override int DefSpeed { get { return Arbalete_Vitesse; } }

        public override int DefMaxRange { get { return 8; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public Arbavive()
            : base(0x29C2)
        {
            Weight = 7.0;
            Layer = Layer.TwoHanded;
            Name = "Arbavive";
        }

        public Arbavive(Serial serial)
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
    public class Lumitrait : BaseArbalette
    {
        public override int EffectID { get { return 0x1BFE; } }
        public override Type AmmoType { get { return typeof(Bolt); } }
        public override Item Ammo { get { return new Bolt(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ConcussionBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int DefStrengthReq { get { return Arbalete_Force6; } }
        public override int DefMinDamage { get { return Arbalete_MinDam6; } }
        public override int DefMaxDamage { get { return Arbalete_MaxDam6; } }
        public override int DefSpeed { get { return Arbalete_Vitesse; } }

        public override int DefMaxRange { get { return 8; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public Lumitrait()
            : base(0x29C0)
        {
            Weight = 7.0;
            Layer = Layer.TwoHanded;
            Name = "Lumitrait";
        }

        public Lumitrait(Serial serial)
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
    public class Arbalette : BaseArbalette
    {
        public override int EffectID { get { return 0x1BFE; } }
        public override Type AmmoType { get { return typeof(Bolt); } }
        public override Item Ammo { get { return new Bolt(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ConcussionBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int DefStrengthReq { get { return Arbalete_Force0; } }
        public override int DefMinDamage { get { return Arbalete_MinDam0; } }
        public override int DefMaxDamage { get { return Arbalete_MaxDam0; } }
        public override int DefSpeed { get { return Arbalete_Vitesse; } }

        public override int DefMaxRange { get { return 8; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public Arbalette()
            : base(0x3002)
        {
            Weight = 7.0;
            Layer = Layer.TwoHanded;
            Name = "Arbalette";
        }

        public Arbalette(Serial serial)
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
    public class ArbaletteLourde : BaseArbalette
    {
        public override int EffectID { get { return 0x1BFE; } }
        public override Type AmmoType { get { return typeof(Bolt); } }
        public override Item Ammo { get { return new Bolt(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ConcussionBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int DefStrengthReq { get { return Arbalete_Force1; } }
        public override int DefMinDamage { get { return Arbalete_MinDam1; } }
        public override int DefMaxDamage { get { return Arbalete_MaxDam1; } }
        public override int DefSpeed { get { return Arbalete_Vitesse; } }

        public override int DefMaxRange { get { return 8; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public ArbaletteLourde()
            : base(0x3003)
        {
            Weight = 7.0;
            Layer = Layer.TwoHanded;
            Name = "Arbalette Lourde";
        }

        public ArbaletteLourde(Serial serial)
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
    public class ArbaletteRepetition : BaseArbalette
    {
        public override int EffectID { get { return 0x1BFE; } }
        public override Type AmmoType { get { return typeof(Bolt); } }
        public override Item Ammo { get { return new Bolt(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ConcussionBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int DefStrengthReq { get { return Arbalete_Force3; } }
        public override int DefMinDamage { get { return Arbalete_MinDam3; } }
        public override int DefMaxDamage { get { return Arbalete_MaxDam3; } }
        public override int DefSpeed { get { return Arbalete_Vitesse; } }

        public override int DefMaxRange { get { return 8; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public ArbaletteRepetition()
            : base(0x303F)
        {
            Weight = 7.0;
            Layer = Layer.TwoHanded;
            Name = "Arbalette à Répétition";
        }

        public ArbaletteRepetition(Serial serial)
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
    public class ArbalettePistolet : BaseArbalette
    {
        public override int EffectID { get { return 0x1BFE; } }
        public override Type AmmoType { get { return typeof(Bolt); } }
        public override Item Ammo { get { return new Bolt(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ConcussionBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int DefStrengthReq { get { return Arbalete_Force5; } }
        public override int DefMinDamage { get { return Arbalete_MinDam5; } }
        public override int DefMaxDamage { get { return Arbalete_MaxDam5; } }
        public override int DefSpeed { get { return Arbalete_Vitesse; } }

        public override int DefMaxRange { get { return 8; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public ArbalettePistolet()
            : base(0x3040)
        {
            Weight = 7.0;
            Layer = Layer.TwoHanded;
            Name = "Arbalette à Main";
        }

        public ArbalettePistolet(Serial serial)
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
