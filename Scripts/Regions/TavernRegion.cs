using System;
using System.Xml;
using System.Collections;
using Server;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Regions;
using Server.Items;

namespace Server.Regions
{
    public class TavernRegion : Region
    {
        public override MusicName DefaultMusic { get { return MusicName.Tavern04; } }
            
        public TavernRegion(XmlElement xml, Map map, Region parent) : base(xml, map, parent)
        {
        }

        public override void OnEnter(Mobile m)
        {
            m.SendMessage("Vous pénétrez une région reposante.");
        }

        public override void OnExit(Mobile m)
        {
            m.SendMessage("Vous quittez un endroit reposant.");
        }
    }
}

namespace Server.Misc
{
    public class FatigueDecayTimer : Timer
    {
        public static void Initialize()
        {
            new FatigueDecayTimer().Start();
        }

        public FatigueDecayTimer()
            : base(TimeSpan.FromSeconds(18), TimeSpan.FromSeconds(18))
        {
            Priority = TimerPriority.OneSecond;
        }

        protected override void OnTick()
        {
            Decay();
        }

        public static void Decay()
        {
            foreach (NetState state in NetState.Instances)
            {
                Mobile m = state.Mobile;

                if (m is TMobile && (m.Region is TavernRegion || m.Region is HouseRegion || IsInCampFireRange(m)))
                    FatigueDecay((TMobile)m);
            }
        }

        public static bool IsInCampFireRange(Mobile m)
        {
            foreach (Item item in m.Map.GetItemsInRange(m.Location, 4))
            {
                if (item != null && item is Campfire)
                    return true;
            }

            return false;
        }

        private static void FatigueDecay(TMobile m)
        {
            double points = 42;

            m.Fatigue += (-1 * (int)(points / 7));

            if (m.Fatigue < 0)
                m.Fatigue = 0;
        }
    }
}