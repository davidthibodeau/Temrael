using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public enum Race
    {
        Aucun = -1,
        Capiceen = 0,
        Nordique,
        Nomade,
        Nain,
        Orcish,
        Elfe,
        ElfeNoir,
        Tieffelin,
        Aasimar,
        MortVivant,
        Maximum,
        MJ
    }

    public class RaceManager
    {
        #region RaceBank
        public static Dictionary<Race, BaseRace> raceBank = new Dictionary<Race, BaseRace>();
        #endregion

        #region GetRace
        public static BaseRace getRace(Race race)
        {
            BaseRace raceClass = null;
            if (!raceBank.ContainsKey(race))
                createRace(race);
            if (raceBank.ContainsKey(race))
            {
                raceClass = raceBank[race];
            }
            return raceClass;
        }

        public static Race getRaceType(Type type)
        {
            if (type.Equals(typeof(RaceAasimar)))
                return Race.Aasimar;
            else if (type.Equals(typeof(RaceDrow)))
                return Race.ElfeNoir;
            else if (type.Equals(typeof(RaceElfe)))
                return Race.Elfe;
            else if (type.Equals(typeof(RaceHumain)))
                return Race.Capiceen;
            else if (type.Equals(typeof(RaceNain)))
                return Race.Nain;
            else if (type.Equals(typeof(RaceNomade)))
                return Race.Nomade;
            else if (type.Equals(typeof(RaceNordique)))
                return Race.Nordique;
            else if (type.Equals(typeof(RaceOrcish)))
                return Race.Orcish;
            else if (type.Equals(typeof(RaceTieffelin)))
                return Race.Tieffelin;

            return Race.Aucun;
        }
        #endregion

        #region GetBonus
        public static Aptitude GetAptitude(Race race)
        {
            BaseRace raceType = getRace(race);

            return raceType.Bonus;
        }

        public static int GetAptitudeNbr(Race race)
        {
            BaseRace raceType = getRace(race);

            return raceType.BonusNbr;
        }
        #endregion

        #region CreateRace
        private static void createRace(Race race)
        {
            if ( !raceBank.ContainsKey(race))
            {
                switch (race)
                {
                    case Race.Aasimar: raceBank.Add(race, new RaceAasimar()); break;
                    case Race.ElfeNoir: raceBank.Add(race, new RaceDrow()); break;
                    case Race.Elfe: raceBank.Add(race, new RaceElfe()); break;
                    case Race.Capiceen: raceBank.Add(race, new RaceHumain()); break;
                    case Race.Nain: raceBank.Add(race, new RaceNain()); break;
                    case Race.Nomade: raceBank.Add(race, new RaceNomade()); break;
                    case Race.Nordique: raceBank.Add(race, new RaceNordique()); break;
                    case Race.Orcish: raceBank.Add(race, new RaceOrcish()); break;
                    case Race.Tieffelin: raceBank.Add(race, new RaceTieffelin()); break;
                    case Race.MortVivant: raceBank.Add(race, new RaceMortVivant()); break;
                    case Race.MJ: raceBank.Add(race, new RaceHumain()); break;
                    case Race.Aucun: raceBank.Add(race, new RaceHumain()); break;
                }
            }
        }
        #endregion
    }
}
