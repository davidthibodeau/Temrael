using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Server.Regions
{
    public class Archipel : BaseRegion
    {
        public Archipel(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }

    public class IleHurlevent : Archipel
    {
        public IleHurlevent(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }

    public class VilleHurlevent : IleHurlevent
    {
        public VilleHurlevent(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }

    public class MarcheHurlevent : VilleHurlevent
    {
        //public override MusicName DefaultMusic { get { return MusicName.Tavern04; } }

        public MarcheHurlevent(XmlElement xml, Map map, Region parent)
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
}
