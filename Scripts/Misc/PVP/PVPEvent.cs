using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Misc.PVP.Gumps;

namespace Server.Misc.PVP
{
    public enum PVPEventState
    {
        Setting,   // L'Event est en train d'être créé, les informations sont mises en place.
        Waiting,   // En attente de la date/heure de début.
        Preparing, // Les joueurs sont en train de se préparer / de se faire spawner sur la map.
        Started,   // Les joueurs se battent en ce moment (Dépend du PVPMode).
        Done       // La bataille est terminée, les résultats sont compilés.
    }

    public class PVPEvent
    {
        #region Membres
        public static ArrayList m_InstancesList;

        public PVPEventState state; // L'état de l'event : Restreint l'utilisation de certaines fonctions (Ex : Empêcher le changement de map quand un combat a lieu).

        private Mobile m_maker;
        private PVPStone m_stone;
        private String m_nom;
        private PVPMap m_map;
        private PVPMode m_mode;
        private PVPTeamArrangement m_teams;
        private DateTime m_debutEvent;

        private Timer debutTimer;   // Le timer qui s'occupe de starter l'événement à la date "debutEvent".

        #region Get/Set
        public Mobile maker
        {
            get { return m_maker; }
        }

        public PVPStone stone
        {
            get { return m_stone; }
        }

        public String nom
        {
            get { return m_nom; }
            set 
            {
                if (state == PVPEventState.Setting)
                {
                    m_nom = value;
                }
            }
        }

        public PVPMap map
        {
            get { return m_map; }
            set 
            {
                if (state == PVPEventState.Setting)
                {
                    m_map = value;

                    debutEvent = DateTime.Now;
                }
            }
        }

        public PVPTeamArrangement teams
        {
            get { return m_teams; }
            set
            {
                if (state == PVPEventState.Setting)
                {
                    m_teams = value;
                }
            }
        }

        public PVPMode mode
        {
            get { return m_mode; }
            set 
            {
                if (state == PVPEventState.Setting)
                {
                    m_mode = value;

                    debutEvent = DateTime.Now;
                }
            }
        }

