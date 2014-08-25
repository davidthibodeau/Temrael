using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class DoubleLance : BaseSpear
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Lance_Force5; } }
        public override int AosMinDamage { get { return Lance_MinDam5; } }
        public override int AosMaxDamage { get { return Lance_MaxDam5; } }
        public override double AosSpeed { get { return Lance_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

		public override int OldStrengthReq{ get{ return 30; } }
		public override int OldMinDamage{ get{ return 2; } }
		public override int OldMaxDamage{ get{ return 36; } }
		public override int OldSpeed{ get{ return 46; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 80; } }

		[Constructable]
		public DoubleLance() : base( 0x297C )
		{
			Weight = 7.0;
            Name = "Double Lance";
		}

        public DoubleLance(Serial serial)
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
    public class Terricharde : BaseSpear
    {
        //public override int NiveauAttirail { get { return 2; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Lance_Force2; } }
        public override int AosMinDamage { get { return Lance_MinDam2; } }
        public override int AosMaxDamage { get { return Lance_MaxDam2; } }
        public override double AosSpeed { get { return Lance_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int OldStrengthReq { get { return 30; } }
        public override int OldMinDamage { get { return 2; } }
        public override int OldMaxDamage { get { return 36; } }
        public override int OldSpeed { get { return 46; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public Terricharde()
            : base(0x297F)
        {
            Weight = 7.0;
            Name = "Terricharde";
        }

        public Terricharde(Serial serial)
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
    public class Piculame : BaseSpear
    {
        //public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Lance_Force6; } }
        public override int AosMinDamage { get { return Lance_MinDam6; } }
        public override int AosMaxDamage { get { return Lance_MaxDam6; } }
        public override double AosSpeed { get { return Lance_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int OldStrengthReq { get { return 30; } }
        public override int OldMinDamage { get { return 2; } }
        public override int OldMaxDamage { get { return 36; } }
        public override int OldSpeed { get { return 46; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public Piculame()
            : base(0x2980)
        {
            Weight = 7.0;
            Name = "Piculame";
        }

        public Piculame(Serial serial)
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
    public class Trident : BaseSpear
    {
        //public override int NiveauAttirail { get { return 2; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Trident_Force2; } }
        public override int AosMinDamage { get { return Trident_MinDam2; } }
        public override int AosMaxDamage { get { return Trident_MaxDam2; } }
        public override double AosSpeed { get { return Trident_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int OldStrengthReq { get { return 30; } }
        public override int OldMinDamage { get { return 2; } }
        public override int OldMaxDamage { get { return 36; } }
        public override int OldSpeed { get { return 46; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public Trident()
            : base(0x2981)
        {
            Weight = 7.0;
            Name = "Trident";
        }

        public Trident(Serial serial)
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
    public class Turione : BaseSpear
    {
        //public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Trident_Force6; } }
        public override int AosMinDamage { get { return Trident_MinDam6; } }
        public override int AosMaxDamage { get { return Trident_MaxDam6; } }
        public override double AosSpeed { get { return Trident_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int OldStrengthReq { get { return 30; } }
        public override int OldMinDamage { get { return 2; } }
        public override int OldMaxDamage { get { return 36; } }
        public override int OldSpeed { get { return 46; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public Turione()
            : base(0x2982)
        {
            Weight = 7.0;
            Name = "Turione";
        }

        public Turione(Serial serial)
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
    public class Racuris : BaseSpear
    {
        //public override int NiveauAttirail { get { return 3; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Trident_Force3; } }
        public override int AosMinDamage { get { return Trident_MinDam3; } }
        public override int AosMaxDamage { get { return Trident_MaxDam3; } }
        public override double AosSpeed { get { return Trident_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int OldStrengthReq { get { return 30; } }
        public override int OldMinDamage { get { return 2; } }
        public override int OldMaxDamage { get { return 36; } }
        public override int OldSpeed { get { return 46; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public Racuris()
            : base(0x2983)
        {
            Weight = 7.0;
            Name = "Racuris";
        }

        public Racuris(Serial serial)
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
    public class Percecoeur : BaseSpear
    {
        //public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Lance_Force6; } }
        public override int AosMinDamage { get { return Lance_MinDam6; } }
        public override int AosMaxDamage { get { return Lance_MaxDam6; } }
        public override double AosSpeed { get { return Lance_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int OldStrengthReq { get { return 30; } }
        public override int OldMinDamage { get { return 2; } }
        public override int OldMaxDamage { get { return 36; } }
        public override int OldSpeed { get { return 46; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public Percecoeur()
            : base(0x2987)
        {
            Weight = 7.0;
            Name = "Percecoeur";
        }

        public Percecoeur(Serial serial)
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
    public class Percetronc : BaseSpear
    {
        //public override int NiveauAttirail { get { return 3; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Lance_Force3; } }
        public override int AosMinDamage { get { return Lance_MinDam3; } }
        public override int AosMaxDamage { get { return Lance_MaxDam3; } }
        public override double AosSpeed { get { return Lance_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int OldStrengthReq { get { return 30; } }
        public override int OldMinDamage { get { return 2; } }
        public override int OldMaxDamage { get { return 36; } }
        public override int OldSpeed { get { return 46; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public Percetronc()
            : base(0x297D)
        {
            Weight = 7.0;
            Name = "Percetronc";
        }

        public Percetronc(Serial serial)
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
    /*
     * Bug d'affichage avec Bottes sombres
     */
    public class Penetra : BaseSpear
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return 50; } }
        public override int AosMinDamage { get { return 13; } }
        public override int AosMaxDamage { get { return 15; } }
        public override double AosSpeed { get { return 42; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int OldStrengthReq { get { return 30; } }
        public override int OldMinDamage { get { return 2; } }
        public override int OldMaxDamage { get { return 36; } }
        public override int OldSpeed { get { return 46; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public Penetra()
            : base(0x297E)
        {
            Weight = 7.0;
            Name = "Penetra";
        }

        public Penetra(Serial serial)
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
    public class Pique : BaseSpear
    {
        //public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Trident_Force1; } }
        public override int AosMinDamage { get { return Trident_MinDam1; } }
        public override int AosMaxDamage { get { return Trident_MaxDam1; } }
        public override double AosSpeed { get { return Trident_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int OldStrengthReq { get { return 30; } }
        public override int OldMinDamage { get { return 2; } }
        public override int OldMaxDamage { get { return 36; } }
        public override int OldSpeed { get { return 46; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public Pique()
            : base(0x2984)
        {
            Weight = 7.0;
            Name = "Pique";
        }

        public Pique(Serial serial)
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
    public class Transpercille : BaseSpear
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Trident_Force4; } }
        public override int AosMinDamage { get { return Trident_MinDam4; } }
        public override int AosMaxDamage { get { return Trident_MaxDam4; } }
        public override double AosSpeed { get { return Trident_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int OldStrengthReq { get { return 30; } }
        public override int OldMinDamage { get { return 2; } }
        public override int OldMaxDamage { get { return 36; } }
        public override int OldSpeed { get { return 46; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public Transpercille()
            : base(0x2985)
        {
            Weight = 7.0;
            Name = "Transpercille";
        }

        public Transpercille(Serial serial)
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
    public class Mascarate : BaseSpear
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Trident_Force5; } }
        public override int AosMinDamage { get { return Trident_MinDam5; } }
        public override int AosMaxDamage { get { return Trident_MaxDam5; } }
        public override double AosSpeed { get { return Trident_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int OldStrengthReq { get { return 30; } }
        public override int OldMinDamage { get { return 2; } }
        public override int OldMaxDamage { get { return 36; } }
        public override int OldSpeed { get { return 46; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public Mascarate()
            : base(0x2986)
        {
            Weight = 7.0;
            Name = "Mascarate";
        }

        public Mascarate(Serial serial)
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
    public class Lancel : BaseSpear
    {
        //public override int NiveauAttirail { get { return 0; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Lance_Force0; } }
        public override int AosMinDamage { get { return Lance_MinDam0; } }
        public override int AosMaxDamage { get { return Lance_MaxDam0; } }
        public override double AosSpeed { get { return Lance_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int OldStrengthReq { get { return 30; } }
        public override int OldMinDamage { get { return 2; } }
        public override int OldMaxDamage { get { return 36; } }
        public override int OldSpeed { get { return 46; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public Lancel()
            : base(0x315A)
        {
            Weight = 7.0;
            Name = "Lancel";
        }

        public Lancel(Serial serial)
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
