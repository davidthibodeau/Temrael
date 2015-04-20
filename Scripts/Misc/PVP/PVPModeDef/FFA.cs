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
        }

        protected override void Spawn(Mobile m)
        {
            IPoint3D p = new Point3D(m_pvpevent.map.Region.RandomPoint(), 0);
            Spells.SpellHelper.GetSurfaceTop(ref p);

            m.Location = (Point3D)p;
            m.Map = m_pvpevent.map.Map;
        }

        public override void Start()
        {
            Console.WriteLine("Starting");

            NbPlayersAlive = 0;
            foreach (PVPTeam team in m_pvpevent.teams)
            {
                NbPlayersAlive += team.joueurs.Count;
            }

            EventSink.PlayerDeath += new PlayerDeathEventHandler(EventSink_PlayerDeath);
            EventSink.Disconnected += new DisconnectedEventHandler(EventSink_PlayerDisc);
        }

        private void EventSink_PlayerDeath(PlayerDeathEventArgs e)
        {
            CheckConditions(e.Mobile);
        }

        private void EventSink_PlayerDisc(DisconnectedEventArgs e)
        {
            CheckConditions(e.Mobile);
        }

        private void CheckConditions(Mobile m)
        {
            if (m_pvpevent.map.Region.Contains(m))
            {
                if (m.Corpse != null)
                {
                    m.Corpse.Visible = false;
                }

                Timer.DelayCall(TimeSpan.FromSeconds(3), new TimerStateCallback(CheckEvent), m);
            }
        }

        private void CheckEvent(object state)
        {
            Mobile m = (Mobile)state;

            Console.WriteLine(m.Name + " est mort !");
            NbPlayersAlive -= 1;

            m.Resurrect();
            if (m.Corpse != null)
            {
                if (m.Corpse is Corpse)
                {
                    Corpse c = (Corpse)m.Corpse;

                    List<Item> toAdd = new List<Item>();
                    if (c.Items != null)
                    {
                        foreach (Item i in c.Items)
                        {
                            toAdd.Add(i);
                        }
                    }

                    foreach (Item i in toAdd)
                    {
                        m.Backpack.AddItem(i);
                    }
                }
            }

            m.Corpse.Delete();

            Despawn(m);

            if (NbPlayersAlive == 1) // Dernier survivant, donc fin de l'event.
            {
                DespawnAll();
                Stop();
            }
        }

    }
}
