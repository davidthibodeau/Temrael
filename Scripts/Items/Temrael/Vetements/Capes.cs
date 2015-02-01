using System;
using Server.Items;

namespace Server.Items
{
    public class CapeNoble : BaseCloak
    {
        [Constructable]
        public CapeNoble() : this(0)
        {
        }

        [Constructable]
        public CapeNoble(int hue)
            : base(0x2712, hue)
        {
            Weight = 5.0;
            Name = "Cape Noble";
        }

        public CapeNoble(Serial serial)
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

    public class CapeVoyage : BaseCloak
    {
        [Constructable]
        public CapeVoyage()
            : this(0)
        {
        }

        [Constructable]
        public CapeVoyage(int hue)
            : base(0x2713, hue)
        {
            Weight = 5.0;
            Name = "Cape Voyage";
        }

        public CapeVoyage(Serial serial)
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
    public class CapeCapuche : BaseCloak
    {
        public override bool Disguise { get { return true; } }

        [Constructable]
        public CapeCapuche()
            : this(0)
        {
        }

        [Constructable]
        public CapeCapuche(int hue)
            : base(0x2714, hue)
        {
            Weight = 5.0;
            Name = "Cape Capuche";
        }

        public CapeCapuche(Serial serial)
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
    public class CapeCagoule : BaseCloak
    {
        public override bool Disguise { get { return true; } }

        [Constructable]
        public CapeCagoule()
            : this(0)
        {
        }

        [Constructable]
        public CapeCagoule(int hue)
            : base(0x2715, hue)
        {
            Weight = 5.0;
            Name = "Cape Cagoule";
        }

        public CapeCagoule(Serial serial)
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
    public class CapeDecore : BaseCloak
    {
        [Constructable]
        public CapeDecore()
            : this(0)
        {
        }

        [Constructable]
        public CapeDecore(int hue)
            : base(0x2716, hue)
        {
            Weight = 5.0;
            Name = "Cape Decore";
        }

        public CapeDecore(Serial serial)
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
    public class CapeBarbare : BaseCloak
    {
        [Constructable]
        public CapeBarbare()
            : this(0)
        {
        }

        [Constructable]
        public CapeBarbare(int hue)
            : base(0x2717, hue)
        {
            Weight = 5.0;
            Name = "Cape Barbare";
        }

        public CapeBarbare(Serial serial)
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
    public class CapeColLong : BaseCloak
    {
        [Constructable]
        public CapeColLong()
            : this(0)
        {
        }

        [Constructable]
        public CapeColLong(int hue)
            : base(0x2718, hue)
        {
            Weight = 5.0;
            Name = "Cape a Col Long";
        }

        public CapeColLong(Serial serial)
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
    public class CapeLongue : BaseCloak
    {
        [Constructable]
        public CapeLongue()
            : this(0)
        {
        }

        [Constructable]
        public CapeLongue(int hue)
            : base(0x2719, hue)
        {
            Weight = 5.0;
            Name = "Cape Longue";
        }

        public CapeLongue(Serial serial)
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
    public class CapeTrainee : BaseCloak
    {
        [Constructable]
        public CapeTrainee()
            : this(0)
        {
        }

        [Constructable]
        public CapeTrainee(int hue)
            : base(0x271A, hue)
        {
            Weight = 5.0;
            Name = "Cape a Trainee";
        }

        public CapeTrainee(Serial serial)
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
    public class CapeSolide : BaseCloak
    {
        [Constructable]
        public CapeSolide()
            : this(0)
        {
        }

        [Constructable]
        public CapeSolide(int hue)
            : base(0x271B, hue)
        {
            Weight = 5.0;
            Name = "Cape Solide";
        }

        public CapeSolide(Serial serial)
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
    public class CapeEpauliere : BaseCloak
    {
        [Constructable]
        public CapeEpauliere()
            : this(0)
        {
        }

