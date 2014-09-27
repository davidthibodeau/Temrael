using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
    public class BourrasqueScroll : SpellScroll
    {
        [Constructable]
        public BourrasqueScroll()
            : this(1)
        {
        }

        [Constructable]
        public BourrasqueScroll(int amount) : base(Bourrasque.m_SpellID, 0x1F65, amount)
        {
            Name = "Évocation: Bourrasque";
        }

        public BourrasqueScroll(Serial serial) : base(serial)
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

            Name = "Évocation: Bourrasque";
        }
    }
}