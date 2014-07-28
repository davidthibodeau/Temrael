using System;
using Server;
using Server.Mobiles;
using System.Collections;
using Server.Gumps;

namespace Server
{
    class Statistiques
    {

        public static void Reset(TMobile from)
        {
            from.RawStr = 10;
            from.RawDex = 10;
            from.RawInt = 10;
            from.RawCon = 0;
            from.RawCha = 0;

            from.StatistiquesLibres = 225;
        }

        public static bool CanRaise(TMobile from, StatType stat)
        {
            if (from.StatistiquesLibres < 1)
                return false;

            BaseRace race = RaceManager.getRace(from.Races);

            switch (stat)
            {
                case StatType.Str:
                    if (from.RawStr + 5 <= 100)
                        return true;
                    break;
                case StatType.Dex:
                    if (from.RawDex + 5 <= 100)
                        return true;
                    break;
                case StatType.Int:
                    if (from.RawInt + 5 <= 100)
                        return true;
                    break;
            }

            return false;
        }

        public static bool CanLower(TMobile from, StatType stat)
        {
            switch (stat)
            {
                case StatType.Str:
                    if (from.Str - 5 >= 10)
                        return true;
                    else
                        return false;
                case StatType.Dex:
                    if (from.Dex - 5 >= 10)
                        return true;
                    else
                        return false;
                case StatType.Int:
                    if (from.Int - 5 >= 10)
                        return true;
                    else
                        return false;
                default: break;
            }

            return false;
        }

        public static int GetDisponibleStats(TMobile from)
        {
            return from.StatistiquesLibres;
        }

        public static int GetRemainingStats(TMobile from)
        {
            int added = from.RawStr + from.RawDex + from.RawInt;
            int points = 225;

            return points - added;
        }
    }
}
