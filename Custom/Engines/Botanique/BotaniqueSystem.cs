using System;

namespace Server.Items
{
    public class BotaniqueSystem
    {
        public const bool Enabled = true;

        #region Tables
        private static string[] m_PlantName = new string[]
            {
                "None",
                "Gui",
                "Inule",
                "Benoite",
                "Solidago",
                "Gomphrena",
                "Lavatere",
                "Passiflore",
                "Millepertuis",
                "Artichaut",
                "Immortelle",
                "Melaleuca",
                "Bourrache",
                "Kalmia",
                "Paquerette",
                "Asphodeline",
                "Airelle",
                "Liseron",
                "Agastache",
                "Chicore",
                "Achillee",
                "Ciste",
                "Aconit",
                "Adonis",
                "Buplevre",
                "Souci",
                "Sauge",
                "Zanthoxylum",
                "Nielle",
                "Betoine",
                "Tanaisie",
                "Lin",
                "Coton"
            };

        private static string[] m_PlantNameM = new string[]
            {
                "None",
                "Gui",
                "Inule",
                "Benoite",
                "Solidago",
                "Gomphrena",
                "Lavatere",
                "Passiflore",
                "Millepertuis",
                "Artichaut",
                "Immortelle",
                "Melaleuca",
                "Bourrache",
                "Kalmia",
                "Paquerette",
                "Asphodeline",
                "Airelle",
                "Liseron",
                "Agastache",
                "Chicore",
                "Achillee",
                "Ciste",
                "Aconit",
                "Adonis",
                "Buplevre",
                "Souci",
                "Sauge",
                "Zanthoxylum",
                "Nielle",
                "Betoine",
                "Tanaisie",
                "Lin",
                "Coton"
            };

        private static string[] m_EarthName = new string[]
            {
                "aucune",
                "riche",
                "humide",
                "sabloneuse",
                "enneigée",
                "compacte",
                "acide"
            };

        private static string[] m_EarthNameM = new string[]
            {
                "Aucune",
                "Riche",
                "Humide",
                "Sabloneuse",
                "Enneigée",
                "Compacte",
                "Acide"
            };

        private static string[] m_StateOfGrowth = new string[]
            {
                "Aucun",
                "Graine",
                "Germe",
                "Jeune pousse",
                "Maturité",
                "Dépérissement"
            };

        private static string[] m_StateOfPollination = new string[]
            {
                "Aucun",
                "Florissement",
                "Transmission du pollen",
                "Chute florale",
                "Formation du fruit",
                "Mûrissement du fruit",
                "Chute du fruit"
            };

        private static string[] m_StateOfHydration = new string[]
            {
                "Assoifée",
                "Moyen",
                "Acceptable",
                "Bon",
                "Noyée"
            };

        private static string[] m_Insects = new string[]
            {
                "Aucun",
                "Chenilles",
                "Doryphores",
                "Limaces",
                "Perces Oreilles",
                "Pucerons",
                "Sauterelles"
            };

        private static string[] m_Disease = new string[]
            {
                "Aucun",
                "Aleurodes",
                "Armillaire",
                "Cécidomyie",
                "Chancre",
                "Fumagine",
                "Nématode",
                "Noctuelle",
                "Psylle",
                "Rouille",
                "Tavelure",
                "Thrips"
            };

        private static string[] m_Manure = new string[]
            {
                "Aucun",
                "Type 01",
                "Type 02"
            };

        private static string[] m_Poison = new string[]
            {
                "Aucun",
                "Empoisonnée"
            };

        private static string[] m_Fungi = new string[]
            {
                "Aucun",
                "Champignon à Lamelle",
                "Bolet",
                "Polyphores",
                "Phalles",
                "Vesses",
                "Gésastres"
            };
        #endregion

        public static string GetPlantName(PlantType type)
        {
            Console.WriteLine(type.ToString());
            return GetPlantName(type, true);
        }

        public static string GetPlantName(PlantType type, bool majuscule)
        {
            if (majuscule)
                return m_PlantNameM[(int)type];
            else
                return m_PlantName[(int)type];
        }

        public static string GetEarthName(EarthType type)
        {
            return GetEarthName(type, true);
        }

        public static string GetEarthName(EarthType type, bool majuscule)
        {
            if (majuscule)
                return m_EarthNameM[(int)type];
            else
                return m_EarthName[(int)type];
        }

        public static string GetStateOfGrowth(StateOfGrowth state)
        {
            return m_StateOfGrowth[(int)state];
        }

        public static string GetStateOfPollination(StateOfPollination state)
        {
            return m_StateOfPollination[(int)state];
        }

        public static string GetStateOfHydration(StateOfHydration state)
        {
            return m_StateOfHydration[(int)state];
        }

        public static string GetInsects(Insects insects)
        {
            return m_Insects[(int)insects];
        }

        public static string GetDisease(Disease disease)
        {
            return m_Disease[(int)disease];
        }

        public static string GetFungi(Fungi fungi)
        {
            return m_Fungi[(int)fungi];
        }

        public static string GetPoison(PlantPoison poison)
        {
            return m_Poison[(int)poison];
        }

        public static BaseSeed GetSeed(BasePlant plant)
        {
            return plant.GetSeed();
        }

        public static Item GetRegeant(BasePlant plant)
        {
            return plant.GetPlantReagent();
        }

        public static string GetManure(Manure manure)
        {
            return m_Manure[(int)manure];
        }
    }
}