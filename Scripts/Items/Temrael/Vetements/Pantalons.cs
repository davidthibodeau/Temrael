using System;
using Server.Items;

namespace Server.Items
{
    public class PantalonsElfiques : BasePants
    {
        [Constructable]
        public PantalonsElfiques()
            : this(0)
        {
        }

        [Constructable]
        public PantalonsElfiques(int hue)
            : base(0x2B08, hue)
        {
            Weight = 5.0;
            Name = "Pantalons Elfiques";
        }

        public PantalonsElfiques(Serial serial)
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

    public class PantalonsDechires : BasePants
    {
        [Constructable]
        public PantalonsDechires()
            : this(0)
        {
        }

        [Constructable]
        public PantalonsDechires(int hue)
            : base(0x2738, hue)
        {
            Weight = 5.0;
            Name = "Pantalons Dechires";
        }

        public PantalonsDechires(Serial serial)
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
    public class PantalonsPauvre : BasePants
    {
        [Constructable]
        public PantalonsPauvre()
            : this(0)
        {
        }

        [Constructable]
        public PantalonsPauvre(int hue)
            : base(0x2739, hue)
        {
            Weight = 5.0;
            Name = "Pantalons Pauvres";
        }

        public PantalonsPauvre(Serial serial)
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
    public class PantalonsNordique : BasePants
    {
        [Constructable]
        public PantalonsNordique()
            : this(0)
        {
        }

        [Constructable]
        public PantalonsNordique(int hue)
            : base(0x273A, hue)
        {
            Weight = 5.0;
            Name = "Pantalons Nordiques";
        }

        public PantalonsNordique(Serial serial)
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
    public class Pantalons : BasePants
    {
        [Constructable]
        public Pantalons()
            : this(0)
        {
        }

        [Constructable]
        public Pantalons(int hue)
            : base(0x273B, hue)
        {
            Weight = 5.0;
            Name = "Pantalons";
        }

        public Pantalons(Serial serial)
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
    public class PantalonsArmure : BasePants
    {
        [Constructable]
        public PantalonsArmure()
            : this(0)
        {
        }

        [Constructable]
        public PantalonsArmure(int hue)
            : base(0x273C, hue)
        {
            Weight = 5.0;
            Name = "Pantalons Armure";
        }

        public PantalonsArmure(Serial serial)
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
    public class PantalonsCourts : BasePants
    {
        [Constructable]
        public PantalonsCourts()
            : this(0)
        {
        }

        [Constructable]
        public PantalonsCourts(int hue)
            : base(0x273D, hue)
        {
            Weight = 5.0;
            Name = "Pantalons Courts";
        }

        public PantalonsCourts(Serial serial)
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
    public class PantalonsLongs : BasePants
    {
        [Constructable]
        public PantalonsLongs()
            : this(0)
        {
        }

        [Constructable]
        public PantalonsLongs(int hue)
            : base(0x273E, hue)
        {
            Weight = 5.0;
            Name = "Pantalons Longs";
        }

        public PantalonsLongs(Serial serial)
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
    public class PantalonsMoulant : BasePants
    {
        [Constructable]
        public PantalonsMoulant()
            : this(0)
        {
        }

        [Constructable]
        public PantalonsMoulant(int hue)
            : base(0x273F, hue)
        {
            Weight = 5.0;
            Name = "Pantalons Moulants";
        }

        public PantalonsMoulant(Serial serial)
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
    public class PantalonsNomade : BasePants
    {
        [Constructable]
        public PantalonsNomade()
            : this(0)
        {
        }

        [Constructable]
        public PantalonsNomade(int hue)
            : base(0x2BDF, hue)
        {
            Weight = 5.0;
            Name = "Pantalons d'Orient";
        }

        public PantalonsNomade(Serial serial)
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
    public class PantalonsCuir : BasePants
    {
        [Constructable]
        public PantalonsCuir()
            : this(0)
        {
        }

        [Constructable]
        public PantalonsCuir(int hue)
            : base(0x3177, hue)
        {
            Weight = 5.0;
            Name = "Pantalons de Cuir";
        }

        public PantalonsCuir(Serial serial)
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
    public class PantalonsOuvert : BasePants
    {
        [Constructable]
        public PantalonsOuvert()
            : this(0)
        {
        }

        [Constructable]
        public PantalonsOuvert(int hue)
            : base(0x3178, hue)
        {
            Weight = 5.0;
            Name = "Pantalons Ouvert";
        }

        public PantalonsOuvert(Serial serial)
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
    public class PantalonsOrient : BasePants
    {
        [Constructable]
        public PantalonsOrient()
            : this(0)
        {
        }

        [Constructable]
        public PantalonsOrient(int hue)
            : base(0x3179, hue)
        {
            Weight = 5.0;
            Name = "Pantalons d'Orient";
        }

        public PantalonsOrient(Serial serial)
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
