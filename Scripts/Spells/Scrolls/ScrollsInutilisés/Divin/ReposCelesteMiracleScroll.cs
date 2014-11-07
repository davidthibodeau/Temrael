using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class ReposCelesteMiracleScroll : SpellScroll
    {
        [Constructable]
        public ReposCelesteMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public ReposCelesteMiracleScroll(int amount)
            : base(2008, 0x227B, amount)
        {
            Name = "Repos Céleste";
        }

        public ReposCelesteMiracleScroll(Serial serial)
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