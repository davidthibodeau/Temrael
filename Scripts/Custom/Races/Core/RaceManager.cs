using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public enum Races
    {
        Aucun = -1,
        Humain = 0,
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
        public static Dictionary<Races, BaseRace> raceBank = new Dictionary<Races, BaseRace>();
        #endregion

        #region GetRace
        public static BaseRace getRace(Races race)
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

        public static Races getRaceType(Type type)
        {
            if (type.Equals(typeof(RaceAasimar)))
                return Races.Aasimar;
            else if (type.Equals(typeof(RaceDrow)))
                return Races.ElfeNoir;
            else if (type.Equals(typeof(RaceElfe)))
                return Races.Elfe;
            else if (type.Equals(typeof(RaceHumain)))
                return Races.Humain;
            else if (type.Equals(typeof(RaceNain)))
                return Races.Nain;
            else if (type.Equals(typeof(RaceNomade)))
                return Races.Nomade;
            else if (type.Equals(typeof(RaceNordique)))
                return Races.Nordique;
            else if (type.Equals(typeof(RaceOrcish)))
                return Races.Orcish;
            else if (type.Equals(typeof(RaceTieffelin)))
                return Races.Tieffelin;

            return Races.Aucun;
        }
        #endregion

        #region GetBonus
        public static NAptitude GetAptitude(Races race)
        {
            BaseRace raceType = getRace(race);

            return raceType.Bonus;
        }

        public static int GetAptitudeNbr(Races race)
        {
            BaseRace raceType = getRace(race);

            return raceType.BonusNbr;
        }
        #endregion

        #region CreateRace
        private static void createRace(Races race)
        {
            if ( !raceBank.ContainsKey(race))
            {
                switch (race)
                {
                    case Races.Aasimar: raceBank.Add(race, new RaceAasimar()); break;
                    case Races.ElfeNoir: raceBank.Add(race, new RaceDrow()); break;
                    case Races.Elfe: raceBank.Add(race, new RaceElfe()); break;
                    case Races.Humain: raceBank.Add(race, new RaceHumain()); break;
                    case Races.Nain: raceBank.Add(race, new RaceNain()); break;
                    case Races.Nomade: raceBank.Add(race, new RaceNomade()); break;
                    case Races.Nordique: raceBank.Add(race, new RaceNordique()); break;
                    case Races.Orcish: raceBank.Add(race, new RaceOrcish()); break;
                    case Races.Tieffelin: raceBank.Add(race, new RaceTieffelin()); break;
                    case Races.MortVivant: raceBank.Add(race, new RaceMortVivant()); break;
                    case Races.MJ: raceBank.Add(race, new RaceHumain()); break;
                    case Races.Aucun: raceBank.Add(race, new RaceHumain()); break;
                }
            }
        }
        #endregion
    }
}
