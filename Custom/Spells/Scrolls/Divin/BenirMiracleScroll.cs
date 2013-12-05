using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class BenirMiracleScroll : SpellScroll
    {
        [Constructable]
        public BenirMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public BenirMiracleScroll(int amount)
            : base(2000, 0x227B, amount)
        {
            Name = "Bénir";
        }

        public BenirMiracleScroll(Serial serial)
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