using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class DefenseDivineMiracleScroll : SpellScroll
    {
        [Constructable]
        public DefenseDivineMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public DefenseDivineMiracleScroll(int amount)
            : base(2015, 0x227B, amount)
        {
            Name = "Défense Divine";
        }

        public DefenseDivineMiracleScroll(Serial serial)
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