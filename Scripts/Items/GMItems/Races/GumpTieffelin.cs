using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class AilesTieffelin : RaceGump
    {
        [Constructable]
        public AilesTieffelin()
            : this(0)
        {
        }

        [Constructable]
        public AilesTieffelin(int hue)
            : base(0x147B, hue)
        {
            Name = "Ailes";
            Layer = Layer.Cloak;
        }

        public AilesTieffelin(Serial serial)
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
            Name = "Ailes";
        }
    }
    public class CorpsTieffelin : RaceGump
    {
        [Constructable]
        public CorpsTieffelin()
            : this(0)
        {
        }

        [Constructable]
        public CorpsTieffelin(int hue)
            : base(0x147C, hue)
        {
            Name = "Tieffelin";
            Layer = Layer.Shirt;
        }

        public CorpsTieffelin(Serial serial)
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
            Name = "Tieffelin";
        }
    }
    public class CornesTieffelin : RaceGump
    {
        [Constructable]
        public CornesTieffelin()
            : this(0)
        {
        }

        [Constructable]
        public CornesTieffelin(int hue)
            : base(0x147D, hue)
        {
            Name = "Cornes";
            Layer = Layer.Helm;
        }

        public CornesTieffelin(Serial serial)
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
            Name = "Cornes";
        }
    }
}
