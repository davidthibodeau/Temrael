using System;
using System.Xml;
using Server;
using Server.Mobiles;

namespace Server.Regions
{
    public class TavernMelandre : TavernRegion
    {
        public override Race RaceType
        {
            get { return Race.Nomade; }
        }

        public TavernMelandre(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}