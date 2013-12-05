using System;
using System.Xml;
using Server;
using Server.Mobiles;

namespace Server.Regions
{
    public class AireReposCitarel : TavernRegion
    {
        public override Races RaceType
        {
            get { return Races.Humain; }
        }

        public AireReposCitarel(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}