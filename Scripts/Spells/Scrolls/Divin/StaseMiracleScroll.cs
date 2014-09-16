using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class StaseMiracleScroll : SpellScroll
    {
        [Constructable]
        public StaseMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public StaseMiracleScroll(int amount)
            : base(2010, 0x227B, amount)
        {
            Name = "Stase";
        }

        public StaseMiracleScroll(Serial serial)
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