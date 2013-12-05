using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class VehemenceMiracleScroll : SpellScroll
    {
        [Constructable]
        public VehemenceMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public VehemenceMiracleScroll(int amount)
            : base(2011, 0x227B, amount)
        {
            Name = "Véhémence";
        }

        public VehemenceMiracleScroll(Serial serial)
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