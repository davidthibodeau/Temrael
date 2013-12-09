using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class ArdeurCelesteScroll : SpellScroll
    {
        [Constructable]
        public ArdeurCelesteScroll()
            : this(1)
        {
        }

        [Constructable]
        public ArdeurCelesteScroll(int amount)
            : base(2012, 0x227B, amount)
        {
            Name = "Ardeur Céleste";
        }

        public ArdeurCelesteScroll(Serial serial)
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