using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        protected override bool InscrireDef(Mobile mob, int teamNumber)
        {
            PVPTeam team = new PVPTeam();
            team.joueurs.Add(mob, false);
            m_teams.Add(team);

            return true;
        }

        public override void Spawn(Mobile m)
        {
            IPoint3D p = new Point3D(m_pvpevent.map.Region.RandomPoint(), 0);
            Spells.SpellHelper.GetSurfaceTop(ref p);

            m.Location = (Point3D)p;
            m.Map = m_pvpevent.map.Map;
        }

        public override bool AjouterEquipe()
        {
            return false;
        }

        public override bool EnleverEquipe()
        {
            return false;
        }
    }
}
