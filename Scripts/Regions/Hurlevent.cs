using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Server.Regions
{
    public class Archipel : BaseRegion
    {
        public Archipel(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }

    public class IleHurlevent : Archipel
    {
        public IleHurlevent(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }

    public class VilleHurlevent : IleHurlevent
    {
        public VilleHurlevent(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}
