using System;
using Server;
using Server.Mobiles;
using System.Collections;
using Server.Gumps;

namespace Server
{
    class Statistiques
    {
        //Force, Constitution, Dex, Charisme, Intelligence : total 420
        #region Stats Par Races

        /*private static int[] m_StatsHumain = new int[] { 80, 80, 80, 90, 90 };
        private static int[] m_StatsNain = new int[] { 80, 90, 90, 70, 90 };
        private static int[] m_StatsDrow = new int[] { 75, 70, 100, 75, 100 };
        private static int[] m_StatsElfe = new int[] { 70, 60, 100, 100, 90 };
        private static int[] m_StatsNordique = new int[] { 90, 90, 85, 75, 80 };
        private static int[] m_StatsTiefling = new int[] { 75, 70, 85, 90, 100 };
        private static int[] m_StatsAasimar = new int[] { 80, 80, 80, 100, 80 };
        private static int[] m_StatsOrcish = new int[] { 100, 100, 70, 70, 80 };
        private static int[] m_StatsNomade = new int[] { 75, 75, 90, 90, 90 };

        private static int[] m_StatsZombie = new int[] { 70, 70, 70, 60, 60 };
        private static int[] m_StatsSquelette = new int[] { 80, 80, 80, 60, 70 };
        private static int[] m_StatsFaucheur = new int[] { 100, 100, 90, 60, 70 };
        private static int[] m_StatsSpectre = new int[] { 80, 100, 100, 70, 70 };
        private static int[] m_StatsEsprit = new int[] { 80, 90, 80, 80, 90 };*/
        #endregion

        public static void Reset(TMobile from)
        {
            from.RawStr = 10;
            from.RawDex = 10;
            from.RawInt = 10;
            from.RawCon = 10;
            from.RawCha = 10;

            from.StatistiquesLibres = 225;
        }

        public static bool CanRaise(TMobile from, StatType stat)
        {
            //int StatTotal = from.Str + from.Con + from.Dex + from.Cha + from.Int;

            //if (from.StatCap + 5 > StatTotal)
            //    return false;

            /*if (from.AccessLevel > AccessLevel.GameMaster || from.Races == Races.MJ)
                return true;*/

            if (from.StatistiquesLibres < 1)
                return false;

            BaseRace race = RaceManager.getRace(from.Races);

            switch (stat)
            {
                case StatType.Str:
                    if (from.RawStr + 5 <= race.Str)
                        return true;
                    break;
                case StatType.Dex:
                    if (from.RawDex + 5 <= race.Dex)
                        return true;
                    break;
                case StatType.Con:
                    if (from.RawCon + 5 <= race.Con)
                        return true;
                    break;
                case StatType.Int:
                    if (from.RawInt + 5 <= race.Int)
                        return true;
                    break;
                case StatType.Cha:
                    if (from.RawCha + 5 <= race.Cha)
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
                case StatType.Con:
                    if (from.Con - 5 >= 10)
                        return true;
                    else
                        return false;
                case StatType.Dex:
                    if (from.Dex - 5 >= 10)
                        return true;
                    else
                        return false;
                case StatType.Cha:
                    if (from.Cha - 5 >= 10)
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
            int added = from.RawStr + from.RawCon + from.RawDex + from.RawCha + from.RawInt;
            int points = 275;

            return points - added;
        }
    }
}
