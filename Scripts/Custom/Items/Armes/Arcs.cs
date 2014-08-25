using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class Legarc : BaseRanged
    {
        //public override int NiveauAttirail { get { return 1; } }

        public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType{ get{ return typeof( Arrow ); } }
		public override Item Ammo{ get{ return new Arrow(); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force1; } }
        public override int AosMinDamage { get { return Arc_MinDam1; } }
        public override int AosMaxDamage { get { return Arc_MaxDam1; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

		public override int OldStrengthReq{ get{ return 20; } }
		public override int OldMinDamage{ get{ return 9; } }
		public override int OldMaxDamage{ get{ return 41; } }
		public override int OldSpeed{ get{ return 20; } }

		public override int DefMaxRange{ get{ return 10; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 60; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } }

		[Constructable]
		public Legarc() : base( 0x299F )
		{
			Weight = 6.0;
			Layer = Layer.TwoHanded;
            Name = "Legarc";
		}

        public Legarc(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
    }
    public class Tarkarc : BaseRanged
    {
        //public override int NiveauAttirail { get { return 1; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force1; } }
        public override int AosMinDamage { get { return Arc_MinDam1; } }
        public override int AosMaxDamage { get { return Arc_MaxDam1; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Tarkarc()
            : base(0x299E)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Tarkarc";
        }

        public Tarkarc(Serial serial)
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
    public class Souplecorde : BaseRanged
    {
        //public override int NiveauAttirail { get { return 3; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force3; } }
        public override int AosMinDamage { get { return Arc_MinDam3; } }
        public override int AosMaxDamage { get { return Arc_MaxDam3; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Souplecorde()
            : base(0x299D)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Souplecorde";
        }

        public Souplecorde(Serial serial)
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
    public class Sombrevent : BaseRanged
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force4; } }
        public override int AosMinDamage { get { return Arc_MinDam4; } }
        public override int AosMaxDamage { get { return Arc_MaxDam4; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Sombrevent()
            : base(0x299C)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Sombrevent";
        }

        public Sombrevent(Serial serial)
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
    public class Sifflecrin : BaseRanged
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force5; } }
        public override int AosMinDamage { get { return Arc_MinDam5; } }
        public override int AosMaxDamage { get { return Arc_MaxDam5; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Sifflecrin()
            : base(0x299B)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Sifflecrin";
        }

        public Sifflecrin(Serial serial)
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
    public class Chantefleche : BaseRanged
    {
        //public override int NiveauAttirail { get { return 6; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force6; } }
        public override int AosMinDamage { get { return Arc_MinDam6; } }
        public override int AosMaxDamage { get { return Arc_MaxDam6; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Chantefleche()
            : base(0x299A)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Chantefleche";
        }

        public Chantefleche(Serial serial)
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
    public class Flamfleche : BaseRanged
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force4; } }
        public override int AosMinDamage { get { return Arc_MinDam4; } }
        public override int AosMaxDamage { get { return Arc_MaxDam4; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Flamfleche()
            : base(0x230A)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Flamfleche";
        }

        public Flamfleche(Serial serial)
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
    public class Barbatrine : BaseRanged
    {
        //public override int NiveauAttirail { get { return 3; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force3; } }
        public override int AosMinDamage { get { return Arc_MinDam3; } }
        public override int AosMaxDamage { get { return Arc_MaxDam3; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Barbatrine()
            : base(0x2D22)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Barbatrine";
        }

        public Barbatrine(Serial serial)
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
    public class Ebonie : BaseRanged
    {
        //public override int NiveauAttirail { get { return 3; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force3; } }
        public override int AosMinDamage { get { return Arc_MinDam3; } }
        public override int AosMaxDamage { get { return Arc_MaxDam3; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Ebonie()
            : base(0x2D23)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Ebonie";
        }

        public Ebonie(Serial serial)
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
    public class Arc : BaseRanged
    {
        //public override int NiveauAttirail { get { return 0; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force0; } }
        public override int AosMinDamage { get { return Arc_MinDam0; } }
        public override int AosMaxDamage { get { return Arc_MaxDam0; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Arc()
            : base(0x2D24)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Arc";
        }

        public Arc(Serial serial)
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
    public class Foliere : BaseRanged
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force5; } }
        public override int AosMinDamage { get { return Arc_MinDam5; } }
        public override int AosMaxDamage { get { return Arc_MaxDam5; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Foliere()
            : base(0x2D25)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Foliere";
        }

        public Foliere(Serial serial)
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
    public class Maegie : BaseRanged
    {
        //public override int NiveauAttirail { get { return 6; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force6; } }
        public override int AosMinDamage { get { return Arc_MinDam6; } }
        public override int AosMaxDamage { get { return Arc_MaxDam6; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Maegie()
            : base(0x2D26)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Maegie";
        }

        public Maegie(Serial serial)
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
    public class Blancorde : BaseRanged
    {
        //public override int NiveauAttirail { get { return 2; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force2; } }
        public override int AosMinDamage { get { return Arc_MinDam2; } }
        public override int AosMaxDamage { get { return Arc_MaxDam2; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Blancorde()
            : base(0x2D27)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Blancorde";
        }

        public Blancorde(Serial serial)
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
    public class Composite : BaseRanged
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force4; } }
        public override int AosMinDamage { get { return Arc_MinDam4; } }
        public override int AosMaxDamage { get { return Arc_MaxDam4; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Composite()
            : base(0x2FEE)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Composite";
        }

        public Composite(Serial serial)
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
    public class Pieuse : BaseRanged
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force5; } }
        public override int AosMinDamage { get { return Arc_MinDam5; } }
        public override int AosMaxDamage { get { return Arc_MaxDam5; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Pieuse()
            : base(0x2FEF)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Pieuse";
        }

        public Pieuse(Serial serial)
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
    public class Foudre : BaseRanged
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force4; } }
        public override int AosMinDamage { get { return Arc_MinDam4; } }
        public override int AosMaxDamage { get { return Arc_MaxDam4; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Foudre()
            : base(0x2FF0)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Foudre";
        }

        public Foudre(Serial serial)
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
    public class Mirielle : BaseRanged
    {
        //public override int NiveauAttirail { get { return 3; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force3; } }
        public override int AosMinDamage { get { return Arc_MinDam3; } }
        public override int AosMaxDamage { get { return Arc_MaxDam3; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Mirielle()
            : base(0x2FF1)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Mirielle";
        }

        public Mirielle(Serial serial)
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
    public class Glaciale : BaseRanged
    {
        //public override int NiveauAttirail { get { return 2; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force2; } }
        public override int AosMinDamage { get { return Arc_MinDam2; } }
        public override int AosMaxDamage { get { return Arc_MaxDam2; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Glaciale()
            : base(0x2FF7)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Glaciale";
        }

        public Glaciale(Serial serial)
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
    public class Vigne : BaseRanged
    {
        //public override int NiveauAttirail { get { return 6; } }

        public override int EffectID { get { return 0xF42; } }
        public override Type AmmoType { get { return typeof(Arrow); } }
        public override Item Ammo { get { return new Arrow(); } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arc_Force6; } }
        public override int AosMinDamage { get { return Arc_MinDam6; } }
        public override int AosMaxDamage { get { return Arc_MaxDam6; } }
        public override double AosSpeed { get { return Arc_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 10; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 60; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootBow; } }

        [Constructable]
        public Vigne()
            : base(0x2FF8)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
            Name = "Vigne";
        }

        public Vigne(Serial serial)
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
