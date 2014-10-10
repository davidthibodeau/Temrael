using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class Cuivardise : BaseEstoc
    {
        public override int DefMinDamage { get { return 3; } }
        public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Cuivardise()
            : base(0x2999)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Cuivardise";
        }

        public Cuivardise(Serial serial)
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

    public class Estoc : BaseEstoc
    {
        public override int DefMinDamage { get { return 2; } }
        public override int DefMaxDamage { get { return 5; } }
        public override int DefSpeed { get { return 20; } }

        [Constructable]
        public Estoc()
            : base(0x2992)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Estoc";
        }

        public Estoc(Serial serial)
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

    public class Fleuret : BaseEstoc
    {
        public override int DefMinDamage { get { return 2; } }
        public override int DefMaxDamage { get { return 5; } }
        public override int DefSpeed { get { return 20; } }

        [Constructable]
        public Fleuret()
            : base(0x2994)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Fleuret";
        }

        public Fleuret(Serial serial)
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

    public class Lyzardese : BaseEstoc
    {
        public override int DefMinDamage { get { return 3; } }
        public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Lyzardese()
            : base(0x2996)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Fleuret";
        }

        public Lyzardese(Serial serial)
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

    public class Musareche : BaseEstoc
    {
        public override int DefMinDamage { get { return 2; } }
        public override int DefMaxDamage { get { return 5; } }
        public override int DefSpeed { get { return 20; } }

        [Constructable]
        public Musareche()
            : base(0x2997)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Musareche";
        }

        public Musareche(Serial serial)
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

    public class Percille : BaseEstoc
    {
        public override int DefMinDamage { get { return 3; } }
        public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Percille()
            : base(0x2998)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Percille";
        }

        public Percille(Serial serial)
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

    public class Rapiere : BaseEstoc
    {
        public override int DefMinDamage { get { return 5; } }
        public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Rapiere()
            : base(0x2995)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Rapiere";
        }

        public Rapiere(Serial serial)
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

    public class Brette : BaseEstoc
    {
        public override int DefMinDamage { get { return 5; } }
        public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Brette()
            : base(0x2993)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Brette";
        }

        public Brette(Serial serial)
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
