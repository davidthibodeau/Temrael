using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Mobiles;

namespace Server.Items
{
    public abstract class BaseRaceGumps : Item
    {
        public virtual int BodyMod { get { return -1; } }
        public virtual int HueMod { get { return -1; } }

        public BaseRaceGumps(int itemID)
            : this(itemID, 0)
        {
        }

        public BaseRaceGumps(int itemID, int hue)
            : base(itemID)
        {
            Movable = false;
            Hue = hue;
            Layer = Layer.Shirt; //(Layer)ItemData.Quality;
        }

        public BaseRaceGumps(Serial serial)
            : base(serial)
        {
        }

        public override void OnSingleClick(Mobile from)
        {
        }

        public override void OnAdded(IEntity parent)
        {
            Mobile mob = parent as Mobile;

            if (mob != null)
                AddProperties(mob);

            base.OnAdded(parent);
        }

        public override void OnRemoved(IEntity parent)
        {
            Mobile mob = parent as Mobile;

            if (mob != null)
                RemoveProperties(mob);

            base.OnRemoved(parent);
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            if (Name != null)
                list.Add(1060601, "{0}", Name);
            else
                list.Add(LabelNumber);
        }

        public virtual void AddProperties(Mobile mob/*, bool ondeserialize*/)
        {
            if (BodyMod != -1)
                mob.BodyMod = BodyMod;

            if (HueMod != -1)
                mob.HueMod = HueMod;

            mob.Delta(MobileDelta.Armor);
            mob.Delta(MobileDelta.Body);
        }

        public virtual void RemoveProperties(Mobile mob)
        {
            if (BodyMod != -1)
                mob.BodyMod = 0;

            if (HueMod != -1)
                mob.HueMod = -1;

            mob.Delta(MobileDelta.Armor);
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

            if (Parent is Mobile)
                AddProperties((Mobile)Parent/*, true*/);
        }
    }
}