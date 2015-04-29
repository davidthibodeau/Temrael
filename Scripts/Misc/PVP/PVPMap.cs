using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Misc.PVP.PVPModeDef;

namespace Server.Misc.PVP
{

    public class PVPMap
    {
        // Ne pas changer l'ordre des maps pour aucune raison : Pourrait causer des bugs de serialize. Il faut ajouter à la fin.
        public static List<PVPMap> MapList = new List<PVPMap>
        {
            // ID                 Nom          Zone de combat(              X Y 1,                X Y 2),                   Liste des spawnpoints.                       Liste des modes non permis.         )
            /* 0 */ new PVPMap("Bob Donjon", Map.Felucca, new Rectangle2D(new Point2D(4045, 53), new Point2D(4052,60)), new List<Point3D>(){new Point3D(4049,57,0)}, new List<Type>(){typeof(FFA)})
        };

        #region Membres
        private String m_Name;                  // Nom du terrain de bataille.
        private Map m_Map;                      // Map du terrain de bataille, pour que la teleportation se fasse au bon endroit.
        private Rectangle2D m_Region;           // Region définissant la zone de combat : La zone doit être plus petite que le terrain en entier.
        private List<Point3D> m_SpawnPoints;    // List des spawnpoints : Team 1 spawn à m_Spawnpoints[0], etc.

        private bool m_IsInUse;                 // Bool qui permet de savoir si un autre event utilise présentement le terrain.
        private List<Type> m_forbiddenModesList;// Liste des types de PVPModes qui ne sont pas permis sur cette map.

        #region Get
        public String Name
        {
            get { return m_Name; }
        }
        public Map Map
        {
            get { return m_Map; }
        }
        public Rectangle2D Region
        {
            get { return m_Region; }
        }
        public List<Point3D> SpawnPoints
        {
            get { return m_SpawnPoints; }
        }
        #endregion
        #endregion

        PVPMap(String name, Map map, Rectangle2D region, List<Point3D> spawnpoints, List<Type> forbiddenModes)
        {
            m_Name = name;
            m_Map = map;
            m_Region = region;
            m_SpawnPoints = spawnpoints;
            m_IsInUse = false;
            m_forbiddenModesList = forbiddenModes;
        }


        // True si le mode est permis, false sinon.
        public bool IsAllowedMode(Type modeToCheck)
        {
            if (modeToCheck == null)
                return true;

            foreach (Type mode in m_forbiddenModesList)
            {
                if (modeToCheck == mode)
                {
                    return false;
                }
            }

            return true;
        }

        public int GetNbSpawnPoints()
        {
            return m_SpawnPoints.Count;
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

        public static void Serialize(GenericWriter writer)
        {
            writer.Write(MapList.Count);
            foreach (PVPMap map in MapList)
            {
                writer.Write(map.m_IsInUse);
            }
        }

        public static void Deserialize(GenericReader reader)
        {
            int Count = reader.ReadInt();

            for (int i = 0; i < Count; ++i)
            {
                MapList[i].m_IsInUse = reader.ReadBool();
            }
        }
    }
}
