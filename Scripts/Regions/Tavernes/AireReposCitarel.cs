using System;
using System.Xml;
using Server;
using Server.Mobiles;

namespace Server.Regions
{
    public class AireReposCitarel : TavernRegion
    {
        public override Race RaceType
        {
            get { return Race.Capiceen; }
        }

        public AireReposCitarel(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}