        [Constructable]
        public CapeEpauliere(int hue)
            : base(0x271C, hue)
        {
            Weight = 5.0;
            Name = "Cape Epauliere";
        }

        public CapeEpauliere(Serial serial)
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
    public class CapeCourte : BaseCloak
    {
        [Constructable]
        public CapeCourte()
            : this(0)
        {
        }

        [Constructable]
        public CapeCourte(int hue)
            : base(0x271D, hue)
        {
            Weight = 5.0;
            Name = "Cape Courte";
        }

        public CapeCourte(Serial serial)
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
    public class CapePlume : BaseCloak
    {
        [Constructable]
        public CapePlume()
            : this(0)
        {
        }

        [Constructable]
        public CapePlume(int hue)
            : base(0x271E, hue)
        {
            Weight = 5.0;
            Name = "Cape a Plume";
        }

        public CapePlume(Serial serial)
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
    public class CapeCol : BaseCloak
    {
        [Constructable]
        public CapeCol()
            : this(0)
        {
        }

        [Constructable]
        public CapeCol(int hue)
            : base(0x271F, hue)
        {
            Weight = 5.0;
            Name = "Cape a Col";
        }

        public CapeCol(Serial serial)
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
    public class CapeFourrure : BaseCloak
    {
        [Constructable]
        public CapeFourrure()
            : this(0)
        {
        }

        [Constructable]
        public CapeFourrure(int hue)
            : base(0x2720, hue)
        {
            Weight = 5.0;
            Name = "Cape Fourrure";
        }

        public CapeFourrure(Serial serial)
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
    public class CapeFeminine : BaseCloak
    {
        [Constructable]
        public CapeFeminine()
            : this(0)
        {
        }

        [Constructable]
        public CapeFeminine(int hue)
            : base(0x2721, hue)
        {
            Weight = 5.0;
            Name = "Cape Feminine";
        }

        public CapeFeminine(Serial serial)
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
    public class CapeNordique : BaseCloak
    {
        [Constructable]
        public CapeNordique()
            : this(0)
        {
        }

        [Constructable]
        public CapeNordique(int hue)
            : base(0x2722, hue)
        {
            Weight = 5.0;
            Name = "Cape Nordique";
        }

        public CapeNordique(Serial serial)
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
    public class CapeJarl : BaseCloak
    {
        [Constructable]
        public CapeJarl()
            : this(0)
        {
        }

        [Constructable]
        public CapeJarl(int hue)
            : base(0x2723, hue)
        {
            Weight = 5.0;
            Name = "Cape Nordique";
        }

        public CapeJarl(Serial serial)
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
    public class CapeElfique : BaseCloak
    {
        [Constructable]
        public CapeElfique()
            : this(0)
        {
        }

        [Constructable]
        public CapeElfique(int hue)
            : base(0x2893, hue)
        {
            Weight = 5.0;
            Name = "Cape Elfique";
        }

        public CapeElfique(Serial serial)
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
    public class CapeSombre : BaseCloak
    {
        [Constructable]
        public CapeSombre()
            : this(0)
        {
        }

        [Constructable]
        public CapeSombre(int hue)
            : base(0x3160, hue)
        {
            Weight = 5.0;
            Name = "Cape Sombre";
        }

        public CapeSombre(Serial serial)
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
    public class CapePoil : BaseCloak
    {
        [Constructable]
        public CapePoil()
            : this(0)
        {
        }

        [Constructable]
        public CapePoil(int hue)
            : base(0x3180, hue)
        {
            Weight = 5.0;
            Name = "Cape a Poil";
        }

        public CapePoil(Serial serial)
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
    public class CapeEtendard : BaseCloak
    {
        [Constructable]
        public CapeEtendard()
            : this(0)
        {
        }

        [Constructable]
        public CapeEtendard(int hue)
            : base(0x2D28, hue)
        {
            Weight = 5.0;
            Name = "Cape à Étendard";
            Layer = Layer.Waist;
        }

        public CapeEtendard(Serial serial)
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
