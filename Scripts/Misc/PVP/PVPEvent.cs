using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Misc.PVP
{
    enum PVPEventState
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

        private PVPStone m_stone;

        private PVPEventState state; // L'état de l'event : Restreint l'utilisation de certaines fonctions (Ex : Empêcher le changement de map quand un combat a lieu).

        private List<PVPTeam> m_teams;
        private PVPMap m_map;
        private PVPMode m_mode;

        public DateTime debutEvent; // La date qui dicte quand est-ce que l'événement va se produire.
        private Timer debutTimer;   // Le timer qui s'occupe de starter l'événement à la date "debutEvent".

        #region Get
        public PVPMode Mode
        {
            get { return m_mode; }
        }
        public List<PVPTeam> Teams
        {
            get { return m_teams; }
        }
        public PVPMap Map
        {
            get { return m_map; }
        }
        public PVPStone Stone
        {
            get { return m_stone; }
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
                if (m_map == null || m_mode == null || m_teams.Count == 0)
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
            if (m_teams.Count != 0 &&
                m_map.UseMap())
            {
                debutTimer.Stop();

                state = PVPEventState.Preparing;

                m_mode.SpawnAll();

                m_mode.Start();
            }
        }

        public void StopEvent()
        {
            m_map.StopUsing();

            state = PVPEventState.Done;
            
            // Logging, si on veut en faire.

            m_InstancesList.Remove(this);
        }
        #endregion

        #region Fonctions de Set.
        public void AjouterEquipe()
        {
            if (state == PVPEventState.Setting)
            {
                if (m_teams.Count < m_map.GetNbSpawnPoints())
                {
                    m_teams.Add(new PVPTeam());
                }
            }
        }

        public void EnleverEquipe()
        {
            if (state == PVPEventState.Setting)
            {
                m_teams.RemoveAt(m_teams.Count - 1);
            }
        }

        public void Inscrire(Mobile m, int TeamNumber)
        {
            if (state == PVPEventState.Setting || state == PVPEventState.Waiting)
            {
                try
                {
                    bool i = (null == m_teams[TeamNumber]);
                }
                catch (Exception)
                {
                    Console.WriteLine("La tentative d'inscription n'a pas fonctionné : Inscription à une equipe non existante.");
                    return;
                }

                // Un joueur ne peut pas s'inscrire dans deux équipes à la fois.
                foreach (PVPTeam team in m_teams)
                {
                    if(team.joueurs.Contains(m))
                    {
                        return;
                    }
                }

                if (m_map != null)
                {
                    if (TeamNumber >= 0 && TeamNumber < m_map.GetNbSpawnPoints())
                    {
                        if (!m_teams[TeamNumber].joueurs.Contains(m))
                        {
                            m_teams[TeamNumber].joueurs.Add(m, PVPPlayerState.None);
                        }
                    }
                }
            }
        }

        public void Desinscrire(Mobile m)
        {
            if (state == PVPEventState.Setting || state == PVPEventState.Waiting)
            {
                foreach (PVPTeam team in m_teams)
                {
                    if (team.joueurs.Contains(m))
                    {
                        team.joueurs.Remove(m);
                    }
                }
            }
        }

        public bool SetMap(int ID)
        {
            if (state == PVPEventState.Setting)
            {
                try
                {
                    PVPMap tempMap = PVPMap.MapList[ID];

                    m_map = tempMap;

                    return true;
                }
                catch (IndexOutOfRangeException)
                {
                }
            }

            return false;
        }

        public bool SetMode(int ID)
        {
            if (state == PVPEventState.Setting)
            {
                try
                {
                    PVPMode tempMode = (PVPMode)Activator.CreateInstance(PVPMode.ModeList[ID], this);

                    m_mode = tempMode;

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

            m_teams = new List<PVPTeam>();

            if (m_InstancesList == null)
            {
                m_InstancesList = new ArrayList();
            }
            m_InstancesList.Add(this);
        }
    }
}
