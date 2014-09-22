using System;
using System.Xml;
using Server;
using Server.Mobiles;

namespace Server.Regions
{
    public class TavernElamsham : TavernRegion
    {
        public override Race RaceType
        {
            get { return Race.ElfeNoir; }
        }

        public TavernElamsham(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}