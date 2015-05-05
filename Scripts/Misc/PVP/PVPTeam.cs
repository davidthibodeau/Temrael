using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Misc.PVP
{
    public class PVPTeam
    {
        public Dictionary<Mobile,PVPPlayerState> joueurs;
        public Point3D spawnLoc;

        public PVPTeam()
        {
            joueurs = new Dictionary<Mobile,PVPPlayerState>();
            spawnLoc = new Point3D();
        }
    }

    public enum PVPPlayerState
    {
        None,
        Spawned,
        Despawned,
        Done
    }
}
