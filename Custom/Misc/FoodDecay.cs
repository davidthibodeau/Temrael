using System;
using Server;
using Server.Network;
using Server.Mobiles;
//using Server.Territories;

namespace Server.Misc
{
    public class FoodDecayTimer : Timer
    {
        public static void Initialize()
        {
            new FoodDecayTimer().Start();
        }

        public FoodDecayTimer()
            : base(TimeSpan.FromMinutes(180), TimeSpan.FromMinutes(180))
        {
            Priority = TimerPriority.OneMinute;
        }

        protected override void OnTick()
        {
            FoodDecay();
        }

        public static void FoodDecay()
        {
            foreach (NetState state in NetState.Instances)
            {
                HungerDecay(state.Mobile);
                ThirstDecay(state.Mobile);
            }
        }

        public static void HungerDecay(Mobile m)
        {
            if (m != null && (((TMobile)m).Races == Races.MortVivant || m.AccessLevel != AccessLevel.Player))
                m.Hunger = 20;

            if (m != null && m.Hunger >= 1 && ((TMobile)m).Races != Races.MortVivant && m.AccessLevel == AccessLevel.Player)
            {
                m.Hunger -= 1;
            }
        }

        public static void ThirstDecay(Mobile m)
        {
            if (m != null && (((TMobile)m).Races == Races.MortVivant || m.AccessLevel != AccessLevel.Player))
                m.Thirst = 20;

            if (m != null && m.Thirst >= 1 && ((TMobile)m).Races != Races.MortVivant && m.AccessLevel == AccessLevel.Player)
            {
                m.Thirst -= 1;
            }
        }
    }

    /*public class ThirstDesertDecayTimer : Timer
    {
        public static void Initialize()
        {
            new ThirstDesertDecayTimer().Start();
        }

        public ThirstDesertDecayTimer()
            : base(TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(15))
        {
            Priority = TimerPriority.OneSecond;
        }

        protected override void OnTick()
        {
            ThirstDecay();
        }

        public static void ThirstDecay()
        {
            foreach (NetState state in NetState.Instances)
            {
                if (state.Mobile != null && state.Mobile is TMobile && state.Mobile.AccessLevel == AccessLevel.Player)
                {
                    TMobile m = (TMobile)state.Mobile;

                    //if (m.Thirst >= 1 && m.Ville != Ville.Najarhim && m.IsInDesert() && !(m.Region is CityKheijan) && m.Races != Races.MortVivant)
                    if (m.Thirst >= 1 && m.IsInDesert() && m.Races != Races.MortVivant)
                    {
                        m.Thirst -= 1;
                    }
                }
            }
        }
    }*/

    public class HitsDecayTimer : Timer
    {
        public static void Initialize()
        {
            new HitsDecayTimer().Start();
        }

        public HitsDecayTimer()
            : base(TimeSpan.FromSeconds(6), TimeSpan.FromSeconds(6))
        {
            Priority = TimerPriority.OneSecond;
        }

        protected override void OnTick()
        {
            HitsDecay();
        }

        public static void HitsDecay()
        {
            foreach (NetState state in NetState.Instances)
            {
                if (state.Mobile != null && state.Mobile is TMobile && state.Mobile.AccessLevel == AccessLevel.Player)
                {
                    TMobile m = (TMobile)state.Mobile;

                    if (m.Hunger <= 0 || m.Thirst <= 0)
                    {
                        if (!m.RisqueDeMort && m.AccessLevel == AccessLevel.Player && m.Races != Races.MortVivant)
                            m.Damage(1);
                    }
                }
            }
        }
    }
}