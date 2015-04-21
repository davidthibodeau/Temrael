using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        private List<PVPEvent> m_PVPevent;

        [Constructable]
        public PVPStone() 
            : base(0x2312)
        {
            MakeUnique();
        }

        public override void OnLocationChange(Point3D oldLocation)
        {
            base.OnLocationChange(oldLocation);

            Point1 = new Point3D(Location.X + 1, Location.Y, Location.Z);
            Point2 = new Point3D(Location.X + 1, Location.Y, Location.Z);
        }

        public override void OnDoubleClick(Mobile from)
        {
            m_PVPevent = new List<PVPEvent>();

            for (int i = 0; i < 40; i++)
            {
                PVPEvent p = new PVPEvent(this);

                p.nom = "Derp" + i.ToString();
                p.SetMap(0);
                p.SetMode(0);
                p.debutEvent = DateTime.Now.AddMinutes(10);
                p.AjouterEquipe();

                m_PVPevent.Add(p);
            }

            from.SendGump(new PVPGumpJoin(from));
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
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            rect = reader.ReadRect3D();
        }
    }
}
