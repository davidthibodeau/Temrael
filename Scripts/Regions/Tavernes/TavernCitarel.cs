using System;
using System.Xml;
using Server;
using Server.Mobiles;

namespace Server.Regions
{
    public class TavernCitarel : TavernRegion
    {
        public override Race RaceType
        {
            get { return Race.Capiceen; }
        }

        public TavernCitarel(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}