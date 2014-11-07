using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
    public class FlamecheScroll : SpellScroll
    {
        [Constructable]
        public FlamecheScroll()
            : this(1)
        {
        }

        [Constructable]
        public FlamecheScroll(int amount) : base(Flameche.m_SpellID, 0x1F65, amount)
        {
            Name = "Évocation: Flamèche";
        }

        public FlamecheScroll(Serial serial) : base(serial)
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

            Name = "Évocation: Flamèche";
        }
    }
}