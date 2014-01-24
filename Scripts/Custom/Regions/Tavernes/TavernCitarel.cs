using System;
using System.Xml;
using Server;
using Server.Mobiles;

namespace Server.Regions
{
    public class TavernCitarel : TavernRegion
    {
        public override Races RaceType
        {
            get { return Races.Capiceen; }
        }

        public TavernCitarel(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}