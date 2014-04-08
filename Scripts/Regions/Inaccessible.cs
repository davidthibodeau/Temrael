using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Server.Regions
{
    public class Inaccessible : Region
    {
        //Region utilisee pour les parties de map bloquees.
        public Inaccessible(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }

        public override bool AllowSpawn()
        {
            return false;
        }
    }
}
