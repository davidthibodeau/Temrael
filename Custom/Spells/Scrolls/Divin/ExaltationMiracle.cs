using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class ExaltationMiracleScroll : SpellScroll
    {
        [Constructable]
        public ExaltationMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public ExaltationMiracleScroll(int amount)
            : base(2001, 0x227B, amount)
        {
            Name = "Exaltation";
        }

        public ExaltationMiracleScroll(Serial serial)
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