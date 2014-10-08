using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    // Une main.
    public class Lancel : BaseSpear
    {
        public override int DefMinDamage { get { return 5; } }
        public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Lancel()
            : base(0x315a)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
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

    public class PerceCoeur : BaseSpear
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 13; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public PerceCoeur()
            : base(0x2987)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "PerceCoeur";
        }

        public PerceCoeur(Serial serial)
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

    public class PerceTronc : BaseSpear
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 11; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public PerceTronc()
            : base(0x297d)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "PerceTronc";
        }

        public PerceTronc(Serial serial)
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
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 13; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Piculame()
            : base(0x2980)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
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

    public class Halberd : BaseSpear
    {
        public override int DefMinDamage { get { return 10; } }
        public override int DefMaxDamage { get { return 15; } }
        public override int DefSpeed { get { return 45; } }

        [Constructable]
        public Halberd()
            : base(0x143e)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Hallebarde";
        }

        public Halberd(Serial serial)
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
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 11; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Mascarate()
            : base(0x2986)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
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

    public class Pique : BaseSpear
    {
        public override int DefMinDamage { get { return 5; } }
        public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Pique()
            : base(0x2984)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
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

    public class Racuris : BaseSpear
    {
        public override int DefMinDamage { get { return 10; } }
        public override int DefMaxDamage { get { return 15; } }
        public override int DefSpeed { get { return 45; } }

        [Constructable]
        public Racuris()
            : base(0x2983)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
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

    public class Lance : BaseSpear
    {
        public override int DefMinDamage { get { return 12; } }
        public override int DefMaxDamage { get { return 17; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public Lance()
            : base(0x26c0)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Lance";
        }

        public Lance(Serial serial)
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

    // Deux mains.
    public class Cythe : BaseSpear
    {
        public override int DefMinDamage { get { return 14; } }
        public override int DefMaxDamage { get { return 19; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public Cythe()
            : base(0x3041)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Cythe";
        }

        public Cythe(Serial serial)
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

    public class DoubleLance : BaseSpear
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public DoubleLance()
            : base(0x297c)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Double lance";
        }

        public DoubleLance(Serial serial)
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

    public class ShortSpear : BaseSpear
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public ShortSpear()
            : base(0x1403)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Lance courte";
        }

        public ShortSpear(Serial serial)
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

    public class Spear : BaseSpear
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Spear()
            : base(0xf62)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Lance";
        }

        public Spear(Serial serial)
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

    public class Terricharde : BaseSpear
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Terricharde()
            : base(0x297f)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
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

    public class WarFork : BaseSpear
    {
        public override int DefMinDamage { get { return 6; } }
        public override int DefMaxDamage { get { return 10; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public WarFork()
            : base(0x1405)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Pique de guerre";
        }

        public WarFork(Serial serial)
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

    public class Bardiche : BaseSpear
    {
        public override int DefMinDamage { get { return 14; } }
        public override int DefMaxDamage { get { return 19; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public Bardiche()
            : base(0xf4d)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Bardiche";
        }

        public Bardiche(Serial serial)
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

    public class Bardine : BaseSpear
    {
        public override int DefMinDamage { get { return 11; } }
        public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Bardine()
            : base(0x2979)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Bardine";
        }

        public Bardine(Serial serial)
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

    public class ExecutionersAxe : BaseSpear
    {
        public override int DefMinDamage { get { return 14; } }
        public override int DefMaxDamage { get { return 19; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public ExecutionersAxe()
            : base(0xf45)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Hache du bourreau";
        }

        public ExecutionersAxe(Serial serial)
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

    public class Granbarde : BaseSpear
    {
        public override int DefMinDamage { get { return 13; } }
        public override int DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 45; } }

        [Constructable]
        public Granbarde()
            : base(0x2977)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Granbarde";
        }

        public Granbarde(Serial serial)
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

    public class Guisarme : BaseSpear
    {
        public override int DefMinDamage { get { return 13; } }
        public override int DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 45; } }

        [Constructable]
        public Guisarme()
            : base(0x2978)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Guisarme";
        }

        public Guisarme(Serial serial)
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

    public class Hastiche : BaseSpear
    {
        public override int DefMinDamage { get { return 11; } }
        public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Hastiche()
            : base(0x297b)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Hastiche";
        }

        public Hastiche(Serial serial)
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

    public class Helbarde : BaseSpear
    {
        public override int DefMinDamage { get { return 13; } }
        public override int DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 45; } }

        [Constructable]
        public Helbarde()
            : base(0x3042)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Helbarde";
        }

        public Helbarde(Serial serial)
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

    public class Pitchfork : BaseSpear
    {
        public override int DefMinDamage { get { return 11; } }
        public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Pitchfork()
            : base(0xe87)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Fourche";
        }

        public Pitchfork(Serial serial)
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

    public class Scythe : BaseSpear
    {
        public override int DefMinDamage { get { return 13; } }
        public override int DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 45; } }

        [Constructable]
        public Scythe()
            : base(0x26ba)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Faux";
        }

        public Scythe(Serial serial)
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
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Transpercille()
            : base(0x2985)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
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

    public class Trident : BaseSpear
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Trident()
            : base(0x2981)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
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
        public override int DefMinDamage { get { return 11; } }
        public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Turione()
            : base(0x2982)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
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

    public class Vougue : BaseSpear
    {
        public override int DefMinDamage { get { return 6; } }
        public override int DefMaxDamage { get { return 10; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Vougue()
            : base(0x297a)
        {
            Weight = 8.0;
            Layer = Layer.TwoHanded;
            Name = "Vougue";
        }

        public Vougue(Serial serial)
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
