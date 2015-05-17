using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Misc.PVP.PVPModeDef;
using Server.Mobiles;

namespace Server.Misc.PVP
{
    public abstract class PVPMode
    {
        public static readonly Dictionary<Type, String> ModeList = new Dictionary<Type, String>
        {
            // ID
            /* 0 */ {typeof(FFA), "Free for all, YOLO"},
            /* 1 */ {typeof(TDTickets), "Team Deathmatch, Tickets"}
        };

        protected PVPEvent m_pvpevent;

        protected bool AllowFriendlyFire = false;
        protected bool AllowLoot = false;

        protected PVPMode(PVPEvent pvpevent)
        {
            m_pvpevent = pvpevent;
        }

        public abstract TimeSpan timeout
        {
            get;
        }

        // 0 veut dire que le nombre d'équipes est limité par la map seulement.
        public abstract int NbMaxEquipes
        {
            get;
        }

        public bool AllowFriendlyDamage(Mobile mob1, Mobile mob2)
        {
            if (AllowFriendlyFire) 
                return true;

            int cpt = 0;
            bool found = false;
            foreach (PVPTeam team in m_pvpevent.teams)
            {
                foreach (KeyValuePair<Mobile,PVPPlayerState> pair in team.joueurs)
                {
                    if (pair.Key == mob1)
                    {
                        found = true;
                        break;
                    }
                }
                if (found) break;
                ++cpt;
            }

            return ! m_pvpevent.teams[cpt].joueurs.ContainsKey(mob2);
        }

        #region Spawning
        protected void SpawnAll()
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
        #endregion

        #region Debut fin du combat / Events
        public void Start()
        {
            EventSink.PlayerDeath += new PlayerDeathEventHandler(EventSink_PlayerDeath);
            EventSink.Disconnected += new DisconnectedEventHandler(EventSink_PlayerDisc);

            foreach (PVPTeam team in m_pvpevent.teams)
            {
                foreach (KeyValuePair<Mobile, PVPPlayerState> pair in team.joueurs)
                {
                    if (((ScriptMobile)pair.Key).CurrentPVPEventInstance == null)
                    {
                        ((ScriptMobile)pair.Key).CurrentPVPEventInstance = m_pvpevent;
                    }
                    else
                    {
                        ((ScriptMobile)pair.Key).CurrentPVPEventInstance.Desinscrire(pair.Key);
                    }
                }
            }

            SpawnAll();

            // Début du timeouttimer.

            OnStart();
        }

        protected abstract void OnStart();

        private void EventSink_PlayerDeath(PlayerDeathEventArgs e)
        {
            if (!AllowLoot)
            {
                if (m_pvpevent.EstInscrit(e.Mobile))
                {
                    if (e.Mobile.Corpse != null)
                    {
                        e.Mobile.Corpse.Visible = false;
                    }
                }
            }

            OnPlayerDeath(e);
        }

        protected virtual void OnPlayerDeath(PlayerDeathEventArgs e)
        {
        }

        private void EventSink_PlayerDisc(DisconnectedEventArgs e)
        {
            OnPlayerDisc(e);
        }

        protected virtual void OnPlayerDisc(DisconnectedEventArgs e)
        {
        }

        /// <summary>
        /// Fonction qui doit être appellée à la fin de l'event (Ex: Les membres d'une équipe ont été tués 50 fois.)
        /// Cette fonction doit être appellée par la classe déviant de la classe PVPMode manuellement.
        /// </summary>
        public void Stop()
        {
            m_pvpevent.state = PVPEventState.Done;

            // Stop le timeouttimer.

            foreach (PVPTeam team in m_pvpevent.teams)
            {
                foreach (KeyValuePair<Mobile, PVPPlayerState> pair in team.joueurs)
                {
                    ((ScriptMobile)pair.Key).CurrentPVPEventInstance = null;
                }
            }

            m_pvpevent.StopEvent();
        }
        #endregion

        #region Serialize / Deserialize
        public void Serialize(GenericWriter writer)
        {
            for (int i = 0; i < ModeList.Count; i++)
            {
                if (ModeList.Keys.ElementAt(i) == this.GetType())
                {
                    writer.Write(i);
                    break;
                }
            }
        }

        public static Type Deserialize(GenericReader reader)
        {
            return ModeList.Keys.ElementAt(reader.ReadInt());
        }
        #endregion
    }
}
