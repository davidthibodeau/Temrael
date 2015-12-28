using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;

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
            ScriptMobile killer = (ScriptMobile)e.Mobile.LastKiller;
            m_pvpevent.teams.Spawn((ScriptMobile)e.Mobile);

            for (int i = 0; i < m_pvpevent.teams.Count; i++)
            {
                if (m_pvpevent.teams[i] == killer.PVPInfo.CurrentTeam)
                {
                    killcount[i] += 1;
                    Server.Commands.CommandHandlers.BroadcastMessage(AccessLevel.Player, 0, "L'équipe #" + i + " a fait un kill. Elle possède " + killcount[i] + "points.");

                    if (killcount[i] >= maxkills)
                    {
                        Stop();
                    }
                    break;
                }
            }
        }
    }
}
