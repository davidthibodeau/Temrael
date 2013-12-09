using System;
using Server.Items;

namespace Server.Items
{
    public class TogeSorcier : BaseOuterTorso
    {
        [Constructable]
        public TogeSorcier()
            : this(0)
        {
        }

        [Constructable]
        public TogeSorcier(int hue)
            : base(0x278B, hue)
        {
            Weight = 5.0;
            Name = "Toge de Sorcier";
        }

        public TogeSorcier(Serial serial)
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
    public class TogeAmple : BaseOuterTorso
    {
        [Constructable]
        public TogeAmple()
            : this(0)
        {
        }

        [Constructable]
        public TogeAmple(int hue)
            : base(0x278C, hue)
        {
            Weight = 5.0;
            Name = "Toge Ample";
        }

        public TogeAmple(Serial serial)
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
    public class TogeMystique : BaseOuterTorso
    {
        [Constructable]
        public TogeMystique()
            : this(0)
        {
        }

        [Constructable]
        public TogeMystique(int hue)
            : base(0x278D, hue)
        {
            Weight = 5.0;
            Name = "Toge Mystique";
        }

        public TogeMystique(Serial serial)
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
    public class TogeVoyage : BaseOuterTorso
    {
        [Constructable]
        public TogeVoyage()
            : this(0)
        {
        }

        [Constructable]
        public TogeVoyage(int hue)
            : base(0x278E, hue)
        {
            Weight = 5.0;
            Name = "Toge de Voyage";
        }

        public TogeVoyage(Serial serial)
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
    public class TogeSoutane : BaseOuterTorso
    {
        public override bool Disguise { get { return true; } }

        [Constructable]
        public TogeSoutane()
            : this(0)
        {
        }

        [Constructable]
        public TogeSoutane(int hue)
            : base(0x278F, hue)
        {
            Weight = 5.0;
            Name = "Soutane";
        }

        public TogeSoutane(Serial serial)
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
    public class TogeReligieuse : BaseOuterTorso
    {
        [Constructable]
        public TogeReligieuse()
            : this(0)
        {
        }

        [Constructable]
        public TogeReligieuse(int hue)
            : base(0x2790, hue)
        {
            Weight = 5.0;
            Name = "Toge Religieuse";
        }

        public TogeReligieuse(Serial serial)
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
    public class TogeDecore : BaseOuterTorso
    {
        [Constructable]
        public TogeDecore()
            : this(0)
        {
        }

        [Constructable]
        public TogeDecore(int hue)
            : base(0x2791, hue)
        {
            Weight = 5.0;
            Name = "Toge Decore";
        }

        public TogeDecore(Serial serial)
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
    public class Toge : BaseOuterTorso
    {
        [Constructable]
        public Toge()
            : this(0)
        {
        }

        [Constructable]
        public Toge(int hue)
            : base(0x2792, hue)
        {
            Weight = 5.0;
            Name = "Toge";
        }

        public Toge(Serial serial)
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
    public class TogeFeminine : BaseOuterTorso
    {
        [Constructable]
        public TogeFeminine()
            : this(0)
        {
        }

        [Constructable]
        public TogeFeminine(int hue)
            : base(0x2793, hue)
        {
            Weight = 5.0;
            Name = "Toge Feminine";
        }

        public TogeFeminine(Serial serial)
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
    public class TogeGoetie : BaseOuterTorso
    {
        [Constructable]
        public TogeGoetie()
            : this(0)
        {
        }

        [Constructable]
        public TogeGoetie(int hue)
            : base(0x2794, hue)
        {
            Weight = 5.0;
            Name = "Toge de Goetie";
        }

        public TogeGoetie(Serial serial)
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
    public class TogeDiciple : BaseOuterTorso
    {
        [Constructable]
        public TogeDiciple()
            : this(0)
        {
        }

        [Constructable]
        public TogeDiciple(int hue)
            : base(0x2796, hue)
        {
            Weight = 5.0;
            Name = "Toge Diciple";
        }

        public TogeDiciple(Serial serial)
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
    public class TogePelerin : BaseOuterTorso
    {
        [Constructable]
        public TogePelerin()
            : this(0)
        {
        }

        [Constructable]
        public TogePelerin(int hue)
            : base(0x2797, hue)
        {
            Weight = 5.0;
            Name = "Toge Pelerin";
        }

        public TogePelerin(Serial serial)
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
    public class TogeElfique : BaseOuterTorso
    {
        [Constructable]
        public TogeElfique()
            : this(0)
        {
        }

        [Constructable]
        public TogeElfique(int hue)
            : base(0x2895, hue)
        {
            Weight = 5.0;
            Name = "Toge Elfique";
        }

        public TogeElfique(Serial serial)
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
    public class TogeDrow : BaseOuterTorso
    {
        [Constructable]
        public TogeDrow()
            : this(0)
        {
        }

        [Constructable]
        public TogeDrow(int hue)
            : base(0x2896, hue)
        {
            Weight = 5.0;
            Name = "Toge Elfe Noir";
        }

        public TogeDrow(Serial serial)
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
    public class TogeArchiMage : BaseOuterTorso
    {
        [Constructable]
        public TogeArchiMage()
            : this(0)
        {
        }

        [Constructable]
        public TogeArchiMage(int hue)
            : base(0x2B78, hue)
        {
            Weight = 5.0;
            Name = "Toge d'Archimage";
        }

        public TogeArchiMage(Serial serial)
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
    public class TogeHautElfe : BaseOuterTorso
    {
        [Constructable]
        public TogeHautElfe()
            : this(0)
        {
        }

        [Constructable]
        public TogeHautElfe(int hue)
            : base(0x2BD9, hue)
        {
            Weight = 5.0;
            Name = "Toge d'Haut Elfe";
        }

        public TogeHautElfe(Serial serial)
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
    public class TogeOrient : BaseOuterTorso
    {
        [Constructable]
        public TogeOrient()
            : this(0)
        {
        }

        [Constructable]
        public TogeOrient(int hue)
            : base(0x2BE0, hue)
        {
            Weight = 5.0;
            Name = "Toge d'Orient";
        }

        public TogeOrient(Serial serial)
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
    public class TogeOr : BaseOuterTorso
    {
        [Constructable]
        public TogeOr()
            : this(0)
        {
        }

        [Constructable]
        public TogeOr(int hue)
            : base(0x2BE2, hue)
        {
            Weight = 5.0;
            Name = "Toge d'Or";
        }

        public TogeOr(Serial serial)
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
    public class TogeNomade : BaseOuterTorso
    {
        [Constructable]
        public TogeNomade()
            : this(0)
        {
        }

        [Constructable]
        public TogeNomade(int hue)
            : base(0x3165, hue)
        {
            Weight = 5.0;
            Name = "Toge de Nomade";
        }

        public TogeNomade(Serial serial)
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
