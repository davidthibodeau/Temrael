using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Misc.PVP.PVPModeDef;

namespace Server.Misc.PVP
{
    public abstract class PVPMode
    {
        public static readonly List<Type> ModeList = new List<Type>
        {
            // ID
            /* 0 */ typeof(FFA),
            /* 1 */ typeof(TDTickets),
        };

        protected PVPEvent m_pvpevent;

        protected PVPMode(PVPEvent pvpevent)
        {
            m_pvpevent = pvpevent;
        }

        public void SpawnAll()
        {
            foreach (PVPTeam team in m_pvpevent.teams)
            {
                List<Mobile> moblist = new List<Mobile>();

                foreach (Mobile m in team.joueurs.Keys)
                {
                    moblist.Add(m);
                }

                foreach (Mobile m in moblist)
                {
                    Spawn(m);
                    team.joueurs[m] = PVPPlayerState.Spawned;
                }
            }
        }

        protected virtual void Spawn(Mobile m)
        {
            // Devrait posséder un spawning de base, qui teleporte les membres de l'équipe 1 au spawnpoint1 de la map.
        }

        public void DespawnAll()
        {
            foreach (PVPTeam team in m_pvpevent.teams)
            {
                List<Mobile> moblist = new List<Mobile>();

                foreach (Mobile m in team.joueurs.Keys)
                {
                    if ((PVPPlayerState)team.joueurs[m] != PVPPlayerState.Despawned) // S'assure qu'un joueur ne se fait pas despawn plusieurs fois.
                    {
                        moblist.Add(m);
                    }
                }

                foreach (Mobile m in moblist)
                {
                    Despawn(m);
                    team.joueurs[m] = PVPPlayerState.Despawned;
                }
            }
        }

        public void Despawn(Mobile m)
        {
            m.Warmode = false;

            m.Hits = m.HitsMax;
            m.Stam = m.StamMax;
            m.Mana = m.ManaMax;

            m_pvpevent.stone.TeleportRand(m);
            //m.LogoutLocation = m.Location;
        }

        public abstract void Start();

        /// <summary>
        /// Fonction qui doit être appellée à la fin de l'event (Ex: Les membres d'une équipe ont été tués 50 fois.)
        /// Cette fonction doit être appellée par la classe déviant de la classe PVPMode manuellement.
        /// </summary>
        protected void Stop()
        {
            Console.WriteLine("Stopping");
            m_pvpevent.StopEvent();
        }
    }
}
