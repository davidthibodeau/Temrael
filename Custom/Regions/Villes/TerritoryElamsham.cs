using System;
using System.Xml;
using Server.Mobiles;

namespace Server.Territories
{
    public class TerritoryElamsham : TerritoryRegion
    {
        public override Races RaceType { get { return Races.ElfeNoir; } }

        public TerritoryElamsham(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}