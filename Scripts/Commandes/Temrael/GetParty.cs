using System;
using System.Collections;
using System.IO;
using System.Text;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Gumps;
using Server.Engines.PartySystem;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class GetInParty
	{
		public static void Initialize()
		{
            CommandSystem.Register("getinparty", AccessLevel.Counselor, new CommandEventHandler(getinparty_OnCommand));
		}

        [Usage("getinparty")] 
	    [Description( "GM peut s'insérer dans un party.")]
        public static void getinparty_OnCommand(CommandEventArgs e)
		{
            e.Mobile.Target = new GetInPartyTarget(e.Mobile);
            e.Mobile.SendMessage("Choisissiez le joueur avec lequel vous voulez converser.");
		}
	}

	public class GetInPartyTarget : Target
	{
        private Mobile GM;

        public GetInPartyTarget(Mobile m_GM)
            : base(-1, false, TargetFlags.None)
		{
            GM = m_GM;
		}

		protected override void OnTarget( Mobile from, object targeted )
		{
            if (targeted is TMobile)
            {
                Mobile targ = (Mobile)targeted;
                Party pm = Party.Get(GM);
                Party mp = Party.Get(targ);

                if (targ == GM)
                    from.SendLocalizedMessage(1005439); // You cannot add yourself to a party.
                else if (targ.Party is Mobile)
                    return;
                else if (mp != null && mp == pm)
                    from.SendLocalizedMessage(1005440); // This person is already in your party!
                else if (mp != null)
                {
                    from.SendMessage("Vous rejoignez le party du joueur.");
                    mp.Add(GM);
                }
                else
                {
                    Party p = Party.Get(targ);

                    if (p == null)
                        targ.Party = p = new Party(targ);

                    if (p != null)
                        p.Add(GM);
                }
            }
            else
                from.SendMessage(256, "Il faut cliquer sur un joueur.");
		}
	}
}