using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class Raghash : BaseSword
    {
        public override int NiveauAttirail { get { return 3; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Sabre_Force3; } }
        public override int AosMinDamage { get { return Sabre_MinDam3; } }
        public override int AosMaxDamage { get { return Sabre_MaxDam3; } }
        public override double AosSpeed { get { return Sabre_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Raghash()
            : base(0x2A18)
        {
            Weight = 6.0;
            Name = "Ragash";
        }

        public Raghash(Serial serial)
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
    public class Prisienne : BaseSword
    {
        public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Sabre_Force4; } }
        public override int AosMinDamage { get { return Sabre_MinDam4; } }
        public override int AosMaxDamage { get { return Sabre_MaxDam4; } }
        public override double AosSpeed { get { return Sabre_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Prisienne()
            : base(0x2A19)
        {
            Weight = 6.0;
            Name = "Prisienne";
        }

        public Prisienne(Serial serial)
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
    public class Mirilione : BaseSword
    {
        public override int NiveauAttirail { get { return 3; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Lame_Force3; } }
        public override int AosMinDamage { get { return Lame_MinDam3; } }
        public override int AosMaxDamage { get { return Lame_MaxDam3; } }
        public override double AosSpeed { get { return Lame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Mirilione()
            : base(0x2A1A)
        {
            Weight = 6.0;
            Name = "Mirilione";
        }

        public Mirilione(Serial serial)
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
    public class Draglast : BaseSword
    {
        public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Lame_Force3; } }
        public override int AosMinDamage { get { return Lame_MinDam3; } }
        public override int AosMaxDamage { get { return Lame_MaxDam3; } }
        public override double AosSpeed { get { return Lame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Draglast()
            : base(0x2A1B)
        {
            Weight = 6.0;
            Name = "Draglast";
        }

        public Draglast(Serial serial)
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
    public class Sabre : BaseSword
    {
        public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Sabre_Force1; } }
        public override int AosMinDamage { get { return Sabre_MinDam1; } }
        public override int AosMaxDamage { get { return Sabre_MaxDam1; } }
        public override double AosSpeed { get { return Sabre_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Sabre()
            : base(0x2A1C)
        {
            Weight = 6.0;
            Name = "Sabre";
        }

        public Sabre(Serial serial)
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
    public class Mersang : BaseSword
    {
        public override int NiveauAttirail { get { return 2; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Sabre_Force2; } }
        public override int AosMinDamage { get { return Sabre_MinDam2; } }
        public override int AosMaxDamage { get { return Sabre_MaxDam2; } }
        public override double AosSpeed { get { return Sabre_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Mersang()
            : base(0x2A1D)
        {
            Weight = 6.0;
            Name = "Mersang";
        }

        public Mersang(Serial serial)
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
    public class Couliere : BaseSword
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force6; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam6; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam6; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Couliere()
            : base(0x2A1E)
        {
            Weight = 6.0;
            Name = "Couliere";
            Layer = Layer.TwoHanded;
        }

        public Couliere(Serial serial)
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
    public class Biliome : BaseSword
    {
        public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return CourteLame_Force1; } }
        public override int AosMinDamage { get { return CourteLame_MinDam1; } }
        public override int AosMaxDamage { get { return CourteLame_MaxDam1; } }
        public override double AosSpeed { get { return CourteLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Biliome()
            : base(0x2A1F)
        {
            Weight = 6.0;
            Name = "Biliome";
        }

        public Biliome(Serial serial)
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
    public class Tranchor : BaseSword
    {
        public override int NiveauAttirail { get { return 3; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Claymore_Force3; } }
        public override int AosMinDamage { get { return Claymore_MinDam3; } }
        public override int AosMaxDamage { get { return Claymore_MaxDam3; } }
        public override double AosSpeed { get { return Claymore_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Tranchor()
            : base(0x2A20)
        {
            Weight = 6.0;
            Name = "Tranchor";
            Layer = Layer.TwoHanded;
        }

        public Tranchor(Serial serial)
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
    public class Hectmore : BaseSword
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Lame_Force6; } }
        public override int AosMinDamage { get { return Lame_MinDam6; } }
        public override int AosMaxDamage { get { return Lame_MaxDam6; } }
        public override double AosSpeed { get { return Lame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Hectmore()
            : base(0x2A21)
        {
            Weight = 6.0;
            Name = "Hectmore";
        }

        public Hectmore(Serial serial)
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
    public class Vorlame : BaseSword
    {
        public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return CourteLame_Force4; } }
        public override int AosMinDamage { get { return CourteLame_MinDam4; } }
        public override int AosMaxDamage { get { return CourteLame_MaxDam4; } }
        public override double AosSpeed { get { return CourteLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Vorlame()
            : base(0x2A22)
        {
            Weight = 6.0;
            Name = "Vorlame";
        }

        public Vorlame(Serial serial)
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
    public class Niropie : BaseSword
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Lame_Force6; } }
        public override int AosMinDamage { get { return Lame_MinDam6; } }
        public override int AosMaxDamage { get { return Lame_MaxDam6; } }
        public override double AosSpeed { get { return Lame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Niropie()
            : base(0x2A23)
        {
            Weight = 6.0;
            Name = "Niropie";
        }

        public Niropie(Serial serial)
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
    public class Merlarme : BaseSword
    {
        public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Lame_Force4; } }
        public override int AosMinDamage { get { return Lame_MinDam4; } }
        public override int AosMaxDamage { get { return Lame_MaxDam4; } }
        public override double AosSpeed { get { return Lame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Merlarme()
            : base(0x2A24)
        {
            Weight = 6.0;
            Name = "Merlame";
        }

        public Merlarme(Serial serial)
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
    public class Gerumir : BaseSword
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return CourteLame_Force6; } }
        public override int AosMinDamage { get { return CourteLame_MinDam6; } }
        public override int AosMaxDamage { get { return CourteLame_MaxDam6; } }
        public override double AosSpeed { get { return CourteLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Gerumir()
            : base(0x2A25)
        {
            Weight = 6.0;
            Name = "Gerumir";
        }

        public Gerumir(Serial serial)
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
    public class Myliron : BaseSword
    {
        public override int NiveauAttirail { get { return 3; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return CourteLame_Force3; } }
        public override int AosMinDamage { get { return CourteLame_MinDam3; } }
        public override int AosMaxDamage { get { return CourteLame_MaxDam3; } }
        public override double AosSpeed { get { return CourteLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Myliron()
            : base(0x2A26)
        {
            Weight = 6.0;
            Name = "Myliron";
        }

        public Myliron(Serial serial)
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
    public class Runire : BaseSword
    {
        public override int NiveauAttirail { get { return 2; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return CourteLame_Force2; } }
        public override int AosMinDamage { get { return CourteLame_MinDam2; } }
        public override int AosMaxDamage { get { return CourteLame_MaxDam2; } }
        public override double AosSpeed { get { return CourteLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Runire()
            : base(0x2A27)
        {
            Weight = 6.0;
            Name = "Runire";
        }

        public Runire(Serial serial)
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
    public class Granlame : BaseSword
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Claymore_Force6; } }
        public override int AosMinDamage { get { return Claymore_MinDam6; } }
        public override int AosMaxDamage { get { return Claymore_MaxDam6; } }
        public override double AosSpeed { get { return Claymore_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Granlame()
            : base(0x2A28)
        {
            Weight = 6.0;
            Name = "Granlame";
            Layer = Layer.TwoHanded;
        }

        public Granlame(Serial serial)
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
    public class Claymore : BaseSword
    {
        public override int NiveauAttirail { get { return 2; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Claymore_Force2; } }
        public override int AosMinDamage { get { return Claymore_MinDam2; } }
        public override int AosMaxDamage { get { return Claymore_MaxDam2; } }
        public override double AosSpeed { get { return Claymore_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Claymore()
            : base(0x29D0)
        {
            Weight = 6.0;
            Name = "Claymore";
            Layer = Layer.TwoHanded;
        }

        public Claymore(Serial serial)
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
    public class Ventmore : BaseSword
    {
        public override int NiveauAttirail { get { return 2; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force2; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam2; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam2; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Ventmore()
            : base(0x29D1)
        {
            Weight = 6.0;
            Name = "Ventmore";
            Layer = Layer.TwoHanded;
        }

        public Ventmore(Serial serial)
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
    public class Dorleane : BaseSword
    {
        public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force5; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam5; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam5; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Dorleane()
            : base(0x29D2)
        {
            Weight = 6.0;
            Name = "Dorleane";
            Layer = Layer.TwoHanded;
        }

        public Dorleane(Serial serial)
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
    public class Lerise : BaseSword
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return CourteLame_Force6; } }
        public override int AosMinDamage { get { return CourteLame_MinDam6; } }
        public override int AosMaxDamage { get { return CourteLame_MaxDam6; } }
        public override double AosSpeed { get { return CourteLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Lerise()
            : base(0x29D3)
        {
            Weight = 6.0;
            Name = "Lerise";
        }

        public Lerise(Serial serial)
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
    public class Dravene : BaseSword
    {
        public override int NiveauAttirail { get { return 2; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Lame_Force2; } }
        public override int AosMinDamage { get { return Lame_MinDam2; } }
        public override int AosMaxDamage { get { return Lame_MaxDam2; } }
        public override double AosSpeed { get { return Lame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Dravene()
            : base(0x29D4)
        {
            Weight = 6.0;
            Name = "Dravene";
        }

        public Dravene(Serial serial)
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
    public class Vifcoupe : BaseSword
    {
        public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force1; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam1; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam1; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Vifcoupe()
            : base(0x29D5)
        {
            Weight = 6.0;
            Name = "Vifcoupe";
            Layer = Layer.TwoHanded;
        }

        public Vifcoupe(Serial serial)
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
    public class Auderre : BaseSword
    {
        public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force1; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam1; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam1; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Auderre()
            : base(0x29D6)
        {
            Weight = 6.0;
            Name = "Auderre";
            Layer = Layer.TwoHanded;
        }

        public Auderre(Serial serial)
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
    public class Nhilarte : BaseSword
    {
        public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force4; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam4; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam4; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Nhilarte()
            : base(0x29D7)
        {
            Weight = 6.0;
            Name = "Nhilarte";
            Layer = Layer.TwoHanded;
        }

        public Nhilarte(Serial serial)
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
    public class Monarque : BaseSword
    {
        public override int NiveauAttirail { get { return 2; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Claymore_Force2; } }
        public override int AosMinDamage { get { return Claymore_MinDam2; } }
        public override int AosMaxDamage { get { return Claymore_MaxDam2; } }
        public override double AosSpeed { get { return Claymore_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Monarque()
            : base(0x29D8)
        {
            Weight = 6.0;
            Name = "Monarque";
            Layer = Layer.TwoHanded;
        }

        public Monarque(Serial serial)
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
    public class Marquaise : BaseSword
    {
        public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Claymore_Force5; } }
        public override int AosMinDamage { get { return Claymore_MinDam5; } }
        public override int AosMaxDamage { get { return Claymore_MaxDam5; } }
        public override double AosSpeed { get { return Claymore_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Marquaise()
            : base(0x29D9)
        {
            Weight = 6.0;
            Name = "Marquaise";
            Layer = Layer.TwoHanded;
        }

        public Marquaise(Serial serial)
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
    public class Zweihander : BaseSword
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Claymore_Force6; } }
        public override int AosMinDamage { get { return Claymore_MinDam6; } }
        public override int AosMaxDamage { get { return Claymore_MaxDam6; } }
        public override double AosSpeed { get { return Claymore_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Zweihander()
            : base(0x29DA)
        {
            Weight = 6.0;
            Name = "Zweihander";
            Layer = Layer.TwoHanded;
        }

        public Zweihander(Serial serial)
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
    public class Zarel : BaseSword
    {
        public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return CourteLame_Force1; } }
        public override int AosMinDamage { get { return CourteLame_MinDam1; } }
        public override int AosMaxDamage { get { return CourteLame_MaxDam1; } }
        public override double AosSpeed { get { return CourteLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Zarel()
            : base(0x29DB)
        {
            Weight = 6.0;
            Name = "Zarel";
        }

        public Zarel(Serial serial)
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
    public class Sefrio : BaseSword
    {
        public override int NiveauAttirail { get { return 3; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return CourteLame_Force3; } }
        public override int AosMinDamage { get { return CourteLame_MinDam3; } }
        public override int AosMaxDamage { get { return CourteLame_MaxDam3; } }
        public override double AosSpeed { get { return CourteLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Sefrio()
            : base(0x2A05)
        {
            Weight = 6.0;
            Name = "Sefrio";
        }

        public Sefrio(Serial serial)
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
    public class Ferel : BaseSword
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return CourteLame_Force6; } }
        public override int AosMinDamage { get { return CourteLame_MinDam6; } }
        public override int AosMaxDamage { get { return CourteLame_MaxDam6; } }
        public override double AosSpeed { get { return CourteLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Ferel()
            : base(0x2A06)
        {
            Weight = 6.0;
            Name = "Ferel";
        }

        public Ferel(Serial serial)
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
    public class Conquise : BaseSword
    {
        public override int NiveauAttirail { get { return 3; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force3; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam3; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam3; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Conquise()
            : base(0x2A07)
        {
            Weight = 6.0;
            Name = "Conquise";
            Layer = Layer.TwoHanded;
        }

        public Conquise(Serial serial)
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
    public class Flamberge : BaseSword
    {
        public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Claymore_Force4; } }
        public override int AosMinDamage { get { return Claymore_MinDam4; } }
        public override int AosMaxDamage { get { return Claymore_MaxDam4; } }
        public override double AosSpeed { get { return Claymore_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Flamberge()
            : base(0x2A08)
        {
            Weight = 6.0;
            Name = "Flamberge";
            Layer = Layer.TwoHanded;
        }

        public Flamberge(Serial serial)
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
    public class Nerfille : BaseSword
    {
        public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force4; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam4; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam4; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Nerfille()
            : base(0x2A09)
        {
            Weight = 6.0;
            Name = "Nerfille";
            Layer = Layer.TwoHanded;
        }

        public Nerfille(Serial serial)
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
    public class Querquoise : BaseSword
    {
        public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force4; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam4; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam4; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Querquoise()
            : base(0x2A0A)
        {
            Weight = 6.0;
            Name = "Querquoise";
            Layer = Layer.TwoHanded;
        }

        public Querquoise(Serial serial)
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
    public class Narvegne : BaseSword
    {
        public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Lame_Force5; } }
        public override int AosMinDamage { get { return Lame_MinDam5; } }
        public override int AosMaxDamage { get { return Lame_MaxDam5; } }
        public override double AosSpeed { get { return Lame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Narvegne()
            : base(0x2A0B)
        {
            Weight = 6.0;
            Name = "Narvegne";
        }

        public Narvegne(Serial serial)
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
    public class Atargne : BaseSword
    {
        public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force4; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam4; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam4; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Atargne()
            : base(0x2A0C)
        {
            Weight = 6.0;
            Name = "Atargne";
            Layer = Layer.TwoHanded;
        }

        public Atargne(Serial serial)
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
    public class Tranchevil : BaseSword
    {
        public override int NiveauAttirail { get { return 2; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force2; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam2; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam2; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Tranchevil()
            : base(0x2A0D)
        {
            Weight = 6.0;
            Name = "Tranchevil";
            Layer = Layer.TwoHanded;
        }

        public Tranchevil(Serial serial)
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
    public class Excalior : BaseSword
    {
        public override int NiveauAttirail { get { return 3; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force3; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam3; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam3; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Excalior()
            : base(0x2A0E)
        {
            Weight = 6.0;
            Name = "Excalior";
            Layer = Layer.TwoHanded;
        }

        public Excalior(Serial serial)
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
    public class Luminera : BaseSword
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force6; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam6; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam6; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Luminera()
            : base(0x2A0F)
        {
            Weight = 6.0;
            Name = "Luminera";
            Layer = Layer.TwoHanded;
        }

        public Luminera(Serial serial)
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
    public class Courbelle : BaseSword
    {
        public override int NiveauAttirail { get { return 3; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Claymore_Force3; } }
        public override int AosMinDamage { get { return Claymore_MinDam3; } }
        public override int AosMaxDamage { get { return Claymore_MaxDam3; } }
        public override double AosSpeed { get { return Claymore_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Courbelle()
            : base(0x2A10)
        {
            Weight = 6.0;
            Name = "Courbelle";
            Layer = Layer.TwoHanded;
        }

        public Courbelle(Serial serial)
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
    public class Sombrimur : BaseSword
    {
        public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Claymore_Force4; } }
        public override int AosMinDamage { get { return Claymore_MinDam4; } }
        public override int AosMaxDamage { get { return Claymore_MaxDam4; } }
        public override double AosSpeed { get { return Claymore_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Sombrimur()
            : base(0x2A11)
        {
            Weight = 6.0;
            Name = "Sombrimur";
            Layer = Layer.TwoHanded;
        }

        public Sombrimur(Serial serial)
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
    public class Mortimer : BaseSword
    {
        public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Claymore_Force5; } }
        public override int AosMinDamage { get { return Claymore_MinDam5; } }
        public override int AosMaxDamage { get { return Claymore_MaxDam5; } }
        public override double AosSpeed { get { return Claymore_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Mortimer()
            : base(0x2A12)
        {
            Weight = 6.0;
            Name = "Mortimer";
            Layer = Layer.TwoHanded;
        }

        public Mortimer(Serial serial)
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
    public class Morsame : BaseSword
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Claymore_Force6; } }
        public override int AosMinDamage { get { return Claymore_MinDam6; } }
        public override int AosMaxDamage { get { return Claymore_MaxDam6; } }
        public override double AosSpeed { get { return Claymore_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Morsame()
            : base(0x2A13)
        {
            Weight = 6.0;
            Name = "Morsame";
            Layer = Layer.TwoHanded;
        }

        public Morsame(Serial serial)
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
    public class Rodere : BaseSword
    {
        public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Lame_Force1; } }
        public override int AosMinDamage { get { return Lame_MinDam1; } }
        public override int AosMaxDamage { get { return Lame_MaxDam1; } }
        public override double AosSpeed { get { return Lame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Rodere()
            : base(0x2A14)
        {
            Weight = 6.0;
            Name = "Rodere";
        }

        public Rodere(Serial serial)
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
    public class Rougegorge : BaseSword
    {
        public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Claymore_Force1; } }
        public override int AosMinDamage { get { return Claymore_MinDam1; } }
        public override int AosMaxDamage { get { return Claymore_MaxDam1; } }
        public override double AosSpeed { get { return Claymore_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Rougegorge()
            : base(0x2A15)
        {
            Weight = 6.0;
            Name = "Rougegorge";
            Layer = Layer.TwoHanded;
        }

        public Rougegorge(Serial serial)
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
    public class Batarde : BaseSword
    {
        public override int NiveauAttirail { get { return 2; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force2; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam2; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam2; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Batarde()
            : base(0x2A16)
        {
            Weight = 6.0;
            Name = "Batarde";
            Layer = Layer.TwoHanded;
        }

        public Batarde(Serial serial)
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
    public class Espadon : BaseSword
    {
        public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Claymore_Force5; } }
        public override int AosMinDamage { get { return Claymore_MinDam5; } }
        public override int AosMaxDamage { get { return Claymore_MaxDam5; } }
        public override double AosSpeed { get { return Claymore_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Espadon()
            : base(0x2A17)
        {
            Weight = 6.0;
            Name = "Espadon";
            Layer = Layer.TwoHanded;
        }

        public Espadon(Serial serial)
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
    public class Dawn : BaseSword
    {
        public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return CourteLame_Force5; } }
        public override int AosMinDamage { get { return CourteLame_MinDam5; } }
        public override int AosMaxDamage { get { return CourteLame_MaxDam5; } }
        public override double AosSpeed { get { return CourteLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Dawn()
            : base(0x315B)
        {
            Weight = 6.0;
            Name = "Dawn";
        }

        public Dawn(Serial serial)
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
    public class Astoria : BaseSword
    {
        public override int NiveauAttirail { get { return 0; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return CourteLame_Force0; } }
        public override int AosMinDamage { get { return CourteLame_MinDam0; } }
        public override int AosMaxDamage { get { return CourteLame_MaxDam0; } }
        public override double AosSpeed { get { return CourteLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return Armes_MinDurabilite0; } }
        public override int InitMaxHits { get { return Armes_MaxDurabilite0; } }

        [Constructable]
        public Astoria()
            : base(0x315E)
        {
            Weight = 6.0;
            Name = "Astoria";
        }

        public Astoria(Serial serial)
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
    public class Abysse : BaseSword
    {
        public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return LourdeLame_Force5; } }
        public override int AosMinDamage { get { return LourdeLame_MinDam5; } }
        public override int AosMaxDamage { get { return LourdeLame_MaxDam5; } }
        public override double AosSpeed { get { return LourdeLame_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int OldStrengthReq { get { return 40; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 34; } }
        public override int OldSpeed { get { return 30; } }

        public override int DefHitSound { get { return 0x237; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 100; } }

        [Constructable]
        public Abysse()
            : base(0x315F)
        {
            Weight = 6.0;
            Name = "Abysse";
            Layer = Layer.TwoHanded;
        }

        public Abysse(Serial serial)
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
}
