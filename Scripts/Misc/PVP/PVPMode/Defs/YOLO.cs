using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;

namespace Server.Misc.PVP
{
    public class YOLO : PVPMode
    {
        List<int> NbPlayersAlive;

        public override TimeSpan timeout
        {
            get { return TimeSpan.FromMinutes(10); }
        }

        public YOLO(PVPEvent pvpevent)
            : base(pvpevent)
        {
            NbPlayersAlive = new List<int>();
        }

        protected override void OnStart()
        {
            for (int i = 0; i < m_pvpevent.teams.Count; i++)
            {
                NbPlayersAlive.Add(m_pvpevent.teams[i].Count);
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
                    NbPlayersAlive[i] -= 1;
                    Server.Commands.CommandHandlers.BroadcastMessage(AccessLevel.Player, 0, m.Name + " est mort, il reste " + NbPlayersAlive[i] + " joueurs dans l'équipe.");
                    break;
                }
            }

            m_pvpevent.teams.Despawn(m);

            int cpt = 0;
            foreach (int val in NbPlayersAlive)
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
