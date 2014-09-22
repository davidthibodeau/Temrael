using System;
using System.Xml;
using Server.Mobiles;

namespace Server.Territories
{
    public class TerritoryElamsham : TerritoryRegion
    {
        public override Race RaceType { get { return Race.ElfeNoir; } }

        public TerritoryElamsham(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}