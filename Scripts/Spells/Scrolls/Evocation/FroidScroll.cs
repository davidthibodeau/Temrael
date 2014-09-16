using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
    public class FroidScroll : SpellScroll
    {
        [Constructable]
        public FroidScroll()
            : this(1)
        {
        }

        [Constructable]
        public FroidScroll(int amount) : base(Froid.spellID, 0x1F65, amount)
        {
            Name = "Évocation: Froid";
        }

        public FroidScroll(Serial serial) : base(serial)
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

            Name = "Évocation: Froid";
        }
    }
}