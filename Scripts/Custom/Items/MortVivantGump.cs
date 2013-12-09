using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Accounting;

namespace Server.Items
{
    public class MortVivantStone : Item
    {
        public override bool CanBeAltered
        {
            get
            {
                return false;
            }
        }

        [Constructable]
        public MortVivantStone()
            : base(3798)
        {
            Movable = false;
            Name = "Mort Vivant";
        }

        public override void OnDoubleClick(Mobile from)
        {
            from.SendGump(new MortVivantGump((TMobile)from));
        }

        public MortVivantStone(Serial serial)
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

