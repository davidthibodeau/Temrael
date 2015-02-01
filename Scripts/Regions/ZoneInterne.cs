using Server.Engines.Evolution;
using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Server.Regions
{
    public class ZoneInterne : BaseRegion
    {
        public ZoneInterne(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }

        public override TimeSpan GetLogoutDelay(Mobile m)
        {
            return TimeSpan.Zero;
        }
    }

    public class ZoneCreation : ZoneInterne
    {
		public static void Initialize()
		{
			EventSink.Login += new LoginEventHandler( OnLogin );
		}

		public static void OnLogin( LoginEventArgs e )
		{
            if (e.Mobile.Region is ZoneCreation)
                e.Mobile.Region.OnEnter(e.Mobile);
		}

        public ZoneCreation(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }

        public override void OnEnter(Mobile m)
        {
            Transfert tr = Transfert.GetTransfert(m as PlayerMobile);

            if (tr != null && tr.Premier != null)
                m.SendMessage("Vous avez de l'expérience dans votre banque de transfert. Si vous désirez en appliquer "
                    + "sur ce perso, vous devez le faire avant de quitter cette zone. (Faites .transfert pour en voir la liste)");

            base.OnEnter(m);
        }
    }

    public class ZoneMort : ZoneInterne
    {
        public ZoneMort(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }
    }
}
