using System;
using System.Xml;
using Server;
using Server.Mobiles;

namespace Server.Regions
{
    public class TavernBrandheim : TavernRegion
    {
        public override Race RaceType
        {
            get { return Race.Nordique; }
        }

        public TavernBrandheim(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}