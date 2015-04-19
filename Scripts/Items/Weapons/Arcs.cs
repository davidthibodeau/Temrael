using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class Arc : BaseArc
    {
        public override int GoldValue { get { return 21; } }

        //public override double DefMinDamage { get { return 6; } }
        //public override double DefMaxDamage { get { return 10; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Arc()
            : base(0x2d24)
        {
            Weight = 8.0;
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

    public class Barbatrine : BaseArc
    {
        //public override double DefMinDamage { get { return 11; } }
        //public override double DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 60; } }

        [Constructable]
        public Barbatrine()
            : base(0x2d22)
        {
            Weight = 8.0;
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

    public class Blancorde : BaseArc
    {
        //public override double DefMinDamage { get { return 7; } }
        //public override double DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Blancorde()
            : base(0x2d27)
        {
            Weight = 8.0;
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

    public class GrandArc : BaseArc
    {
        //public override double DefMinDamage { get { return 14; } }
        //public override double DefMaxDamage { get { return 19; } }
        public override int DefSpeed { get { return 80; } }

        [Constructable]
        public GrandArc()
            : base(0x13b2)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Grand Arc";
        }

        public GrandArc(Serial serial)
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

    public class Composite : BaseArc
    {
        //public override double DefMinDamage { get { return 9; } }
        //public override double DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public Composite()
            : base(0x2fee)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Arc Composite";
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

    public class Ebonie : BaseArc
    {
        //public override double DefMinDamage { get { return 7; } }
        //public override double DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Ebonie()
            : base(0x2d23)
        {
            Weight = 8.0;
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

    public class Flamfleche : BaseArc
    {
        //public override double DefMinDamage { get { return 4; } }
        //public override double DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 20; } }

        [Constructable]
        public Flamfleche()
            : base(0x230a)
        {
            Weight = 8.0;
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

    public class Foliere : BaseArc
    {
        //public override double DefMinDamage { get { return 7; } }
        //public override double DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Foliere()
            : base(0x2d25)
        {
            Weight = 8.0;
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

    public class Sifflecrin : BaseArc
    {
        //public override double DefMinDamage { get { return 4; } }
        //public override double DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 20; } }

        [Constructable]
        public Sifflecrin()
            : base(0x299b)
        {
            Weight = 8.0;
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

    public class Souplecorde : BaseArc
    {
        //public override double DefMinDamage { get { return 6; } }
        //public override double DefMaxDamage { get { return 10; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Souplecorde()
            : base(0x299d)
        {
            Weight = 8.0;
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

    public class Sombrevent : BaseArc
    {
        //public override double DefMinDamage { get { return 11; } }
        //public override double DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 60; } }

        [Constructable]
        public Sombrevent()
            : base(0x299c)
        {
            Weight = 8.0;
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

    public class Chantefleche : BaseArc
    {
        //public override double DefMinDamage { get { return 9; } }
        //public override double DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public Chantefleche()
            : base(0x299a)
        {
            Weight = 8.0;
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

    public class Mirielle : BaseArc
    {
        //public override double DefMinDamage { get { return 13; } }
        //public override double DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 70; } }

        [Constructable]
        public Mirielle()
            : base(0x2ff1)
        {
            Weight = 8.0;
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

    public class Legarc : BaseArc
    {
        //public override double DefMinDamage { get { return 4; } }
        //public override double DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 20; } }

        [Constructable]
        public Legarc()
            : base(0x299f)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Legarc";
        }

        public Legarc(Serial serial)
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

    public class Vigne : BaseArc
    {
        //public override double DefMinDamage { get { return 14; } }
        //public override double DefMaxDamage { get { return 19; } }
        public override int DefSpeed { get { return 80; } }

        [Constructable]
        public Vigne()
            : base(0x2ff8)
        {
            Weight = 8.0;
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

    public class Glaciale : BaseArc
    {
        //public override double DefMinDamage { get { return 11; } }
        //public override double DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 60; } }

        [Constructable]
        public Glaciale()
            : base(0x2ff7)
        {
            Weight = 8.0;
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

    public class Maegie : BaseArc
    {
        //public override double DefMinDamage { get { return 13; } }
        //public override double DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 70; } }

        [Constructable]
        public Maegie()
            : base(0x2d26)
        {
            Weight = 8.0;
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

    public class Foudre : BaseArc
    {
        //public override double DefMinDamage { get { return 9; } }
        //public override double DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public Foudre()
            : base(0x2ff0)
        {
            Weight = 8.0;
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

    public class Tarkarc : BaseArc
    {
        //public override double DefMinDamage { get { return 6; } }
        //public override double DefMaxDamage { get { return 10; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Tarkarc()
            : base(0x299e)
        {
            Weight = 8.0;
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

    public class Pieuse : BaseArc
    {
        //public override double DefMinDamage { get { return 13; } }
        //public override double DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 70; } }

        [Constructable]
        public Pieuse()
            : base(0x2fef)
        {
            Weight = 8.0;
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
}
