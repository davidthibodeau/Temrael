using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
    public class EtouffementScroll : SpellScroll
    {
        [Constructable]
        public EtouffementScroll()
            : this(1)
        {
        }

        [Constructable]
        public EtouffementScroll(int amount)
            : base(EtouffementSpell.m_SpellID, 0x1F5E, amount)
        {
            Name = "Immuabilité: Étouffement";
        }

        public EtouffementScroll(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
}