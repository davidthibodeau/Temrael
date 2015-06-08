using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Misc.PVP.Gumps;

namespace Server.Misc.PVP
{
    public class PVPStone : Item
    {
        [CommandProperty(AccessLevel.Batisseur)]
        public Point3D Point1
        {
            set { rect.Start = value; }
            get { return rect.Start; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public Point3D Point2
        {
            set { rect.End = value; }
            get { return rect.End; }
        }

        private Rectangle3D rect;

        [Constructable]
        public PVPStone() 
            : base(0x2312)
        {
            MakeUnique();
            Name = "Babillard des guerres.";
        }

        public override void OnLocationChange(Point3D oldLocation)
        {
            base.OnLocationChange(oldLocation);

            Point1 = new Point3D(Location.X + 1, Location.Y, Location.Z);
            Point2 = new Point3D(Location.X + 1, Location.Y, Location.Z);
        }

        public override void OnDoubleClick(Mobile from)
        {
            from.SendGump(new PVPGump(from, this));
        }

        public void TeleportRand(Mobile m)
        {
            Point3D p = rect.RandomPoint();

            m.MoveToWorld(p, this.Map);
            m.LogoutLocation = p;
        }

        public PVPStone(Serial serial) 
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(rect);

            int count;
            if (PVPEvent.m_InstancesList != null)
            {
                count = PVPEvent.m_InstancesList.Count;
            }
            else
            {
                count = 0;
            }
            writer.Write(count);

            if (PVPEvent.m_InstancesList != null)
            {
                for (int i = 0; i < count; ++i)
                {
                    ((PVPEvent)PVPEvent.m_InstancesList[i]).Serialize(writer);
                }
            }
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            rect = reader.ReadRect3D();

            int count = reader.ReadInt();
            for(int i = 0; i < count; ++i)
            {
                PVPEvent pvpevent = PVPEvent.CreateEvent(null, this);
                pvpevent.Deserialize(reader);
            }
        }
    }
}
