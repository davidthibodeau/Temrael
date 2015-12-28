using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;

namespace Server.Misc.PVP
{
    public class Tickets : PVPMode
    {
        List<int> tickets;
        const int maxtickets = 10;

        public override TimeSpan timeout
        {
            get { return TimeSpan.FromMinutes(10); }
        }

        public Tickets(PVPEvent pvpevent)
            : base(pvpevent)
        {
            tickets = new List<int>();
        }

        protected override void OnStart()
        {
            for (int i = 0; i < m_pvpevent.teams.Count; i++)
            {
                tickets.Add(maxtickets);
            }
        }

        protected override void OnPlayerDeath(PlayerDeathEventArgs e)
        {
            CheckEvent((ScriptMobile)e.Mobile);
        }

        protected override void OnPlayerDisc(DisconnectedEventArgs e)
        {
            CheckEvent((ScriptMobile)e.Mobile);
        }

        private void CheckEvent(ScriptMobile m)
        {
            for (int i = 0; i < m_pvpevent.teams.Count; i++)
            {
                if (m_pvpevent.teams[i] == m.PVPInfo.CurrentTeam)
                {
                    if (tickets[i] > 0)
                    {
                        tickets[i] -= 1;
                        m_pvpevent.teams.Spawn(m);
                    }
                    else
                    {
                        m_pvpevent.teams.Despawn(m);
                    }
                    //Server.Commands.CommandHandlers.BroadcastMessage(AccessLevel.Player, 0, "L'équipe #" + i + " a perdu un ticket. Il lui reste " + tickets[i] + " tickets");
                    break;
                }
            }

            int cpt = 0;
            foreach (int val in tickets)
            {
                if (val != 0)
                {
                    ++cpt;
                }
            }

            if (cpt <= 1)
            {
                Stop();
            }
        }
    }
}
