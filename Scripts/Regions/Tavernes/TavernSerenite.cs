using System;
using System.Xml;
using Server;
using Server.Mobiles;

namespace Server.Regions
{
    public class TavernSerenite : TavernRegion
    {
        public override Race RaceType
        {
            get { return Race.Elfe; }
        }

        public TavernSerenite(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}