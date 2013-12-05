using System;
using System.Xml;
using Server;
using Server.Mobiles;

namespace Server.Regions
{
    public class CitarelCommerce : CommerceRegion
    {
        public CitarelCommerce(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}