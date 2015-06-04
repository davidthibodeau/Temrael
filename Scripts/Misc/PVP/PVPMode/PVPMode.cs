using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;

namespace Server.Misc.PVP
{
    public abstract class PVPMode
    {
        public static readonly Dictionary<Type, String> ModeList = new Dictionary<Type, String>
        {
            // ID
            /* 0 */ {typeof(Tickets), "Tickets. (10)"},
            /* 1 */ {typeof(YOLO), "Une seule vie."},
            /* 2 */ {typeof(KillCount), "KillCount.(10)"},
            //* 3 */ {typeof(CaptureTheFlag), "Capture the flag."},
        };

        protected PVPEvent m_pvpevent;
        private TimeoutTimer m_timeoutTimer;

        protected bool AllowFriendlyFire = false;
        protected bool AllowLoot = false;

        public PVPMode(PVPEvent pvpevent)
        {
            m_pvpevent = pvpevent;
            m_timeoutTimer = new TimeoutTimer(this);
        }

        public virtual bool AllowFriendlyDamage(Mobile mob1, Mobile mob2)
        {
            if (AllowFriendlyFire) 
                return true;

            int cpt = 0;
            bool found = false;
            foreach (PVPTeam team in m_pvpevent.teams)
            {
                foreach (KeyValuePair<Mobile,bool> pair in team.joueurs)
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

            return !m_pvpevent.teams[cpt].joueurs.ContainsKey(mob2);
        }

        #region Debut fin du combat / Events
        public void Start()
        {
            EventSink.PlayerDeath += new PlayerDeathEventHandler(EventSink_PlayerDeath);
            EventSink.Disconnected += new DisconnectedEventHandler(EventSink_PlayerDisc);

            foreach (PVPTeam team in m_pvpevent.teams)
            {
                foreach (KeyValuePair<Mobile, bool> pair in team.joueurs)
                {
                    if (((ScriptMobile)pair.Key).CurrentPVPEventInstance == null)
                    {
                        ((ScriptMobile)pair.Key).CurrentPVPEventInstance = m_pvpevent;
                    }
                    else
                    {
                        ((ScriptMobile)pair.Key).CurrentPVPEventInstance.teams.Desinscrire(pair.Key);
                    }
                }
            }

            m_timeoutTimer.Start();

            OnStart();
        }

        protected abstract void OnStart();

        protected virtual TimeSpan DeathTime
        {
            get { return TimeSpan.FromSeconds(3); }
        }

        private void EventSink_PlayerDeath(PlayerDeathEventArgs e)
        {
            if (m_pvpevent.teams.EstInscrit(e.Mobile))
            {
                if (!m_pvpevent.teams.IsDespawned(e.Mobile))
                {
                    if (!AllowLoot)
                    {
                        if (e.Mobile.Corpse != null)
                        {
                            e.Mobile.Corpse.Visible = false;
                        }
                    }

                    Timer.DelayCall(DeathTime, new TimerStateCallback(Delayed_Ondeath), e);
                }
            }
        }

        private void Delayed_Ondeath(object obj)
        {
            PlayerDeathEventArgs e = (PlayerDeathEventArgs)obj;

            e.Mobile.Resurrect();
            if (e.Mobile.Corpse != null && !AllowLoot)
            {
                List<Item> toAdd = new List<Item>();
                if (e.Mobile.Corpse.Items != null)
                {
                    foreach (Item i in e.Mobile.Corpse.Items)
                    {
                        toAdd.Add(i);
                    }
                }

                foreach (Item i in toAdd)
                {
                    e.Mobile.Backpack.AddItem(i);
                }

                e.Mobile.Corpse.Delete();
            }

            OnPlayerDeath(e);
        }

        protected virtual void OnPlayerDeath(PlayerDeathEventArgs e)
        {
        }

        private void EventSink_PlayerDisc(DisconnectedEventArgs e)
        {
            if (m_pvpevent.teams.EstInscrit(e.Mobile))
            {
                if (!m_pvpevent.teams.IsDespawned(e.Mobile))
                {
                    OnPlayerDisc(e);
                }
            }
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

            m_timeoutTimer.Stop();

            foreach (PVPTeam team in m_pvpevent.teams)
            {
                foreach (KeyValuePair<Mobile, bool> pair in team.joueurs)
                {
                    if (m_pvpevent == ((ScriptMobile)pair.Key).CurrentPVPEventInstance)
                    {
                        ((ScriptMobile)pair.Key).CurrentPVPEventInstance = null;
                    }
                }
            }

            m_pvpevent.StopEvent();
        }
        #endregion

        #region Timeout
        public abstract TimeSpan timeout
        {
            get;
        }

        private class TimeoutTimer : Timer
        {
            PVPMode m_mode;

            public TimeoutTimer(PVPMode mode)
                : base(mode.timeout)
            {
                m_mode = mode;
            }

            protected override void OnTick()
            {
                m_mode.Stop();
                Stop();
            }
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

        public static PVPMode Deserialize(GenericReader reader, PVPEvent pvpevent)
        {
            return (PVPMode)Activator.CreateInstance(ModeList.Keys.ElementAt(reader.ReadInt()), pvpevent);
        }
        #endregion
    }
}
