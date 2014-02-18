using System;
using System.Xml;
using Server;
using Server.Mobiles;

namespace Server.Regions
{
    public class InnCitarel : TavernRegion
    {
        public override Races RaceType
        {
            get { return Races.Capiceen; }
        }

        public InnCitarel(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}