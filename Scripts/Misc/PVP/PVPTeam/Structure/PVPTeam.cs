using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Misc.PVP
{
    public class PVPTeam
    {
        // Mobile -- IsDespawned
        public Dictionary<Mobile,bool> joueurs;

        public PVPTeam()
        {
            joueurs = new Dictionary<Mobile,bool>();
        }
    }
}
