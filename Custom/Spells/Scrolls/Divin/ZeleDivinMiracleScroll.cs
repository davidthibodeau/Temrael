using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class ZeleDivinMiracleScroll : SpellScroll
    {
        [Constructable]
        public ZeleDivinMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public ZeleDivinMiracleScroll(int amount)
            : base(2023, 0x227B, amount)
        {
            Name = "Zèle";
        }

        public ZeleDivinMiracleScroll(Serial serial)
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