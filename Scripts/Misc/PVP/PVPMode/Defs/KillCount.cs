using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Misc.PVP
{
    public class KillCount : PVPMode
    {
        List<int> killcount;
        const int maxkills = 10;

        public override TimeSpan timeout
        {
            get { return TimeSpan.FromMinutes(10); }
        }

        public KillCount(PVPEvent pvpevent)
            : base(pvpevent)
        {
            killcount = new List<int>();
        }

        protected override void OnStart()
        {
            for (int i = 0; i < m_pvpevent.teams.Count; i++)
            {
                killcount.Add(0);
            }
        }

        protected override void OnPlayerDeath(PlayerDeathEventArgs e)
        {
            Mobile killer = e.Mobile.LastKiller;
            m_pvpevent.teams.Spawn(e.Mobile);

            for (int i = 0; i < m_pvpevent.teams.Count; i++)
            {
                if (m_pvpevent.teams[i].joueurs.ContainsKey(killer))
                {
                    killcount[i] += 1;
                    Server.Commands.CommandHandlers.BroadcastMessage(AccessLevel.Player, 0, "L'équipe #" + i + " a fait un kill. Elle possède " + killcount[i] + "points.");
                    break;
                }
            }

            foreach (int val in killcount)
            {
                if (val >= maxkills)
                {
                    m_pvpevent.teams.DespawnAll();
                    Stop();
                    break;
                }
            }
        }
    }
}
