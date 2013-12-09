using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class ExtaseMiracleScroll : SpellScroll
    {
        [Constructable]
        public ExtaseMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public ExtaseMiracleScroll(int amount)
            : base(2002, 0x227B, amount)
        {
            Name = "Extase";
        }

        public ExtaseMiracleScroll(Serial serial)
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