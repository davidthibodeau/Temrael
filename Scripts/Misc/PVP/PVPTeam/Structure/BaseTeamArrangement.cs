using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Server.Items;
using Server.Mobiles;

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
        public void Inscrire(ScriptMobile mob, int teamNumber)
        {
            if (m_pvpevent.state <= PVPEventState.Waiting)
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
        }

        protected abstract bool InscrireDef(ScriptMobile mob, int teamNumber);

        public void Desinscrire(ScriptMobile m)
        {
            if (m_pvpevent.state <= PVPEventState.Preparing)
            {
                foreach (PVPTeam team in this)
                {
                    if (team.Contains(m))
                    {
                        team.Remove(m);
                        return;
                    }
                }
            }
        }

        public bool EstInscrit(ScriptMobile m)
        {
            foreach (PVPTeam team in this)
            {
                if (team.Contains(m))
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
                cpt += team.Count;
            }

            return cpt;
        }
        #endregion

        #region Modifier le nombre d'équipes.
        public bool AjouterEquipe()
        {
            if (m_pvpevent.state == PVPEventState.Setting)
            {
                if (m_pvpevent.map != null)
                {
                    if (this.Count < m_pvpevent.map.NbTeamSpawnpoints)
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

        public void SetNbEquipe(int nb)
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

        public bool EnleverEquipe()
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
                foreach (ScriptMobile m in team)
                {
                    Spawn(m);
                }
            }
        }

        public void Spawn(ScriptMobile m)
        {
            m.PVPInfo.m_IsDespawned = false;

            m.Warmode = false;

            m.Hits = m.HitsMax;
            m.Stam = m.StamMax;
            m.Mana = m.ManaMax;

            SpawnDef(m);
        }

        protected abstract void SpawnDef(ScriptMobile m);

        public void DespawnAll()
        {
            foreach (PVPTeam team in this)
            {
                foreach (ScriptMobile m in team)
                {
                    Despawn(m);
                }
            }
        }

        public void Despawn(ScriptMobile m)
        {
            if (!m.PVPInfo.m_IsDespawned) // S'assure qu'un joueur ne se fait pas despawn plusieurs fois.
            {
                m.PVPInfo.m_IsDespawned = true;

                m.Warmode = false;

                m.Hits = m.HitsMax;
                m.Stam = m.StamMax;
                m.Mana = m.ManaMax;

                m_pvpevent.stone.TeleportRand(m);
                //m.LogoutLocation = m.Location;

                PVPDossard.Remove(m);
            }
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
        public static void Serialize(GenericWriter writer, PVPTeamArrangement teamArrangement)
        {
            if (teamArrangement != null)
            {
                for (int i = 0; i < TeamArrangementList.Count; i++)
                {
                    if (TeamArrangementList.Keys.ElementAt(i) == teamArrangement.GetType())
                    {
                        writer.Write(i);
                        break;
                    }
                }

                writer.Write(teamArrangement.m_teams.Count);
                foreach (PVPTeam team in teamArrangement.m_teams)
                {
                    writer.Write(team.Count);
                    foreach (ScriptMobile joueur in team)
                    {
                        writer.Write(joueur);
                    }
                }
            }
            else
            {
                writer.Write(-1);
            }
        }

        public static PVPTeamArrangement Deserialize(GenericReader reader, PVPEvent pvpevent)
        {
            int val = reader.ReadInt();
            PVPTeamArrangement teamArrangement = null;

            if (val != -1)
            {
                teamArrangement = (PVPTeamArrangement)Activator.CreateInstance(TeamArrangementList.Keys.ElementAt(val), pvpevent);

                int TeamsCount = reader.ReadInt();
                for (int i = 0; i < TeamsCount; ++i)
                {
                    teamArrangement.AjouterEquipe();

                    int JoueursCount = reader.ReadInt();
                    for (int j = 0; j < JoueursCount; ++j)
                    {
                        ScriptMobile mob = (ScriptMobile)reader.ReadMobile();

                        teamArrangement[i].Add(mob);
                        mob.PVPInfo = new PVPInfo(pvpevent, teamArrangement[i]);
                    }
                }
            }

            return teamArrangement;
        }
        #endregion

        public PVPTeamArrangement(PVPEvent pvpevent)
        {
            m_pvpevent = pvpevent;
            m_teams = new List<PVPTeam>();
        }
    }

    public class PVPDossard : BaseClothing
    {
        [Constructable]
        public PVPDossard(int hue)
            : base(0x2752, Layer.Cloak, hue)
        {
            Movable = false;
            CanBeAltered = false;
        }

        public PVPDossard(Serial serial)
            : base(serial)
        {
        }

        public static void ForcePut(ScriptMobile mob, int hue)
        {
            if (mob.FindItemOnLayer(Layer.Cloak) != null)
            {
                mob.Backpack.AddItem(mob.FindItemOnLayer(Layer.Cloak));
            }

            mob.AddItem(new PVPDossard(hue));
        }

        public static void Remove(ScriptMobile mob)
        {
            if (mob.FindItemOnLayer(Layer.Cloak) is PVPDossard)
            {
                mob.FindItemOnLayer(Layer.Cloak).Delete();
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(GenericReader reader)
        {
 	         base.Deserialize(reader);
        }
    }
}