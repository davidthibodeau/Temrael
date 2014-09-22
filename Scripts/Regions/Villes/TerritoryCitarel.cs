using System;
using System.Xml;
using Server.Mobiles;

namespace Server.Territories
{
    public class TerritoryCitarel : TerritoryRegion
    {
        public override Race RaceType { get { return Race.Capiceen; } }

        public TerritoryCitarel(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}