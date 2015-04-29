using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Misc.PVP
{
    public enum PVPEventState
    {
        Setting,   // L'Event est en train d'être créé, les informations sont mises en place.
        Waiting,   // En attente de la date/heure de début.
        Preparing, // Les joueurs se préparent en ce moment.
        Started,   // Les joueurs se battent en ce moment.
        Done       // La bataille est terminée, les résultats sont compilés.
    }

    public class PVPEvent
    {
        #region Membres
        public static ArrayList m_InstancesList;

        public PVPEventState state; // L'état de l'event : Restreint l'utilisation de certaines fonctions (Ex : Empêcher le changement de map quand un combat a lieu).

        private PVPStone m_stone;
        private String m_nom;
        private PVPMap m_map;
        private PVPMode m_mode;
        private List<PVPTeam> m_teams;
        private DateTime m_debutEvent;

        private Timer debutTimer;   // Le timer qui s'occupe de starter l'événement à la date "debutEvent".

        #region Get/Set
        public PVPStone stone
        {
            get { return m_stone; }
        }

        public String nom
        {
            get { return m_nom; }
            set { m_nom = value; }
        }

        public PVPMap map
        {
            get { return m_map; }
            set 
            {
                if (state == PVPEventState.Setting)
                {
                    m_map = value;

                    mode = null;
                }
            }
        }

        public PVPMode mode
        {
            get { return m_mode; }
            set 
            {
                if (state == PVPEventState.Setting && map != null)
                {
                    if (map.IsAllowedMode(value.GetType()))
                    {
                        m_mode = value;

                        debutEvent = DateTime.Now;
                        SetNbEquipe(0);
                    }
                }
            }
        }

        public List<PVPTeam> teams
        {
            get { return m_teams; }
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
                            if (pvpevent.map != null && pvpevent.mode != null)
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
            if (state == PVPEventState.Setting)
            {
                if (map == null || mode == null || teams.Count == 0)
                    return false;

                Console.WriteLine("Preparation de l'event.");
                debutTimer.Start();

                state = PVPEventState.Waiting;
            }

            return true;
        }

        /// <summary>
        /// S'occupe de teleporter les joueurs aux spawns, et d'activer les spécificités propres au mode.
        /// </summary>
        private void StartEvent()
        {
            if (teams.Count != 0 &&
                map.UseMap())
            {
                debutTimer.Stop();

                state = PVPEventState.Preparing;

                mode.SpawnAll();

                mode.Start();
            }
        }

        public void StopEvent()
        {
            if (state >= PVPEventState.Preparing)
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

        #region Fonctions de Set.
        public bool AjouterEquipe()
        {
            if (state == PVPEventState.Setting)
            {
                if (map != null && mode != null)
                {
                    if (teams.Count < map.GetNbSpawnPoints())
                    {
                        if (teams.Count < mode.NbMaxEquipes || mode.NbMaxEquipes == 0)
                        {
                            teams.Add(new PVPTeam());
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public void SetNbEquipe(int nb)
        {
            if (state == PVPEventState.Setting)
            {
                bool set = false;
                while (!set)
                {
                    if (teams.Count == nb)
                    {
                        set = true;
                    }
                    else if (teams.Count < nb)
                    {
                        if (!AjouterEquipe())
                            break;
                    }
                    else
                    {
                        if (!EnleverEquipe())
                            break;
                    }
                }
            }
        }

        public bool EnleverEquipe()
        {
            if (state == PVPEventState.Setting)
            {
                if (teams.Count != 0)
                {
                    teams.RemoveAt(teams.Count - 1);
                    return true;
                }
            }
            return false;
        }

        public void Inscrire(Mobile m, int TeamNumber)
        {
            if (state == PVPEventState.Setting ||state == PVPEventState.Waiting)
            {
                try
                {
                    bool i = (null == teams[TeamNumber]);
                }
                catch (Exception)
                {
                    m.SendMessage("La tentative d'inscription n'a pas fonctionné : Inscription à une equipe non existante.");
                    return;
                }

                if (!EstInscrit(m)) // Un joueur ne peut pas s'inscrire dans deux équipes à la fois.
                {
                    if (map != null)
                    {
                        if (TeamNumber >= 0 && TeamNumber < map.GetNbSpawnPoints())
                        {
                            if (!teams[TeamNumber].joueurs.Contains(m))
                            {
                                teams[TeamNumber].joueurs.Add(m, PVPPlayerState.None);
                                m.SendMessage("Vous avez été inscrit à l'event \" " + nom + " \" avec succès.");
                            }
                        }
                    }
                }
            }
        }

        public void Desinscrire(Mobile m)
        {
            if (state == PVPEventState.Setting || state == PVPEventState.Waiting)
            {
                foreach (PVPTeam team in teams) // La boucle pourrait s'arrêter au premier remove de fait.
                {
                    if (team.joueurs.Contains(m))
                    {
                        team.joueurs.Remove(m);
                    }
                }
            }
        }

        public bool EstInscrit(Mobile m)
        {
            foreach (PVPTeam team in teams)
            {
                if (team.joueurs.Contains(m))
                {
                    return true;
                }
            }
            return false;
        }

        public int TotalJoueursInscrit()
        {
            int cpt = 0;
            foreach (PVPTeam team in teams)
            {
                cpt += team.joueurs.Count;
            }

            return cpt;
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

        public bool SetModeByID(int ID)
        {
            if (state == PVPEventState.Setting)
            {
                try
                {
                    mode = (PVPMode)Activator.CreateInstance(PVPMode.ModeList[ID], this);
                    return true;
                }
                catch (IndexOutOfRangeException)
                {
                }
            }

            return false;
        }
        #endregion

        public class PreparationTimer : Timer
        {
            PVPEvent m_pvpevent;

            public PreparationTimer(PVPEvent pvpevent)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(3))
            {
                m_pvpevent = pvpevent;
            }

            protected override void OnTick()
            {
                if (DateTime.Now >= m_pvpevent.debutEvent)
                {
                    m_pvpevent.StartEvent();
                }
            }
        }

        public PVPEvent(PVPStone stone)
        {
            debutTimer = new PreparationTimer(this);
            state = PVPEventState.Setting;

            m_stone = stone;

            m_nom = "";
            m_map = null;
            m_mode = null;
            m_debutEvent = DateTime.Now;
            m_teams = new List<PVPTeam>();

            if (m_InstancesList == null)
            {
                m_InstancesList = new ArrayList();
            }
            m_InstancesList.Add(this);
        }
    }
}
