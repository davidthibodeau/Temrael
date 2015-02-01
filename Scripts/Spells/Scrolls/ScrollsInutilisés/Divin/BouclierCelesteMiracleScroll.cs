using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class BouclierCelesteMiracleScroll : SpellScroll
    {
        [Constructable]
        public BouclierCelesteMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public BouclierCelesteMiracleScroll(int amount)
            : base(2014, 0x227B, amount)
        {
        }

        public BouclierCelesteMiracleScroll(Serial serial)
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