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
            #region Map defs
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
            }),

            /* 1 */ new PVPMap("Fort de Kurok", Map.Ilshenar, 2, new List<Point3D>()
            {
                // Spawnpoints.
                new Point3D(487, 175, -50),
                new Point3D(508, 116, -80),

                new Point3D(409, 191, -81),
                new Point3D(426, 208, -78),
                new Point3D(434, 148, -10),
                new Point3D(445, 123, -50),
                new Point3D(456, 138, -50),
                new Point3D(476, 152, -30),
                new Point3D(500, 149, -82)
            }),

            /* 2 */ new PVPMap("Cîme aux faucons", Map.Ilshenar, 3, new List<Point3D>()
            {
                // Spawnpoints.
                new Point3D(838, 147, -80),
                new Point3D(749, 109, -21),
                new Point3D(706, 199, -80),

                new Point3D(749, 163, -80),
                new Point3D(740, 137, -58),
                new Point3D(798, 149, -38),
                new Point3D(795, 127, 4),
                new Point3D(780, 193, -81),
                new Point3D(803, 164, -58),
                new Point3D(706, 174, -80)
            }),

            /* 3 */ new PVPMap("Le bazar de Mirage", Map.Ilshenar, 2, new List<Point3D>()
            {
                // Spawnpoints.
                new Point3D(1101, 196, -30),
                new Point3D(1103, 115, -80),

                new Point3D(1098, 152, -31),
                new Point3D(1067, 155, -25),
                new Point3D(1066, 165, -30),
                new Point3D(1076, 164, -30),
                new Point3D(1097, 163, -10),
                new Point3D(1097, 180, -5),
                new Point3D(1069, 190, -30),
                new Point3D(1069, 184, -30),
                new Point3D(1105, 150, -30)
            })
            #endregion
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

        private PVPMap(String name, Map map, int nbTeamSpawnPoints, List<Point3D> spawnpoints)
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

        public static void Serialize(GenericWriter writer, PVPMap map)
        {
            if (map != null)
            {
                for (int i = 0; i < MapList.Count; i++)
                {
                    if (MapList[i] == map)
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

        public static PVPMap Deserialize(GenericReader reader)
        {
            int val = reader.ReadInt();

            if (val != -1)
            {
                return MapList[val];
            }
            else
            {
                return null;
            }
        }
    }
}
