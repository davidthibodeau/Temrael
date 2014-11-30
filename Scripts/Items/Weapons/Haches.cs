using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    /* Main gauche
    public class Furagne : BaseAxe
    {
        //public override int DefMinDamage { get { return 2; } }
        //public override int DefMaxDamage { get { return 5; } }
        public override int DefSpeed { get { return 20; } }

        [Constructable]
        public Furagne()
            : base(0x2971)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
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

    public class Biliane : BaseAxe
    {
        //public override int DefMinDamage { get { return 5; } }
        //public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Biliane()
            : base(0x296e)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
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

    // Deux mains gauche
    public class Duxtranche : BaseAxe
    {
        //public override int DefMinDamage { get { return 7; } }
        //public override int DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Duxtranche()
            : base(0x2975)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
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
    */

    // Main Droite
    public class Grochette : BaseAxe
    {
        //public override int DefMinDamage { get { return 9; } }
        //public override int DefMaxDamage { get { return 13; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Grochette()
            : base(0x296b)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
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
        //public override int DefMinDamage { get { return 5; } }
        //public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Loragne()
            : base(0x296a)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
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

    public class Luminar : BaseAxe
    {
        //public override int DefMinDamage { get { return 5; } }
        //public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Luminar()
            : base(0x2973)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
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

    public class Minarque : BaseAxe
    {
        //public override int DefMinDamage { get { return 7; } }
        //public override int DefMaxDamage { get { return 11; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Minarque()
            : base(0x2969)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
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
        //public override int DefMinDamage { get { return 7; } }
        //public override int DefMaxDamage { get { return 11; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Montorgne()
            : base(0x2968)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
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

    public class Noctame : BaseAxe
    {
        //public override int DefMinDamage { get { return 3; } }
        //public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Noctame()
            : base(0x296d)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
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

    public class Orcarinia : BaseAxe
    {
        //public override int DefMinDamage { get { return 5; } }
        //public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Orcarinia()
            : base(0x2967)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Orcarinia";
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

    public class WarAxe : BaseAxe
    {
        //public override int DefMinDamage { get { return 5; } }
        //public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public WarAxe()
            : base(0x13b0)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Hache de guerre";
        }

        public WarAxe(Serial serial)
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

    // Deux mains droite
    public class Axe : BaseAxe
    {
        public override int GoldValue { get { return 20; } set { } }

        //public override int DefMinDamage { get { return 7; } }
        //public override int DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Axe()
            : base(0xf49)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Hache";
        }

        public Axe(Serial serial)
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

    public class Hachettedouble : BaseAxe
    {
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Hachettedouble()
            : base(0x2b13)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Hachette double";
        }

        public Hachettedouble(Serial serial)
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
        //public override int DefMinDamage { get { return 13; } }
        //public override int DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 45; } }

        [Constructable]
        public Coupecrane()
            : base(0x3047)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Coupecrane";
        }

        public Coupecrane(Serial serial)
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

    public class Elvetrine : BaseAxe
    {
        //public override int DefMinDamage { get { return 13; } }
        //public override int DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 45; } }

        [Constructable]
        public Elvetrine()
            : base(0x296f)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Elvetrine";
        }

        public Elvetrine(Serial serial)
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

    public class HacheDouble : BaseAxe
    {
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public HacheDouble()
            : base(0x2b12)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Hache Double";
        }

        public HacheDouble(Serial serial)
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

    public class LargeBattleAxe : BaseAxe
    {
        //public override int DefMinDamage { get { return 13; } }
        //public override int DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 45; } }

        [Constructable]
        public LargeBattleAxe()
            : base(0x13fb)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Grande hache de guerre";
        }

        public LargeBattleAxe(Serial serial)
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
        //public override int DefMinDamage { get { return 11; } }
        //public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Morgrove()
            : base(0x2976)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Morgrove";
        }

        public Morgrove(Serial serial)
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
        //public override int DefMinDamage { get { return 9; } }
        //public override int DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Tranchecorps()
            : base(0x2974)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Tranchecorps";
        }

        public Tranchecorps(Serial serial)
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

    public class TwoHandedAxe : BaseAxe
    {
        //public override int DefMinDamage { get { return 9; } }
        //public override int DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public TwoHandedAxe()
            : base(0x1443)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Matar"; // Because why not.
        }

        public TwoHandedAxe(Serial serial)
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

    public class Venmar : BaseAxe
    {
        //public override int DefMinDamage { get { return 7; } }
        //public override int DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Venmar()
            : base(0x2972)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Venmar"; // Because why not.
        }

        public Venmar(Serial serial)
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
        //public override int DefMinDamage { get { return 7; } }
        //public override int DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Viftranche()
            : base(0x2970)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Viftranche"; // Because why not.
        }

        public Viftranche(Serial serial)
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

    public class Morgate : BaseAxe
    {
        //public override int DefMinDamage { get { return 9; } }
        //public override int DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Morgate()
            : base(0x296c)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Morgate"; // Because why not.
        }

        public Morgate(Serial serial)
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

    public class DoubleAxe : BaseAxe
    {
        //public override int DefMinDamage { get { return 4; } }
        //public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 20; } }

        [Constructable]
        public DoubleAxe()
            : base(0x296c)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Doublache"; // Because why not.
        }

        public DoubleAxe(Serial serial)
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
