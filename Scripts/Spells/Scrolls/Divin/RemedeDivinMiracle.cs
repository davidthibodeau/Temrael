using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class RemedeDivinMiracleScroll : SpellScroll
    {
        [Constructable]
        public RemedeDivinMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public RemedeDivinMiracleScroll(int amount)
            : base(2006, 0x227B, amount)
        {
            Name = "Remède Divin";
        }

        public RemedeDivinMiracleScroll(Serial serial)
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