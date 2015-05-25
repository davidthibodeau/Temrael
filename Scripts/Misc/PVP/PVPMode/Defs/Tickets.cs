using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Misc.PVP
{
    public class Tickets : PVPMode
    {
        List<int> tickets;

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
            int cpt = 0;

            for (int i = 0; i < m_pvpevent.teams.Count; i++)
            {
                tickets[i] = 50;
            }
        }

        protected override void OnPlayerDeath(PlayerDeathEventArgs e)
        {
            CheckEvent(e.Mobile);
        }

        protected override void OnPlayerDisc(DisconnectedEventArgs e)
        {
            CheckEvent(e.Mobile);
        }

        private void CheckEvent(Mobile m)
        {
            for (int i = 0; i < m_pvpevent.teams.Count; i++)
            {
                if (m_pvpevent.teams[i].joueurs.ContainsKey(m))
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
                m_pvpevent.teams.DespawnAll();
                Stop();
            }
        }
    }
}
