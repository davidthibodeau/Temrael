using System;
using System.Xml;
using Server;
using Server.Mobiles;

namespace Server.Regions
{
    public class TavernElamsham : TavernRegion
    {
        public override Races RaceType
        {
            get { return Races.ElfeNoir; }
        }

        public TavernElamsham(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}