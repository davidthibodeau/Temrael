using System;
using System.Xml;
using System.Collections;
using Server;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Regions;
using Server.Items;

namespace Server.Regions
{
    public class CommerceRegion : Region
    {
        //public override MusicName DefaultMusic { get { return MusicName.Tavern04; } }

        public CommerceRegion(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }

        public override void OnEnter(Mobile m)
        {
            m.SendMessage("Vous pénétrez dans le marché de la ville");
        }

        public override void OnExit(Mobile m)
        {
            m.SendMessage("Vous quittez le marché de la ville.");
        }
    }

    public class CommerceCitarel : CommerceRegion
    {
        public CommerceCitarel(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }

    public class CommerceElamsham : CommerceRegion
    {
        public CommerceElamsham(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }

    public class CommerceMelandre : CommerceRegion
    {
        public CommerceMelandre(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }

    public class CommerceSerenite : CommerceRegion
    {
        public CommerceSerenite(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}