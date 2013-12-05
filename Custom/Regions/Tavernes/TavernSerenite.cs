using System;
using System.Xml;
using Server;
using Server.Mobiles;

namespace Server.Regions
{
    public class TavernSerenite : TavernRegion
    {
        public override Races RaceType
        {
            get { return Races.Elfe; }
        }

        public TavernSerenite(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}