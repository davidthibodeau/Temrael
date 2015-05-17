using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Items;

namespace Server.Misc.PVP.PVPModeDef
{
    public class FFA : PVPMode
    {
        int NbPlayersAlive;

        public FFA(PVPEvent pvpevent)
            : base(pvpevent)
        {
            AllowFriendlyFire = true;
        }

        public override TimeSpan timeout
        {
            get { return TimeSpan.FromMinutes(10); }
        }

        public override int NbMaxEquipes
        {
            get { return 1; }
        }

        protected override void Spawn(Mobile m)
        {
            IPoint3D p = new Point3D(m_pvpevent.map.Region.RandomPoint(), 0);
            Spells.SpellHelper.GetSurfaceTop(ref p);

            m.Location = (Point3D)p;
            m.Map = m_pvpevent.map.Map;
        }

        protected override void OnStart()
        {
            NbPlayersAlive = 0;
            foreach (PVPTeam team in m_pvpevent.teams)
            {
                NbPlayersAlive += team.joueurs.Count;
            }
        }

        protected override void OnPlayerDeath(PlayerDeathEventArgs e)
        {
            CheckConditions(e.Mobile);
        }

        protected override void OnPlayerDisc(DisconnectedEventArgs e)
        {
            CheckConditions(e.Mobile);
        }

        private void CheckConditions(Mobile m)
        {
            if (m_pvpevent.map.Region.Contains(m))
            {
                Timer.DelayCall(TimeSpan.FromSeconds(3), new TimerStateCallback(CheckEvent), m);
            }
        }

        private void CheckEvent(object state)
        {
            Mobile m = (Mobile)state;

            NbPlayersAlive -= 1;

            m.Resurrect();
            if (m.Corpse != null)
            {
                List<Item> toAdd = new List<Item>();
                if (m.Corpse.Items != null)
                {
                    foreach (Item i in m.Corpse.Items)
                    {
                        toAdd.Add(i);
                    }
                }

                foreach (Item i in toAdd)
                {
                    m.Backpack.AddItem(i);
                }

                m.Corpse.Delete();
            }

            Despawn(m);

            if (NbPlayersAlive <= 1) // Dernier survivant, donc fin de l'event.
            {
                DespawnAll();
                Stop();
            }
        }

    }
}
