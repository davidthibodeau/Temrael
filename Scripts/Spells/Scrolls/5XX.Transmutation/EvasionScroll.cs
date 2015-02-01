using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Spells.Scrolls.Transmutation
{
    namespace Server.Items
    {
        public class EvasionScroll : SpellScroll
        {
            [Constructable]
            public EvasionScroll()
                : this(1)
            {
            }

            [Constructable]
            public EvasionScroll(int amount)
                : base(EvasionSpell.m_SpellID, 0x1F5B, amount)
            {
                Name = "Transmutation: Evasion";
            }

            public EvasionScroll(Serial serial)
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
}
