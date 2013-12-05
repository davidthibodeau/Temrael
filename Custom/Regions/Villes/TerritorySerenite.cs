using System;
using System.Xml;
using Server.Mobiles;

namespace Server.Territories
{
    public class TerritorySerenite : TerritoryRegion
    {
        public override Races RaceType { get { return Races.Elfe; } }

        public TerritorySerenite(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}