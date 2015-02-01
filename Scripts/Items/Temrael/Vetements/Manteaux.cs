using System;
using Server.Items;

namespace Server.Items
{
    public class ManteauRaye : BaseOuterTorso
    {
        [Constructable]
        public ManteauRaye()
            : this(0)
        {
        }

        [Constructable]
        public ManteauRaye(int hue)
            : base(0x2785, hue)
        {
            Weight = 5.0;
            Name = "Manteau Raye";
        }

        public ManteauRaye(Serial serial)
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
    public class ManteauPardessus : BaseOuterTorso
    {
        [Constructable]
        public ManteauPardessus()
            : this(0)
        {
        }

        [Constructable]
        public ManteauPardessus(int hue)
            : base(0x2786, hue)
        {
            Weight = 5.0;
            Name = "Manteau Pardessus";
        }

        public ManteauPardessus(Serial serial)
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
    public class ManteauTabar : BaseOuterTorso
    {
        [Constructable]
        public ManteauTabar()
            : this(0)
        {
        }

        [Constructable]
        public ManteauTabar(int hue)
            : base(0x2787, hue)
        {
            Weight = 5.0;
            Name = "Manteau Tabar";
        }

        public ManteauTabar(Serial serial)
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
    public class ManteauNoble : BaseOuterTorso
    {
        [Constructable]
        public ManteauNoble()
            : this(0)
        {
        }

        [Constructable]
        public ManteauNoble(int hue)
            : base(0x2788, hue)
        {
            Weight = 5.0;
            Name = "Manteau Noble";
        }

        public ManteauNoble(Serial serial)
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
    public class ManteauLong : BaseOuterTorso
    {
        [Constructable]
        public ManteauLong()
            : this(0)
        {
        }

        [Constructable]
        public ManteauLong(int hue)
            : base(0x2789, hue)
        {
            Weight = 5.0;
            Name = "Manteau Long";
        }

        public ManteauLong(Serial serial)
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
    public class ManteauCourt : BaseOuterTorso
    {
        [Constructable]
        public ManteauCourt()
            : this(0)
        {
        }

        [Constructable]
        public ManteauCourt(int hue)
            : base(0x278A, hue)
        {
            Weight = 5.0;
            Name = "Manteau Court";
        }

        public ManteauCourt(Serial serial)
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
