using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class RetablissementMiracleScroll : SpellScroll
    {
        [Constructable]
        public RetablissementMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public RetablissementMiracleScroll(int amount)
            : base(2009, 0x227B, amount)
        {
            Name = "Rétablissement";
        }

        public RetablissementMiracleScroll(Serial serial)
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