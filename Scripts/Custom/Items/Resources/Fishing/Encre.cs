using System;
using Server;

namespace Server.Items
{
    public class Encre : Item
    {
        [Constructable]
        public Encre() : this(1)
        {
        }

        [Constructable]
        public Encre(int amount) : base(0xF82)
        {
            Hue = 1107;
            Name = "fiole d'encre";
            Stackable = true;
            Amount = amount;
        }

        public Encre(Serial serial) : base(serial)
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