using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Commands;
using Server.Misc;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Regions;
using Server.Movement;
using Server.Spells.Fifth;
using Server.Spells.Seventh;
using Server.Spells.Necromancy;
using Server.Spells;
using Server.Mobiles;
using Server.Multis;
using Server.ContextMenus;

namespace Server.Mobiles
{
    abstract class GardeSimple : BaseCreature
    {

        public GardeSimple()
            : base(AIType.AI_Army, FightMode.Closest, 2, 1, 0.5, 2)
        {

        }

        public GardeSimple(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version

        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
