using System;
using System.Xml;
using Server.Mobiles;

namespace Server.Territories
{
    public class TerritoryBrandheim : TerritoryRegion
    {
        public override Races RaceType { get { return Races.Nordique; } }

        public TerritoryBrandheim(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}