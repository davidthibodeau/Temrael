using System;
using Server;
using Server.Mobiles;
using System.Collections;
using Server.Gumps;

namespace Server
{
    class Statistiques
    {

        public static void Reset(PlayerMobile from)
        {
            from.RawStr = 25;
            from.RawDex = 25;
            from.RawInt = 25;

            //from.StatistiquesLibres = 225;
        }

        public static bool CanRaise(PlayerMobile from, StatType stat)
        {
            //if (from.StatistiquesLibres < 1)
            //    return false;

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

        public static bool CanLower(PlayerMobile from, StatType stat)
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

        public static int GetDisponibleStats(PlayerMobile from)
        {
            return 0; //from.StatistiquesLibres;
        }

        public static int GetRemainingStats(PlayerMobile from)
        {
            int added = from.RawStr + from.RawDex + from.RawInt;
            int points = 225;

            return points - added;
        }
    }
}
