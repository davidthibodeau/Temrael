using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;

namespace Server.Misc.PVP
{
    public class FFA : PVPTeamArrangement
    {
        public FFA(PVPEvent pvpevent)
            : base(pvpevent)
        {
        }

        public override int NbMaxEquipes
        {
            get { return 0; }
        }

        protected override bool InscrireDef(ScriptMobile mob, int teamNumber)
        {
            PVPTeam team = new PVPTeam();
            team.Add(mob);
            m_teams.Add(team);

            return true;
        }

        protected override void SpawnDef(ScriptMobile m)
        {
            m.Location = m_pvpevent.map.SpawnPoints[Utility.Random(m_pvpevent.map.SpawnPoints.Count)];

            m.Map = m_pvpevent.map.Map;
        }
    }
}
