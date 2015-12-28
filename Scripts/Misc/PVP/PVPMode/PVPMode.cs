using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;
using Server.Items;

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

        protected bool m_AllowFriendlyFire = false;
        protected bool m_AllowLoot = false;

        PlayerDeathEventHandler playerdeathhandler;
        DisconnectedEventHandler disconnectedhandler;

        public PVPMode(PVPEvent pvpevent)
        {
            m_pvpevent = pvpevent;
            m_timeoutTimer = new TimeoutTimer(this);
        }

        public virtual bool AllowFriendlyFire(ScriptMobile mob1, ScriptMobile mob2)
        {
            if (m_AllowFriendlyFire) 
                return true;

            if (mob1.PVPInfo.CurrentEvent == mob2.PVPInfo.CurrentEvent)
            {
                return !(mob1.PVPInfo.CurrentTeam == mob2.PVPInfo.CurrentTeam);
            }

            return true;
        }

        public virtual bool AllowLoot()
        {
            return m_AllowLoot;
        }

        #region Debut fin du combat / Events
        public void Start()
        {
            playerdeathhandler = new PlayerDeathEventHandler(EventSink_PlayerDeath);
            disconnectedhandler = new DisconnectedEventHandler(EventSink_PlayerDisc);

            EventSink.PlayerDeath += playerdeathhandler;
            EventSink.Disconnected += disconnectedhandler;

            int cpt = 0;
            foreach (PVPTeam team in m_pvpevent.teams)
            {
                cpt += team.Count;
            }

            if (cpt > 1)
            {
                m_timeoutTimer.Start();

                OnStart();
            }
            else
            {
                Stop();
            }
        }

        protected abstract void OnStart();

        protected virtual TimeSpan DeathTime
        {
            get { return TimeSpan.FromSeconds(3); }
        }

        private void EventSink_PlayerDeath(PlayerDeathEventArgs e)
        {
            if (((ScriptMobile)e.Mobile).PVPInfo.CurrentEvent == m_pvpevent)
            {
                if (!((ScriptMobile)e.Mobile).PVPInfo.m_IsDespawned)
                {
                    Timer.DelayCall(DeathTime, new TimerStateCallback(Delayed_Ondeath), e);
                }
            }
        }

        private void Delayed_Ondeath(object obj)
        {
            PlayerDeathEventArgs e = (PlayerDeathEventArgs)obj;

            e.Mobile.Resurrect();
            if (e.Mobile.Corpse != null && !m_AllowLoot)
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
            }

            OnPlayerDeath(e);
        }

        protected virtual void OnPlayerDeath(PlayerDeathEventArgs e)
        {
        }

        private void EventSink_PlayerDisc(DisconnectedEventArgs e)
        {
            if (((ScriptMobile)e.Mobile).PVPInfo.CurrentEvent == m_pvpevent)
            {
                if (!((ScriptMobile)e.Mobile).PVPInfo.m_IsDespawned)
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

            m_pvpevent.teams.DespawnAll();

            m_timeoutTimer.Stop();

            foreach (PVPTeam team in m_pvpevent.teams)
            {
                foreach (ScriptMobile joueur in team)
                {
                    joueur.PVPInfo = null;
                }
            }

            if (playerdeathhandler != null)
            {
                EventSink.PlayerDeath -= playerdeathhandler;
            }
            if (disconnectedhandler != null)
            {
                EventSink.Disconnected -= disconnectedhandler;
            }

            foreach (PVPTeam team in m_pvpevent.teams)
            {
                foreach (ScriptMobile joueur in team)
                {
                    if (joueur.Corpse != null)
                    {
                        if (joueur.Corpse is Corpse)
                        {
                            Corpse c = (Corpse)joueur.Corpse;
                            c.Open(c.Owner, true);
                        }
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
        public static void Serialize(GenericWriter writer, PVPMode mode)
        {
            if (mode != null)
            {
                for (int i = 0; i < ModeList.Count; i++)
                {
                    if (ModeList.Keys.ElementAt(i) == mode.GetType())
                    {
                        writer.Write(i);
                        break;
                    }
                }
            }
            else
            {
                writer.Write(-1);
            }
        }

        public static PVPMode Deserialize(GenericReader reader, PVPEvent pvpevent)
        {
            int val = reader.ReadInt();

            if (val != -1)
            {
                return (PVPMode)Activator.CreateInstance(ModeList.Keys.ElementAt(val), pvpevent);
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
