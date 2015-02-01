using System;
using System.IO;
using System.Collections;
using Server;
using Server.Items;
using Server.Movement;
using Server.Misc;

namespace Server.Mobiles
{
    public class PlantSpawner : Item
    {
        private int m_HomeRange;
        private int m_Count;
        private TimeSpan m_MinDelay;
        private TimeSpan m_MaxDelay;
        private PlantType[] m_Plant;
        private ArrayList m_Plants;
        private DateTime m_End;
        private InternalTimer m_Timer;
        private bool m_Running;
        private TileType m_TileType;

        public bool IsFull { get { return (m_Plants != null && m_Plants.Count >= m_Count); } }
        
        [CommandProperty(AccessLevel.Batisseur)]
        public TileType TileType
        {
            get { return m_TileType; }
            set { m_TileType = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public PlantType[] PlantName
        {
            get { return m_Plant; }
            set
            {
                m_Plant = value;
            }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Count
        {
            get { return m_Count; }
            set { m_Count = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool Running
        {
            get { return m_Running; }
            set
            {
                if (value)
                    Start();
                else
                    Stop();
            }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int HomeRange
        {
            get { return m_HomeRange; }
            set { m_HomeRange = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public TimeSpan MinDelay
        {
            get { return m_MinDelay; }
            set { m_MinDelay = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public TimeSpan MaxDelay
        {
            get { return m_MaxDelay; }
            set { m_MaxDelay = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public TimeSpan NextSpawn
        {
            get
            {
                if (m_Running)
                    return m_End - DateTime.Now;
                else
                    return TimeSpan.FromSeconds(0);
            }
            set
            {
                Start();
                DoTimer(value);
            }
        }

        [Constructable]
        public PlantSpawner(Point2D location, TileType type, PlantType tSpring, PlantType tSummer, PlantType tAutomn, PlantType tWinter, int range, int count, TimeSpan minDelay, TimeSpan maxDelay)
            : base(0x1f13)
        {
            Visible = false;
            Movable = false;
            Name = "Plant Spawner";

            MoveToWorld(new Point3D(location.X, location.Y, -80/*Map.GetAverageZ(location.X, location.Y)*/), Map.Felucca);
            m_TileType = type;
            m_Plant = new PlantType[] { tSpring, tSummer, tAutomn, tWinter };
            m_HomeRange = range;
            m_Count = count;
            m_MinDelay = minDelay;
            m_MaxDelay = maxDelay;

            m_Plants = new ArrayList();

            m_Running = true;
            DoTimer(TimeSpan.FromSeconds(1));
            Respawn();
        }

        public PlantSpawner(Serial serial) : base(serial)
		{
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.AccessLevel < AccessLevel.Batisseur)
                return;

            PlantSpawnerGump g = new PlantSpawnerGump(this);
            from.SendGump(g);
        }

        public override void OnSingleClick(Mobile from)
        {
            base.OnSingleClick(from);

            if (m_Running)
                LabelTo(from, "[Running]");
            else
                LabelTo(from, "[Off]");
        }

        public void Start()
        {
            if (!m_Running)
            {
                int season = Map.Felucca.Season;

                if (season >= 0 && season <= 3)
                {
                    if (m_Plant[season] != PlantType.None)
                    {
                        m_Running = true;
                        DoTimer();
                    }
                }
            }
        }

        public void Stop()
        {
            if (m_Running)
            {
                m_Timer.Stop();
                m_Running = false;
            }
        }

        public void Defrag()
        {
            for (int i = 0; i < m_Plants.Count; ++i)
            {
                object o = m_Plants[i];

                if (o is BasePlant)
                {
                    BasePlant plant = (BasePlant)o;

                    if (plant.Deleted || plant.Parent != null || plant.IsGathered)
                    {
                        m_Plants.RemoveAt(i);
                        --i;
                    }
                }
                else
                {
                    m_Plants.RemoveAt(i);
                    --i;
                }
            }
        }

        public void OnTick()
        {
            DoTimer();
            Spawn();
        }

        public void Respawn()
        {
            RemovePlants();

            for (int i = 0; i < m_Count; i++)
                Spawn();
        }

        public bool CanSpawn()
        {
            int season = Map.Felucca.Season;

            if (season < 0 || season > 3)
                return false;

            if (m_Plant[season] == PlantType.None)
                return false;

            return true;
        }

        public void Spawn()
        {
            Map map = Map;

            if (map == null || map == Map.Internal || Parent != null)
                return;

            Defrag();

            if (m_Plants.Count >= m_Count)
                return;

            if (CanSpawn())
            {
                try
                {
                    int season = Map.Felucca.Season;

                    if (season < 0 || season > 3)
                        return;

                    if (season == 0 || season == 1 || season == 2)
                        season = Utility.Random(3);

                    if (m_Plant[season] == PlantType.None)
                        return;

                    Type type = ScriptCompiler.FindTypeByName(m_Plant[season].ToString());
                    object o = Activator.CreateInstance(type);

                    if (o is BasePlant)
                    {
                        BasePlant plant = (BasePlant)o;

                        m_Plants.Add(plant);

                        Point3D loc = GetSpawnPosition();

                        if (loc != Point3D.Zero)
                        {
                            plant.OnBeforeSpawn(loc, map);

                            plant.MoveToWorld(loc, map);

                            plant.OnAfterSpawn();
                        }
                    }
                }
                catch
                {
                }
            }
        }

        public Point3D GetSpawnPosition()
        {
            Map map = Map;

            if (map == null)
                return Location;

            // Try 10 times to find a Spawnable location.
            for (int i = 0; i < 10; i++)
            {
                int x = Location.X + (Utility.Random((m_HomeRange * 2) + 1) - m_HomeRange);
                int y = Location.Y + (Utility.Random((m_HomeRange * 2) + 1) - m_HomeRange);
                int z = Map.GetAverageZ(x, y);

                if (Deplacement.GetTileType(new Point3D(x, y, z), Map) == m_TileType)
                {
                    if (Map.CanSpawnMobile(new Point2D(x, y), z))
                    {
                        return new Point3D(x, y, z);
                    }
                }
            }

            return Point3D.Zero;
        }

        public void DoTimer()
        {
            if (!m_Running)
                return;

            int minSeconds = (int)m_MinDelay.TotalSeconds;
            int maxSeconds = (int)m_MaxDelay.TotalSeconds;

            TimeSpan delay = TimeSpan.FromSeconds(Utility.RandomMinMax(minSeconds, maxSeconds));
            DoTimer(delay);
        }

        public void DoTimer(TimeSpan delay)
        {
            if (!m_Running)
                return;

            m_End = DateTime.Now + delay;

            if (m_Timer != null)
                m_Timer.Stop();

            m_Timer = new InternalTimer(this, delay);
            m_Timer.Start();
        }

        private class InternalTimer : Timer
        {
            private PlantSpawner m_Spawner;

            public InternalTimer(PlantSpawner spawner, TimeSpan delay) : base(delay)
            {
                if (spawner.IsFull)
                    Priority = TimerPriority.FiveSeconds;
                else
                    Priority = TimerPriority.OneSecond;

                m_Spawner = spawner;
            }

            protected override void OnTick()
            {
                if (m_Spawner != null)
                    if (!m_Spawner.Deleted)
                        m_Spawner.OnTick();
            }
        }

        public int CountPlants()
        {
            Defrag();

            return m_Plants.Count;
        }

        public void RemovePlants()
        {
            Defrag();

            for (int i = 0; i < m_Plants.Count; ++i)
            {
                object o = m_Plants[i];

                if (o is BasePlant)
                    ((BasePlant)o).Delete();
            }
        }

        public void BringToHome()
        {
            Defrag();

            for (int i = 0; i < m_Plants.Count; ++i)
            {
                object o = m_Plants[i];

                if (o is BasePlant)
                {
                    BasePlant plant = (BasePlant)o;

                    plant.MoveToWorld(Location, Map);
                }
            }
        }

        public override void OnDelete()
        {
            base.OnDelete();

            RemovePlants();

            if (m_Timer != null)
                m_Timer.Stop();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)3); // version

            writer.Write((int)m_TileType);

            writer.Write(m_MinDelay);
            writer.Write(m_MaxDelay);
            writer.Write(m_Count);
            writer.Write(m_HomeRange);
            writer.Write(m_Running);

            if (m_Running)
                writer.WriteDeltaTime(m_End);

            for (int i = 0; i < m_Plant.Length; ++i)
                writer.Write((int)m_Plant[i]);

            writer.Write(m_Plants.Count);

            for (int i = 0; i < m_Plants.Count; ++i)
            {
                object o = m_Plants[i];

                if (o is BasePlant)
                    writer.Write((BasePlant)o);
                else
                    writer.Write(Serial.MinusOne);
            }
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 3:
                case 2:
                case 1:
                    {
                        m_TileType = (TileType)reader.ReadInt();

                        goto case 0;
                    }
                case 0:
                    {
                        m_MinDelay = reader.ReadTimeSpan();
                        m_MaxDelay = reader.ReadTimeSpan();
                        m_Count = reader.ReadInt();
                        m_HomeRange = reader.ReadInt();
                        m_Running = reader.ReadBool();

                        TimeSpan ts = TimeSpan.Zero;

                        if (m_Running)
                            ts = reader.ReadDeltaTime() - DateTime.Now;

                        m_Plant = new PlantType[4];

                        for (int i = 0; i < m_Plant.Length; ++i)
                            m_Plant[i] = (PlantType)reader.ReadInt();

                        int count = reader.ReadInt();

                        m_Plants = new ArrayList(count);

                        for (int i = 0; i < count; ++i)
                        {
                            IEntity e = World.FindEntity(reader.ReadInt());

                            if (e != null)
                                m_Plants.Add(e);
                        }

                        if (m_Running)
                            DoTimer(ts);

                        break;
                    }
            }

            if (version < 2)
            {
                if (m_Count == 6)
                    m_Count = 5;
                else if (m_Count == 4)
                    m_Count = 3;
                else if (m_Count == 2)
                    m_Count = 2;
                else
                    m_Count = 1;

                Timer.DelayCall(TimeSpan.FromSeconds(5.0), new TimerCallback(_OnTick));
            }

            //Delete();
        }

        public static void _OnTick()
        {
            Time.OnSeasonChange((Season)Map.Felucca.Season);
        }
    }
}