        public DateTime debutEvent
        {
            get { return m_debutEvent; }
            set 
            {
                if( state == PVPEventState.Setting)
                {
                    if (map != null && mode != null)
                    {
                        foreach (PVPEvent pvpevent in m_InstancesList)
                        {
                            if (pvpevent.map != null && pvpevent.mode != null && pvpevent != this)
                            {
                                if (map == pvpevent.map)
                                {
                                    if ((value >= pvpevent.debutEvent && value <= pvpevent.debutEvent + pvpevent.mode.timeout)
                                      || (value + mode.timeout >= pvpevent.debutEvent && value + mode.timeout <= pvpevent.debutEvent + pvpevent.mode.timeout))
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        return;
                    }

                    m_debutEvent = value;
                }
            }
        }

        public bool SetMapByID(int ID)
        {
            if (state == PVPEventState.Setting)
            {
                try
                {
                    map = PVPMap.MapList[ID];
                    return true;
                }
                catch (IndexOutOfRangeException)
                {
                }
            }

            return false;
        }

        public bool SetTeamByID(int ID)
        {
            if (state == PVPEventState.Setting)
            {
                try
                {
                    teams = (PVPTeamArrangement)Activator.CreateInstance(PVPTeamArrangement.TeamArrangementList.Keys.ElementAt(ID), this);
                    return true;
                }
                catch (IndexOutOfRangeException)
                {
                }
            }

            return false;
        }

        public bool SetModeByID(int ID)
        {
            if (state == PVPEventState.Setting)
            {
                try
                {
                    mode = (PVPMode)Activator.CreateInstance(PVPMode.ModeList.Keys.ElementAt(ID), this);
                    return true;
                }
                catch (IndexOutOfRangeException)
                {
                }
            }

            return false;
        }
        #endregion
        #endregion

        #region Gestion de l'Event.
        /// <summary>
        /// S'occupe de starter le timer qui fera commencer la bataille.
        /// Cette fonction devrait être utilisée lorsque les informations sont prêtes.
        /// </summary>
        /// <returns>
        /// Si une information (map, mode, équipes) est manquante, la fonction retournera false.
        /// Si les informations ont déjà été settées par le passé, ou que tout se déroule normalement, la fonction retournera true.</returns>
        public bool PrepareEvent()
        {
            if (state == PVPEventState.Setting && (map != null || mode != null || teams != null || m_debutEvent > DateTime.Now))
            {
                debutTimer.Start();

                state = PVPEventState.Waiting;

                return true;
            }

            return false;
        }

        /// <summary>
        /// S'occupe de teleporter les joueurs aux spawns, et d'activer les spécificités propres au mode.
        /// </summary>
        private void StartEvent()
        {
            if (teams.Count != 0 &&
                map.UseMap())
            {
                state = PVPEventState.Started;

                mode.Start();
            }
        }

        /// <summary>
        /// Retire l'event de la liste d'instances et le détruit.
        /// </summary>
        public void StopEvent()
        {
            if (state == PVPEventState.Started && m_mode != null)
            {
                m_mode.Stop();
                return; // m_mode.Stop() appelle la fonction StopEvent().
            }

            if (state >= PVPEventState.Started)
            {
                map.StopUsing();
            }

            // Logging, si on veut en faire.

            m_InstancesList.Remove(this);

            debutTimer.Stop();
            debutTimer = null;

            m_stone = null;
            state = PVPEventState.Done;

            nom = "";
            m_teams = null;
            map = null;
            mode = null;

            debutEvent = DateTime.Now;
        }
        #endregion

        public class WaitingTimer : Timer
        {
            PVPEvent m_pvpevent;

            public WaitingTimer(PVPEvent pvpevent)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(3))
            {
                m_pvpevent = pvpevent;
            }

            protected override void OnTick()
            {
                if (DateTime.Now >= m_pvpevent.debutEvent)
                {
                    m_pvpevent.debutTimer = new PreparationTimer(m_pvpevent);
                    m_pvpevent.debutTimer.Start();
                    Stop();
                }
            }
        }

        public class PreparationTimer : Timer
        {
            PVPEvent m_pvpevent;
            List<Mobile> m_toCheck;
            DateTime m_EndTime;

            TimeSpan tempsAttente { get { return TimeSpan.FromSeconds(30); } }

            public PreparationTimer(PVPEvent pvpevent) :
                base(TimeSpan.Zero, TimeSpan.FromSeconds(1))
            {
                m_pvpevent = pvpevent;
                m_toCheck = new List<Mobile>();
                m_EndTime = DateTime.Now + tempsAttente;

                m_pvpevent.state = PVPEventState.Preparing;

                foreach (PVPTeam team in m_pvpevent.teams)
                {
                    foreach (KeyValuePair<Mobile,bool> pair in team.joueurs)
                    {
                        m_toCheck.Add(pair.Key);
                    }
                }

                // Send Gump le gump de choix.
                foreach (Mobile mob in m_toCheck)
                {
                    mob.SendGump(new PVPGumpPreparation(mob, m_pvpevent, m_toCheck));
                }
            }

            protected override void OnTick()
            {
                if (m_EndTime - DateTime.Now <= TimeSpan.FromSeconds(10))
                {
                    foreach (PVPTeam team in m_pvpevent.teams)
                    {
                        foreach (KeyValuePair<Mobile, bool> pair in team.joueurs)
                        {
                            pair.Key.SendMessage(((int)(m_EndTime - DateTime.Now).TotalSeconds).ToString() + "..");
                        }
                    }

                    if (m_EndTime <= DateTime.Now)
                    {
                        foreach (Mobile mob in m_toCheck)
                        {
                            m_pvpevent.teams.Desinscrire(mob);
                            mob.CloseGump(typeof(PVPGumpPreparation));
                        }

                        foreach (PVPTeam team in m_pvpevent.teams)
                        {
                            foreach (KeyValuePair<Mobile, bool> pair in team.joueurs)
                            {
                                pair.Key.Frozen = false;
                            }
                        }

                        m_pvpevent.StartEvent();
                        Stop();
                    }
                }
            }
        }

        public static PVPEvent CreateEvent(Mobile maker, PVPStone stone)
        {
            PVPEvent pvpevent = new PVPEvent(maker, stone);

            if (maker != null)
            {
                foreach (PVPEvent _event in PVPEvent.m_InstancesList)
                {
                    if (maker == _event.m_maker && _event != pvpevent)
                    {
                        maker.SendMessage("Vous ne pouvez pas créer un autre event, étant donné que vous avez déjà créé " + _event.nom);
                        pvpevent.StopEvent();
                        return pvpevent = null;
                    }
                }
            }

            return pvpevent;
        }

        private PVPEvent(Mobile maker, PVPStone stone)
        {
            debutTimer = new WaitingTimer(this);
            state = PVPEventState.Setting;

            m_maker = maker;
            m_stone = stone;

            m_nom = "";
            m_map = null;
            m_mode = null;
            m_teams = null;
            m_debutEvent = DateTime.Now;

            if (m_InstancesList == null)
            {
                m_InstancesList = new ArrayList();
            }
            m_InstancesList.Add(this);
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write((int)state);
            writer.Write(m_maker);
            writer.Write(m_stone);
            writer.Write(m_nom);
            m_teams.Serialize(writer);
            m_map.Serialize(writer);
            m_mode.Serialize(writer);
            writer.Write(m_debutEvent);
        }

        public void Deserialize(GenericReader reader)
        {
            state = (PVPEventState)reader.ReadInt();
            m_maker = reader.ReadMobile();
            m_stone = (PVPStone)reader.ReadItem();
            m_nom = reader.ReadString();
            m_teams = PVPTeamArrangement.Deserialize(reader);
            m_map = PVPMap.Deserialize(reader);
            m_mode = PVPMode.Deserialize(reader);
            m_debutEvent = reader.ReadDateTime();

            debutTimer = new WaitingTimer(this);

            if (state >= PVPEventState.Preparing)
            {
                // Event commencé : Despawn et effaçage.
                teams.DespawnAll();
                StopEvent();
            }
            else if (m_debutEvent < DateTime.Now)
            {
                 // Event surpassé : Effaçage.
                StopEvent();
            }
            else
            {
                // Event non débuté : Reboot.
                debutTimer.Start();
            }
        }
    }
}
