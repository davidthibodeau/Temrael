using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Misc.PVP
{
    class Teams : PVPTeamArrangement
    {
        public Teams(PVPEvent pvpevent)
            : base(pvpevent)
        {
        }

        public override int NbMaxEquipes
        {
            get { return 4; }
        }

        protected override bool InscrireDef(Mobile mob, int teamNumber)
        {
            if (m_pvpevent.map != null)
            {
                if (teamNumber >= 0 && teamNumber < m_pvpevent.map.GetNbSpawnPoints())
                {
                    if (!m_teams[teamNumber].joueurs.ContainsKey(mob))
                    {
                        try
                        {
                            m_teams[teamNumber].joueurs.Add(mob, false);

                            return true;
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }

            return false;
        }

        protected override void SpawnDef(Mobile m)
        {
            int cpt = 0;
            foreach (PVPTeam team in m_teams)
            {
                if (team.joueurs.ContainsKey(m))
                {
                    m.Location = m_pvpevent.map.SpawnPoints[cpt];
                    m.Map = m_pvpevent.map.Map;
                    return;
                }
                ++cpt;
            }
        }

    }
}
