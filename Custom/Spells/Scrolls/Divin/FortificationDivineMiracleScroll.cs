using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class FortificationDivineMiracleScroll : SpellScroll
    {
        [Constructable]
        public FortificationDivineMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public FortificationDivineMiracleScroll(int amount)
            : base(2017, 0x227B, amount)
        {
            Name = "Fortification Divine";
        }

        public FortificationDivineMiracleScroll(Serial serial)
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