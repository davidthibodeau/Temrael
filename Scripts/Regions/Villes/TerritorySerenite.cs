using System;
using System.Xml;
using Server.Mobiles;

namespace Server.Territories
{
    public class TerritorySerenite : TerritoryRegion
    {
        public override Race RaceType { get { return Race.Elfe; } }

        public TerritorySerenite(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}