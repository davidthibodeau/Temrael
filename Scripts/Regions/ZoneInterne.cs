using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Server.Regions
{
    public class ZoneInterne : BaseRegion
    {
        public ZoneInterne(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }

    public class ZoneCreation : ZoneInterne
    {
        public ZoneCreation(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }

    public class ZoneMort : ZoneInterne
    {
        public ZoneMort(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}
