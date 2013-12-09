using System;
using System.Xml;
using Server.Mobiles;

namespace Server.Territories
{
    public class TerritoryMelandre : TerritoryRegion
    {
        public override Races RaceType { get { return Races.Nomade; } }

        public TerritoryMelandre(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}