using Server.Engines.Hiding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Mobiles
{
    public class ScriptMobile : Mobile
    {
        [CommandProperty(AccessLevel.Batisseur)]
        public Detection Detection
        {
            get;
            set;
        }

        public ScriptMobile()
        {
            Detection = new Detection(this);
        }

        public ScriptMobile(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); //version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            Detection = new Detection(this);
        }

        protected override void OnLocationChange(Point3D oldLocation)
        {
            base.OnLocationChange(oldLocation);

            ActiverTestsDetection();
        }

        protected override bool OnMove(Direction d)
        {
            ActiverTestsDetection();

            return base.OnMove(d);
        }

        public void ActiverTestsDetection()
        {
            //Le systeme de detection fonctionne juste pour les joueurs.
            if (AccessLevel > AccessLevel.Player) return;
            Detection.DetecterAlentours();
            if (Hidden)
                Detection.TesterPresenceAlentours();
        }

        public override void OnHiddenChanged()
        {
            base.OnHiddenChanged();
            Detection.ResetAlentours();
        }

    }
}
