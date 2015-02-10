using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    // Main gauche
    //public class Imperlame : BaseKnife
    //{
    //    //public override int DefMinDamage { get { return 2; } }
    //    //public override int DefMaxDamage { get { return 5; } }
    //    public override int DefSpeed { get { return 30; } }

    //    [Constructable]
    //    public Imperlame()
    //        : base(0x2991)
    //    {
    //        Weight = 3.0;
    //        Layer = Layer.OneHanded;
    //        Name = "Imperlame";
    //    }

    //    public Imperlame(Serial serial)
    //        : base(serial)
    //    {
    //    }

    //    public override void Serialize(GenericWriter writer)
    //    {
    //        base.Serialize(writer);

    //        writer.Write((int)0); // version
    //    }

    //    public override void Deserialize(GenericReader reader)
    //    {
    //        base.Deserialize(reader);

    //        int version = reader.ReadInt();
    //    }
    //}

    //public class Poignard : BaseKnife
    //{
    //    //public override int DefMinDamage { get { return 2; } }
    //    //public override int DefMaxDamage { get { return 5; } }
    //    public override int DefSpeed { get { return 30; } }

    //    [Constructable]
    //    public Poignard()
    //        : base(0x2988)
    //    {
    //        Weight = 3.0;
    //        Layer = Layer.OneHanded;
    //        Name = "Poignard";
    //    }

    //    public Poignard(Serial serial)
    //        : base(serial)
    //    {
    //    }

    //    public override void Serialize(GenericWriter writer)
    //    {
    //        base.Serialize(writer);

    //        writer.Write((int)0); // version
    //    }

    //    public override void Deserialize(GenericReader reader)
    //    {
    //        base.Deserialize(reader);

    //        int version = reader.ReadInt();
    //    }
    //}

    //public class Eblame : BaseKnife
    //{
    //    //public override int DefMinDamage { get { return 2; } }
    //    //public override int DefMaxDamage { get { return 5; } }
    //    public override int DefSpeed { get { return 30; } }

    //    [Constructable]
    //    public Eblame()
    //        : base(0x298d)
    //    {
    //        Weight = 3.0;
    //        Layer = Layer.OneHanded;
    //        Name = "Eblame";
    //    }

    //    public Eblame(Serial serial)
    //        : base(serial)
    //    {
    //    }

    //    public override void Serialize(GenericWriter writer)
    //    {
    //        base.Serialize(writer);

    //        writer.Write((int)0); // version
    //    }

    //    public override void Deserialize(GenericReader reader)
    //    {
    //        base.Deserialize(reader);

    //        int version = reader.ReadInt();
    //    }
    //}

    public class Basilarda : BaseKnife
    {
        //public override int DefMinDamage { get { return 2; } }
        //public override int DefMaxDamage { get { return 5; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Basilarda()
            : base(0x2d1e)
        {
            Weight = 3.0;
            Layer = Layer.OneHanded;
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

    public class Dagger : BaseKnife
    {
        //public override int DefMinDamage { get { return 2; } }
        //public override int DefMaxDamage { get { return 5; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Dagger()
            : base(0xf52)
        {
            Weight = 3.0;
            Layer = Layer.OneHanded;
            Name = "Dague";
        }

        public Dagger(Serial serial)
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
        //public override int DefMinDamage { get { return 2; } }
        //public override int DefMaxDamage { get { return 5; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Dentsombre()
            : base(0x298c)
        {
            Weight = 3.0;
            Layer = Layer.OneHanded;
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

    public class Dracourbe : BaseKnife
    {
        //public override int DefMinDamage { get { return 3; } }
        //public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Dracourbe()
            : base(0x2989)
        {
            Weight = 3.0;
            Layer = Layer.OneHanded;
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
        //public override int DefMinDamage { get { return 2; } }
        //public override int DefMaxDamage { get { return 5; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Ecorchette()
            : base(0x298a)
        {
            Weight = 3.0;
            Layer = Layer.OneHanded;
            Name = "Écorchette";
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

    public class Elvine : BaseKnife
    {
        //public override int DefMinDamage { get { return 3; } }
        //public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Elvine()
            : base(0x2d21)
        {
            Weight = 3.0;
            Layer = Layer.OneHanded;
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

    public class Lozure : BaseKnife
    {
        //public override int DefMinDamage { get { return 2; } }
        //public override int DefMaxDamage { get { return 5; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Lozure()
            : base(0x298e)
        {
            Weight = 3.0;
            Layer = Layer.OneHanded;
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

    public class Osseuse : BaseKnife
    {
        //public override int DefMinDamage { get { return 3; } }
        //public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Osseuse()
            : base(0x2d1f)
        {
            Weight = 3.0;
            Layer = Layer.OneHanded;
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

    public class Safrine : BaseKnife
    {
        //public override int DefMinDamage { get { return 2; } }
        //public override int DefMaxDamage { get { return 5; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Safrine()
            : base(0x298b)
        {
            Weight = 3.0;
            Layer = Layer.OneHanded;
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

    public class Serpentine : BaseKnife
    {
        //public override int DefMinDamage { get { return 2; } }
        //public override int DefMaxDamage { get { return 5; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Serpentine()
            : base(0x298f)
        {
            Weight = 3.0;
            Layer = Layer.OneHanded;
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

    public class Spadasine : BaseKnife
    {
        //public override int DefMinDamage { get { return 2; } }
        //public override int DefMaxDamage { get { return 5; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Spadasine()
            : base(0x2d20)
        {
            Weight = 3.0;
            Layer = Layer.OneHanded;
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

    public class Brillaume : BaseKnife
    {
        //public override int DefMinDamage { get { return 2; } }
        //public override int DefMaxDamage { get { return 5; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Brillaume()
            : base(0x2990)
        {
            Weight = 3.0;
            Layer = Layer.OneHanded;
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

    public class ButcherKnife : BaseKnife
    {
        public override int GoldValue { get { return 6; } }

        //public override int DefMinDamage { get { return 2; } }
        //public override int DefMaxDamage { get { return 5; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public ButcherKnife()
            : base(0x13f6)
        {
            Weight = 3.0;
            Layer = Layer.OneHanded;
            Name = "Couteau de boucher";
        }

        public ButcherKnife(Serial serial)
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

    public class Cleaver : BaseKnife
    {
        public override int GoldValue { get { return 6; } }

        //public override int DefMinDamage { get { return 3; } }
        //public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Cleaver()
            : base(0xec3)
        {
            Weight = 3.0;
            Layer = Layer.OneHanded;
            Name = "Couperet";
        }

        public Cleaver(Serial serial)
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

    public class SkinningKnife : BaseKnife
    {
        //public override int DefMinDamage { get { return 2; } }
        //public override int DefMaxDamage { get { return 5; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public SkinningKnife()
            : base(0xec4)
        {
            Weight = 3.0;
            Layer = Layer.OneHanded;
            Name = "Couteau à écorcher";
        }

        public SkinningKnife(Serial serial)
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
