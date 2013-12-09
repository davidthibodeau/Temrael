using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class FerveurDivineMiracleScroll : SpellScroll
    {
        [Constructable]
        public FerveurDivineMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public FerveurDivineMiracleScroll(int amount)
            : base(2016, 0x227B, amount)
        {
            Name = "Ferveur Divine";
        }

        public FerveurDivineMiracleScroll(Serial serial)
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