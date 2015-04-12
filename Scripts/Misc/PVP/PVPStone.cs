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

        private PVPEvent pvpevent;

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
            if (pvpevent == null)
            {
                pvpevent = new PVPEvent(this);
            }

            pvpevent.SetMap(0);
            pvpevent.SetMode(0);

            if (pvpevent.Teams.Count == 0)
            {
                pvpevent.AjouterEquipe();
            }

            pvpevent.Inscrire(from, 0);

            pvpevent.debutEvent = DateTime.Now.Add(TimeSpan.FromSeconds(20));

            if (pvpevent.Teams[0].joueurs.Count == 2)
            {
                pvpevent.PrepareEvent();
            }
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
