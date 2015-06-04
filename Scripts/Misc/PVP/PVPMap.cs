using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Misc.PVP
{

    public class PVPMap
    {
        // Ne pas changer l'ordre des maps pour aucune raison : Pourrait causer des bugs de serialize. Il faut ajouter à la fin.
        public static List<PVPMap> MapList = new List<PVPMap>
        {
            /* 0 */ new PVPMap("Ville de Vénore", Map.Ilshenar, 4, new List<Point3D>()
            {
                // Spawnpoints.
                new Point3D(163,261,-59),
                new Point3D(189, 101, -59),
                new Point3D(221, 194, -79),
                new Point3D(137, 168, -58),

                new Point3D(197, 207, -54),
                new Point3D(197, 225, -54),
                new Point3D(177, 234, -59),
                new Point3D(130, 215, -54),
                new Point3D(184, 148, -54),
                new Point3D(228, 150, -59),
                new Point3D(218, 110, -59)
            })
        };

        #region Membres
        private String m_Name;                  // Nom du terrain de bataille.
        private Map m_Map;                      // Map du terrain de bataille, pour que la teleportation se fasse au bon endroit.
        private int m_NbTeamSpawnpoints;        // Nombre de spawnpoints fait pour les équipes.
        private List<Point3D> m_SpawnPoints;    // List des spawnpoints : Team 1 spawn à m_Spawnpoints[0], etc. 

        private bool m_IsInUse;                 // Bool qui permet de savoir si un autre event utilise présentement le terrain.

        #region Get
        public String Name
        {
            get { return m_Name; }
        }
        public Map Map
        {
            get { return m_Map; }
        }
        public int NbTeamSpawnpoints
        {
            get { return m_NbTeamSpawnpoints; }
        }
        public List<Point3D> SpawnPoints
        {
            get { return m_SpawnPoints; }
        }

        #endregion
        #endregion

        PVPMap(String name, Map map, int nbTeamSpawnPoints, List<Point3D> spawnpoints)
        {
            m_Name = name;
            m_Map = map;
            m_NbTeamSpawnpoints = nbTeamSpawnPoints;
            m_SpawnPoints = spawnpoints;
            m_IsInUse = false;
        }

        public bool UseMap()
        {
            if (!m_IsInUse)
            {
                return m_IsInUse = true;
            }
            else
            {
                return false;
            }
        }

        public void StopUsing()
        {
            m_IsInUse = false;
        }

        public void Serialize(GenericWriter writer)
        {
            for (int i = 0; i < MapList.Count; i++)
            {
                if (MapList[i] == this)
                {
                    writer.Write(i);
                    break;
                }
            }
        }

        public static PVPMap Deserialize(GenericReader reader)
        {
            return MapList[reader.ReadInt()];
        }
    }
}
