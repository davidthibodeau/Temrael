using System;
using System.Xml;
using Server.Mobiles;

namespace Server.Territories
{
    public class TerritoryCitarel : TerritoryRegion
    {
        public override Races RaceType { get { return Races.Capiceen; } }

        public TerritoryCitarel(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}