using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
    public class TempeteScroll : SpellScroll
    {
        [Constructable]
        public TempeteScroll()
            : this(1)
        {
        }

        [Constructable]
        public TempeteScroll(int amount) : base(Tempete.m_SpellID, 0x1F65, amount)
        {
            Name = "Évocation: Tempête";
        }

        public TempeteScroll(Serial serial) : base(serial)
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

            Name = "Évocation: Tempête";
        }
    }
}