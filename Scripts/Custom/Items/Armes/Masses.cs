using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class Fleau : BaseBashing
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ShadowStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Masse_Force5; } }
        public override int AosMinDamage { get { return Masse_MinDam5; } }
        public override int AosMaxDamage { get { return Masse_MaxDam5; } }
        public override double AosSpeed { get { return Masse_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 40; } }

        [Constructable]
        public Fleau()
            : base(0x295F)
        {
            Weight = 9.0;
            Name = "Fleau";
        }

        public Fleau(Serial serial)
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
    public class Granmace : BaseBashing
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ShadowStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Masse_Force4; } }
        public override int AosMinDamage { get { return Masse_MinDam4; } }
        public override int AosMaxDamage { get { return Masse_MaxDam4; } }
        public override double AosSpeed { get { return Masse_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 40; } }

        [Constructable]
        public Granmace()
            : base(0x2960)
        {
            Weight = 9.0;
            Name = "Granmace";
        }

        public Granmace(Serial serial)
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
    public class Batonmace : BaseBashing
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ShadowStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return 40; } }
        public override int AosMinDamage { get { return 11; } }
        public override int AosMaxDamage { get { return 13; } }
        public override double AosSpeed { get { return 44; } }
        public override float MlSpeed { get { return 2.50f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 40; } }

        [Constructable]
        public Batonmace()
            : base(0x2961)
        {
            Weight = 9.0;
            Name = "Batonmace";
        }

        public Batonmace(Serial serial)
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
    public class Brisecrane : BaseBashing
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ShadowStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Masse_Force3; } }
        public override int AosMinDamage { get { return Masse_MinDam3; } }
        public override int AosMaxDamage { get { return Masse_MaxDam3; } }
        public override double AosSpeed { get { return Masse_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 40; } }

        [Constructable]
        public Brisecrane()
            : base(0x2962)
        {
            Weight = 9.0;
            Name = "Brisecrane";
        }

        public Brisecrane(Serial serial)
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
    public class Defonceur : BaseBashing
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ShadowStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Masse_Force6; } }
        public override int AosMinDamage { get { return Masse_MinDam6; } }
        public override int AosMaxDamage { get { return Masse_MaxDam6; } }
        public override double AosSpeed { get { return Masse_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 40; } }

        [Constructable]
        public Defonceur()
            : base(0x2963)
        {
            Weight = 9.0;
            Name = "Defonceur";
        }

        public Defonceur(Serial serial)
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
    public class Ecraseface : BaseBashing
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ShadowStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Masse_Force5; } }
        public override int AosMinDamage { get { return Masse_MinDam5; } }
        public override int AosMaxDamage { get { return Masse_MaxDam5; } }
        public override double AosSpeed { get { return Masse_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 40; } }

        [Constructable]
        public Ecraseface()
            : base(0x2964)
        {
            Weight = 9.0;
            Name = "Ecraseface";
        }

        public Ecraseface(Serial serial)
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
    public class Gourdin : BaseBashing
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ShadowStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return 40; } }
        public override int AosMinDamage { get { return 11; } }
        public override int AosMaxDamage { get { return 13; } }
        public override double AosSpeed { get { return 44; } }
        public override float MlSpeed { get { return 2.50f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 40; } }

        [Constructable]
        public Gourdin()
            : base(0x2965)
        {
            Weight = 9.0;
            Name = "Gourdin";
        }

        public Gourdin(Serial serial)
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
    public class Gourpic : BaseBashing
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ShadowStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return 40; } }
        public override int AosMinDamage { get { return 11; } }
        public override int AosMaxDamage { get { return 13; } }
        public override double AosSpeed { get { return 44; } }
        public override float MlSpeed { get { return 2.50f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 40; } }

        [Constructable]
        public Gourpic()
            : base(0x2966)
        {
            Weight = 9.0;
            Name = "Gourpic";
        }

        public Gourpic(Serial serial)
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
    public class Malert : BaseBashing
    {
        //public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ShadowStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Marteau_Force6; } }
        public override int AosMinDamage { get { return Marteau_MinDam6; } }
        public override int AosMaxDamage { get { return Marteau_MaxDam6; } }
        public override double AosSpeed { get { return Marteau_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 40; } }

        [Constructable]
        public Malert()
            : base(0x317C)
        {
            Weight = 9.0;
            Name = "Gourpic";
            Layer = Layer.TwoHanded;
        }

        public Malert(Serial serial)
            : base(serial)
        {
            Layer = Layer.TwoHanded;
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
    public class Massue : BaseBashing
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ShadowStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Masse_Force4; } }
        public override int AosMinDamage { get { return Masse_MinDam4; } }
        public override int AosMaxDamage { get { return Masse_MaxDam4; } }
        public override double AosSpeed { get { return Masse_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 40; } }

        [Constructable]
        public Massue()
            : base(0x3043)
        {
            Weight = 9.0;
            Name = "Massue";
        }

        public Massue(Serial serial)
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
    public class Ecracheur : BaseBashing
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ShadowStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Masse_Force5; } }
        public override int AosMinDamage { get { return Masse_MinDam5; } }
        public override int AosMaxDamage { get { return Masse_MaxDam5; } }
        public override double AosSpeed { get { return Masse_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 40; } }

        [Constructable]
        public Ecracheur()
            : base(0x3044)
        {
            Weight = 9.0;
            Name = "Ecracheur";
        }

        public Ecracheur(Serial serial)
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
    public class MarteauGuerre : BaseBashing
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ShadowStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Marteau_Force5; } }
        public override int AosMinDamage { get { return Marteau_MinDam5; } }
        public override int AosMaxDamage { get { return Marteau_MaxDam5; } }
        public override double AosSpeed { get { return Marteau_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 40; } }

        [Constructable]
        public MarteauGuerre()
            : base(0x3045)
        {
            Weight = 9.0;
            Name = "Marteau de Guerre";
            Layer = Layer.TwoHanded;
        }

        public MarteauGuerre(Serial serial)
            : base(serial)
        {
            Layer = Layer.TwoHanded;
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
    public class Broyeur : BaseBashing
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ShadowStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Masse_Force6; } }
        public override int AosMinDamage { get { return Masse_MinDam6; } }
        public override int AosMaxDamage { get { return Masse_MaxDam6; } }
        public override double AosSpeed { get { return Masse_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 40; } }

        [Constructable]
        public Broyeur()
            : base(0x3046)
        {
            Weight = 9.0;
            Name = "Broyeur";
        }

        public Broyeur(Serial serial)
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