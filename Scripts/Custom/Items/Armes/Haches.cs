using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class Elvetrine : BaseAxe
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hache_Force6; } }
        public override int AosMinDamage { get { return Hache_MinDam6; } }
        public override int AosMaxDamage { get { return Hache_MaxDam6; } }
        public override double AosSpeed { get { return Hache_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Elvetrine()
            : base(0x296F)
        {
            Weight = 4.0;
            Name = "Elvetrine";
            Layer = Layer.TwoHanded;
        }

        public Elvetrine(Serial serial)
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
    public class Noctame : BaseAxe
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hachette_Force6; } }
        public override int AosMinDamage { get { return Hachette_MinDam6; } }
        public override int AosMaxDamage { get { return Hachette_MaxDam6; } }
        public override double AosSpeed { get { return Hachette_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Noctame()
            : base(0x296D)
        {
            Weight = 4.0;
            Name = "Noctame";
        }

        public Noctame(Serial serial)
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
    public class Biliane : BaseAxe
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hachette_Force6; } }
        public override int AosMinDamage { get { return Hachette_MinDam6; } }
        public override int AosMaxDamage { get { return Hachette_MaxDam6; } }
        public override double AosSpeed { get { return Hachette_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Biliane()
            : base(0x296E)
        {
            Weight = 4.0;
            Name = "Biliane";
        }

        public Biliane(Serial serial)
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
    public class Viftranche : BaseAxe
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hache_Force6; } }
        public override int AosMinDamage { get { return Hache_MinDam6; } }
        public override int AosMaxDamage { get { return Hache_MaxDam6; } }
        public override double AosSpeed { get { return Hache_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Viftranche()
            : base(0x2970)
        {
            Weight = 4.0;
            Name = "Viftranche";
            Layer = Layer.TwoHanded;
        }

        public Viftranche(Serial serial)
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
    public class Venmar : BaseAxe
    {
        public override int NiveauAttirail { get { return 2; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hache_Force2; } }
        public override int AosMinDamage { get { return Hache_MinDam2; } }
        public override int AosMaxDamage { get { return Hache_MaxDam2; } }
        public override double AosSpeed { get { return Hache_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Venmar()
            : base(0x2972)
        {
            Weight = 4.0;
            Name = "Venmar";
            Layer = Layer.TwoHanded;
        }

        public Venmar(Serial serial)
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
    public class Furagne : BaseAxe
    {
        public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hachette_Force1; } }
        public override int AosMinDamage { get { return Hachette_MinDam1; } }
        public override int AosMaxDamage { get { return Hachette_MaxDam1; } }
        public override double AosSpeed { get { return Hachette_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Furagne()
            : base(0x2971)
        {
            Weight = 4.0;
            Name = "Furagne";
        }

        public Furagne(Serial serial)
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
    public class Luminar : BaseAxe
    {
        public override int NiveauAttirail { get { return 2; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hachette_Force2; } }
        public override int AosMinDamage { get { return Hachette_MinDam2; } }
        public override int AosMaxDamage { get { return Hachette_MaxDam2; } }
        public override double AosSpeed { get { return Hachette_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Luminar()
            : base(0x2973)
        {
            Weight = 4.0;
            Name = "Luminar";
        }

        public Luminar(Serial serial)
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
    public class Tranchecorps : BaseAxe
    {
        public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hache_Force5; } }
        public override int AosMinDamage { get { return Hache_MinDam5; } }
        public override int AosMaxDamage { get { return Hache_MaxDam5; } }
        public override double AosSpeed { get { return Hache_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Tranchecorps()
            : base(0x2974)
        {
            Weight = 4.0;
            Name = "Tranchecorps";
            Layer = Layer.TwoHanded;
        }

        public Tranchecorps(Serial serial)
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
    public class Duxtranche : BaseAxe
    {
        public override int NiveauAttirail { get { return 3; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hachette_Force3; } }
        public override int AosMinDamage { get { return Hachette_MinDam3; } }
        public override int AosMaxDamage { get { return Hachette_MaxDam3; } }
        public override double AosSpeed { get { return Hachette_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Duxtranche()
            : base(0x2975)
        {
            Weight = 4.0;
            Name = "Duxtranche";

        }

        public Duxtranche(Serial serial)
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
    public class Morgrove : BaseAxe
    {
        public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hache_Force1; } }
        public override int AosMinDamage { get { return Hache_MinDam1; } }
        public override int AosMaxDamage { get { return Hache_MaxDam1; } }
        public override double AosSpeed { get { return Hache_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Morgrove()
            : base(0x2976)
        {
            Weight = 4.0;
            Name = "Morgrove";
            Layer = Layer.TwoHanded;
        }

        public Morgrove(Serial serial)
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
    public class Morgate : BaseAxe
    {
        public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hache_Force5; } }
        public override int AosMinDamage { get { return Hache_MinDam5; } }
        public override int AosMaxDamage { get { return Hache_MaxDam5; } }
        public override double AosSpeed { get { return Hache_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Morgate()
            : base(0x296C)
        {
            Weight = 4.0;
            Name = "Morgate";
            Layer = Layer.TwoHanded;
        }

        public Morgate(Serial serial)
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
    public class Grochette : BaseAxe
    {
        public override int NiveauAttirail { get { return 6; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hachette_Force6; } }
        public override int AosMinDamage { get { return Hachette_MinDam6; } }
        public override int AosMaxDamage { get { return Hachette_MaxDam6; } }
        public override double AosSpeed { get { return Hachette_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Grochette()
            : base(0x296B)
        {
            Weight = 4.0;
            Name = "Grochette";
        }

        public Grochette(Serial serial)
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
    public class Loragne : BaseAxe
    {
        public override int NiveauAttirail { get { return 2; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hachette_Force2; } }
        public override int AosMinDamage { get { return Hachette_MinDam2; } }
        public override int AosMaxDamage { get { return Hachette_MaxDam2; } }
        public override double AosSpeed { get { return Hachette_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Loragne()
            : base(0x296A)
        {
            Weight = 4.0;
            Name = "Loragne";
        }

        public Loragne(Serial serial)
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
    public class Minarque : BaseAxe
    {
        public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hachette_Force5; } }
        public override int AosMinDamage { get { return Hachette_MinDam5; } }
        public override int AosMaxDamage { get { return Hachette_MaxDam5; } }
        public override double AosSpeed { get { return Hachette_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Minarque()
            : base(0x2969)
        {
            Weight = 4.0;
            Name = "Minarque";
        }

        public Minarque(Serial serial)
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
    public class Montorgne : BaseAxe
    {
        public override int NiveauAttirail { get { return 3; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hachette_Force3; } }
        public override int AosMinDamage { get { return Hachette_MinDam3; } }
        public override int AosMaxDamage { get { return Hachette_MaxDam3; } }
        public override double AosSpeed { get { return Hachette_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Montorgne()
            : base(0x2968)
        {
            Weight = 4.0;
            Name = "Montorgne";
        }

        public Montorgne(Serial serial)
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
    public class Orcarinia : BaseAxe
    {
        public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hachette_Force5; } }
        public override int AosMinDamage { get { return Hachette_MinDam5; } }
        public override int AosMaxDamage { get { return Hachette_MaxDam5; } }
        public override double AosSpeed { get { return Hachette_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Orcarinia()
            : base(0x2967)
        {
            Weight = 4.0;
            Name = "Orcarina";
        }

        public Orcarinia(Serial serial)
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
    public class Coupecrane : BaseAxe
    {
        public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hache_Force5; } }
        public override int AosMinDamage { get { return Hache_MinDam5; } }
        public override int AosMaxDamage { get { return Hache_MaxDam5; } }
        public override double AosSpeed { get { return Hache_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Coupecrane()
            : base(0x3047)
        {
            Weight = 4.0;
            Name = "Coupecrane";
            Layer = Layer.TwoHanded;
        }

        public Coupecrane(Serial serial)
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
    public class HacheDouble : BaseAxe
    {
        public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hache_Force1; } }
        public override int AosMinDamage { get { return Hache_MinDam1; } }
        public override int AosMaxDamage { get { return Hache_MaxDam1; } }
        public override double AosSpeed { get { return Hache_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public HacheDouble()
            : base(0x2B12)
        {
            Weight = 4.0;
            Name = "Hache Métalique";
            Layer = Layer.TwoHanded;
        }

        public HacheDouble(Serial serial)
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
    public class HachetteDouble : BaseAxe
    {
        public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hachette_Force1; } }
        public override int AosMinDamage { get { return Hachette_MinDam1; } }
        public override int AosMaxDamage { get { return Hachette_MaxDam1; } }
        public override double AosSpeed { get { return Hachette_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public HachetteDouble()
            : base(0x2B13)
        {
            Weight = 4.0;
            Name = "Hachette Double";
        }

        public HachetteDouble(Serial serial)
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
    public class Hachette : BaseAxe
    {
        public override int NiveauAttirail { get { return 0; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hachette_Force0; } }
        public override int AosMinDamage { get { return Hachette_MinDam0; } }
        public override int AosMaxDamage { get { return Hachette_MaxDam0; } }
        public override double AosSpeed { get { return Hachette_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

        public override int OldStrengthReq { get { return 35; } }
        public override int OldMinDamage { get { return 6; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 37; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Hachette()
            : base(0xF49)
        {
            Weight = 4.0;
            Name = "Hachette";
        }

        public Hachette(Serial serial)
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
            ItemID = 0xF49;
        }
    }
}
