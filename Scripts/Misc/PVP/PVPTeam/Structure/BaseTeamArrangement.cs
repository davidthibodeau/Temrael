using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Server.Misc.PVP
{
    public abstract class PVPTeamArrangement : IEnumerable
    {
        public static readonly Dictionary<Type, String> TeamArrangementList = new Dictionary<Type, String>
        {
            // ID
            /* 0 */ {typeof(FFA), "Free for all"},
            /* 1 */ {typeof(Teams), "En équipe, 1v1v.."}
        };

        protected PVPEvent m_pvpevent;
        protected List<PVPTeam> m_teams;

        public abstract int NbMaxEquipes // 0 == nombre d'équipes illimité.
        {
            get;
        }

        #region Inscription
        public void Inscrire(Mobile mob, int teamNumber)
        {
            if (!EstInscrit(mob))
            {
                if (InscrireDef(mob, teamNumber))
                {
                    mob.SendMessage("Vous avez été inscrit à l'event " + m_pvpevent.nom + " avec succès.");
                }
                else
                {
                    mob.SendMessage("Il y a eu une erreur lors de votre inscription à l'event " + m_pvpevent.nom);
                }
            }
        }

        protected abstract bool InscrireDef(Mobile mob, int teamNumber);

        public void Desinscrire(Mobile m)
        {
            if (m_pvpevent.state == PVPEventState.Setting || m_pvpevent.state == PVPEventState.Waiting)
            {
                foreach (PVPTeam team in this)
                {
                    if (team.joueurs.ContainsKey(m))
                    {
                        team.joueurs.Remove(m);
                        return;
                    }
                }
            }
        }

        public bool EstInscrit(Mobile m)
        {
            foreach (PVPTeam team in this)
            {
                if (team.joueurs.ContainsKey(m))
                {
                    return true;
                }
            }
            return false;
        }

        public int TotalJoueursInscrit()
        {
            int cpt = 0;
            foreach (PVPTeam team in this)
            {
                cpt += team.joueurs.Count;
            }

            return cpt;
        }
        #endregion

        #region Modifier le nombre d'équipes.
        public virtual bool AjouterEquipe()
        {
            if (m_pvpevent.state == PVPEventState.Setting)
            {
                if (m_pvpevent.map != null)
                {
                    if (this.Count < m_pvpevent.map.GetNbSpawnPoints())
                    {
                        if (this.Count < NbMaxEquipes || NbMaxEquipes == 0)
                        {
                            m_teams.Add(new PVPTeam());
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public virtual void SetNbEquipe(int nb)
        {
            if (m_pvpevent.state == PVPEventState.Setting)
            {
                bool set = false;
                while (!set)
                {
                    if (this.Count == nb)
                    {
                        set = true;
                    }
                    else if (this.Count < nb)
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

        public virtual bool EnleverEquipe()
        {
            if (m_pvpevent.state == PVPEventState.Setting)
            {
                if (this.Count != 0)
                {
                    m_teams.RemoveAt(this.Count - 1);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Spawning
        public void SpawnAll()
        {
            foreach (PVPTeam team in this)
            {
                List<Mobile> moblist = new List<Mobile>();

                foreach (Mobile m in team.joueurs.Keys)
                {
                    moblist.Add(m);
                }

                foreach (Mobile m in moblist)
                {
                    Spawn(m);
                }
            }
        }

        public abstract void Spawn(Mobile m);

        public void DespawnAll()
        {
            foreach (PVPTeam team in this)
            {
                List<Mobile> moblist = new List<Mobile>();

                foreach (Mobile m in team.joueurs.Keys)
                {
                    if (team.joueurs[m] == false) // S'assure qu'un joueur ne se fait pas despawn plusieurs fois.
                    {
                        moblist.Add(m);
                    }
                }

                foreach (Mobile m in moblist)
                {
                    Despawn(m);
                    team.joueurs[m] = true;
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

        public bool IsDespawned(Mobile m)
        {
            foreach (PVPTeam team in this)
            {
                if (team.joueurs.ContainsKey(m))
                {
                    return team.joueurs[m];
                }
            }
            return false;
        }
        #endregion

        #region IEnumerable / Implementation
        public IEnumerator<PVPTeam> GetEnumerator()
        {
            return m_teams.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count
        {
            get { return m_teams.Count; }
        }

        public PVPTeam this[int i]
        {
            get { return m_teams[i]; }
            set { m_teams[i] = value; }
        }
        #endregion

        #region Serialize / Deserialize
        public void Serialize(GenericWriter writer)
        {
            for (int i = 0; i < TeamArrangementList.Count; i++)
            {
                if (TeamArrangementList.Keys.ElementAt(i) == this.GetType())
                {
                    writer.Write(i);
                    break;
                }
            }

            writer.Write(m_teams.Count);
            foreach (PVPTeam team in m_teams)
            {
                writer.Write(team.joueurs.Count);
                foreach (KeyValuePair<Mobile, bool> pair in team.joueurs)
                {
                    writer.Write(pair.Key);
                    writer.Write(pair.Value);
                }
            }
        }

        public static PVPTeamArrangement Deserialize(GenericReader reader)
        {
            PVPTeamArrangement teamArrangement = (PVPTeamArrangement)Activator.CreateInstance(TeamArrangementList.Keys.ElementAt(reader.ReadInt()));
            
            int TeamsCount = reader.ReadInt();
            for (int i = 0; i < TeamsCount; ++i)
            {
                teamArrangement.AjouterEquipe();

                int JoueursCount = reader.ReadInt();
                for (int j = 0; j < JoueursCount; ++j)
                {
                    Mobile mob = reader.ReadMobile();
                    bool playerstate = reader.ReadBool();

                    teamArrangement[j].joueurs.Add(mob, playerstate);
                }
            }

            return teamArrangement;
        }
        #endregion

        protected PVPTeamArrangement(PVPEvent pvpevent)
        {
            m_pvpevent = pvpevent;
            m_teams = new List<PVPTeam>();
        }
    }
}
