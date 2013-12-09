using System;
using System.Xml;
using Server;
using Server.Mobiles;

namespace Server.Regions
{
    public class TavernBrandheim : TavernRegion
    {
        public override Races RaceType
        {
            get { return Races.Nordique; }
        }

        public TavernBrandheim(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}