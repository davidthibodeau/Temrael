using System;
using Server;

namespace Server.Items
{
    public class HuileMorue : Item
    {
        [Constructable]
        public HuileMorue() : this(1)
        {
        }

        [Constructable]
        public HuileMorue(int amount) : base(0xF82)
        {
            Hue = 1883;
            Name = "huile de morue";
            Stackable = true;
            Amount = amount;
        }

        public HuileMorue(Serial serial) : base(serial)
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