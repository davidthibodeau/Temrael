﻿using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class MortRaceGump : RaceGump
    {
        public virtual MortEvo EMort { get { return MortEvo.Aucune; } }

        public MortRaceGump(int itemID)
            : this(itemID, 0)
        {
        }

        public MortRaceGump(int itemID, int hue)
            : base(itemID, hue)
        {
        }

        public MortRaceGump(Serial serial)
            : base(serial)
        {
        }

        public override void OnSingleClick(Mobile from)
        {
        }

        public override void OnAdded(IEntity parent)
        {
            TMobile mob = parent as TMobile;

            if (mob != null)
            {
                mob.MortEvo = EMort;

                mob.Delta(MobileDelta.Hits);
                mob.Delta(MobileDelta.Stam);
                mob.Delta(MobileDelta.Mana);
            }

            base.OnAdded(parent);
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