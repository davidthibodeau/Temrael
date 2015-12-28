using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;

namespace Server.Misc.PVP
{
    // Classe servant à donner de l'information au Mobile quant à son event courant de PVP. 
    // Sert entre autre à accélérer certaines parties du système.
    public class PVPInfo
    {
        public bool m_IsDespawned;
        private PVPEvent m_CurrentEvent;
        private PVPTeam m_CurrentTeam;

        public PVPEvent CurrentEvent
        {
            get { return m_CurrentEvent; }
        }

        public PVPTeam CurrentTeam
        {
            get { return m_CurrentTeam; }
        }

        public PVPInfo(PVPEvent CurrentEvent, PVPTeam CurrentTeam)
        {
            m_IsDespawned = false;
            m_CurrentEvent = CurrentEvent;
            m_CurrentTeam = CurrentTeam;
        }

        public PVPInfo(PVPEvent CurrentEvent, ScriptMobile Player)
        {
            m_IsDespawned = false;
            m_CurrentEvent = CurrentEvent;

            foreach (PVPTeam team in m_CurrentEvent.teams)
            {
                if (team.Contains(Player))
                {
                    m_CurrentTeam = team;
                    break;
                }
            }
        }
    }
}
