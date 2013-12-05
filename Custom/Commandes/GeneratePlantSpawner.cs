using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class GeneratePlantSpawner
    {
        public static TimeSpan BaseMinDelay = TimeSpan.FromHours(3.0);
        public static TimeSpan BaseMaxDelay = TimeSpan.FromHours(5.0);

        private static Point2D[] m_Desert80 = new Point2D[]
            {
                new Point2D(4212, 867),
                new Point2D(4133, 940),
                new Point2D(4344, 1013),
                new Point2D(4222, 1051),
                new Point2D(569, 1553),
                new Point2D(457, 1607),
                new Point2D(3835, 1940),
                new Point2D(3598, 1963),
                new Point2D(3729, 2017),
                new Point2D(1993, 2268),
                new Point2D(2111, 2278),
                new Point2D(2420, 2343),
                new Point2D(3576, 2344),
                new Point2D(2222, 2347),
                new Point2D(1960, 2446),
                new Point2D(2025, 2526),
                new Point2D(2204, 2528),
                new Point2D(2135, 2618),
                new Point2D(2236, 2683),
            };

        private static Point2D[] m_Desert60 = new Point2D[]
            {
                new Point2D(2316, 2371),
                new Point2D(2135, 2449),
                new Point2D(4666, 3627),
                new Point2D(4635, 3710),
            };

        private static Point2D[] m_Desert40 = new Point2D[]
            {
                new Point2D(3705, 875),
                new Point2D(3604, 1856),
                new Point2D(3543, 1885),
                new Point2D(3936, 1948),
                new Point2D(3504, 1951),
                new Point2D(1757, 2379),
                new Point2D(2227, 2434),
                new Point2D(2286, 2444),
                new Point2D(2114, 2525),
                new Point2D(1935, 2549),
            };

        private static Point2D[] m_Desert20 = new Point2D[]
            {
                new Point2D(1846, 1098),
                new Point2D(2028, 2187),
                new Point2D(2282, 2773),
                new Point2D(2357, 2827),
                new Point2D(2446, 2855),
            };

        private static Point2D[] m_Jungle80 = new Point2D[]
            {
                new Point2D(1375, 556),
                new Point2D(1236, 574),
                new Point2D(1504, 586),
                new Point2D(1128, 625),
                new Point2D(1432, 697),
                new Point2D(2289, 709),
                new Point2D(2058, 719),
                new Point2D(2172, 722),
                new Point2D(1270, 731),
                new Point2D(1131, 755),
                new Point2D(2416, 761),
                new Point2D(1948, 772),
                new Point2D(2311, 809),
                new Point2D(1392, 815),
                new Point2D(2053, 848),
                new Point2D(2160, 851),
                new Point2D(1254, 853),
                new Point2D(1863, 865),
                new Point2D(1036, 880),
                new Point2D(1150, 890),
                new Point2D(2271, 908),
                new Point2D(2391, 908),
                new Point2D(1486, 920),
                new Point2D(1960, 934),
                new Point2D(1357, 959),
                new Point2D(1728, 974),
                new Point2D(1839, 988),
                new Point2D(2167, 989),
                new Point2D(1227, 998),
                new Point2D(2052, 1009),
                new Point2D(1000, 1025),
                new Point2D(1126, 1093),
                new Point2D(2086, 1124),
                new Point2D(2979, 1351),
                new Point2D(2758, 1421),
                new Point2D(2890, 1435),
                new Point2D(3009, 1478),
                new Point2D(2854, 1571),
                new Point2D(3310, 3622),
                new Point2D(3432, 3661),
                new Point2D(3291, 3754),
                new Point2D(3402, 3785),
            };

        private static Point2D[] m_Jungle60 = new Point2D[]
            {
                new Point2D(1089, 982),
                new Point2D(1476, 2995),
            };

        private static Point2D[] m_Jungle40 = new Point2D[]
            {
                new Point2D(1539, 473),
                new Point2D(1458, 485),
                new Point2D(1303, 511),
                new Point2D(1147, 535),
                new Point2D(1305, 641),
                new Point2D(1204, 665),
                new Point2D(1351, 680),
                new Point2D(1473, 3145),
                new Point2D(3330, 3839),
            };

        private static Point2D[] m_Jungle20 = new Point2D[]
            {
                new Point2D(2934, 1526),
                new Point2D(3009, 1576),
            };

        private static Point2D[] m_ForetNord80 = new Point2D[]
            {
                new Point2D(919, 550),
                new Point2D(1045, 584),
                new Point2D(829, 641),
                new Point2D(954, 691),
                new Point2D(1813, 695),
                new Point2D(846, 793),
                new Point2D(1650, 938),
                new Point2D(1891, 996),
                new Point2D(2319, 1009),
                new Point2D(2196, 1060),
                new Point2D(1686, 1081),
                new Point2D(2004, 1081),
                new Point2D(2353, 1127),
                new Point2D(2232, 1169),
                new Point2D(1363, 1174),
                new Point2D(1506, 1207),
                new Point2D(1507, 1207),
                new Point2D(2322, 1234),
                new Point2D(1728, 1376),
                new Point2D(1860, 1387),
                new Point2D(2319, 1415),
                new Point2D(2424, 1439),
            };

        private static Point2D[] m_ForetNord60 = new Point2D[]
            {
                new Point2D(1326, 1064),
                new Point2D(1438, 1084),
                new Point2D(1254, 1123),
                new Point2D(1876, 1277),
                new Point2D(2241, 1303),
            };

        private static Point2D[] m_ForetNord40 = new Point2D[]
            {
                new Point2D(1138, 505),
                new Point2D(1048, 704),
                new Point2D(1525, 1315),
            };

        private static Point2D[] m_ForetSud80 = new Point2D[]
            {
                new Point2D(1181, 2413),
                new Point2D(787, 2506),
                new Point2D(1130, 2538),
                new Point2D(980, 2549),
                new Point2D(865, 2643),
                new Point2D(1094, 2647),
                new Point2D(1171, 2752),
                new Point2D(1289, 2808),
                new Point2D(1096, 2873),
                new Point2D(1228, 2898),
                new Point2D(1102, 3004),
                new Point2D(1275, 3023),
            };

        private static Point2D[] m_ForetSud60 = new Point2D[]
            {
                new Point2D(1071, 2382),
                new Point2D(978, 2394),
                new Point2D(1321, 2423),
                new Point2D(899, 2451),
                new Point2D(1243, 2511),
                new Point2D(1233, 2625),
                new Point2D(982, 2671),
                new Point2D(791, 2741),
                new Point2D(1050, 2751),
                new Point2D(889, 2769),
                new Point2D(968, 2824),
                new Point2D(1347, 2923),
                new Point2D(1001, 2936),
                new Point2D(1312, 3203),
            };

        private static Point2D[] m_ForetSud40 = new Point2D[]
            {
                new Point2D(1158, 2266),
                new Point2D(1102, 2296),
                new Point2D(1025, 2310),
                new Point2D(1215, 2313),
                new Point2D(952, 2321),
                new Point2D(1144, 2328),
                new Point2D(1273, 2351),
                new Point2D(1050, 2456),
                new Point2D(992, 2466),
                new Point2D(900, 2531),
                new Point2D(774, 2588),
                new Point2D(756, 2657),
                new Point2D(1389, 3000),
                new Point2D(973, 3035),
                new Point2D(1282, 3125),
            };

        private static Point2D[] m_ForetSud20 = new Point2D[]
            {
                new Point2D(1187, 2966),
                new Point2D(1188, 3004),
            };

        private static Point2D[] m_ForetEquateur80 = new Point2D[]
            {
                new Point2D(1038, 1687),
                new Point2D(432, 1738),
                new Point2D(802, 1751),
                new Point2D(682, 1768),
                new Point2D(925, 1783),
                new Point2D(556, 1817),
                new Point2D(1063, 1820),
                new Point2D(801, 1883),
                new Point2D(412, 1885),
                new Point2D(1164, 1886),
                new Point2D(664, 1901),
                new Point2D(928, 1903),
                new Point2D(529, 1940),
                new Point2D(1054, 1967),
                new Point2D(2481, 1984),
                new Point2D(1288, 1991),
                new Point2D(2359, 2000),
                new Point2D(756, 2009),
                new Point2D(897, 2018),
                new Point2D(1164, 2023),
                new Point2D(2163, 2084),
                new Point2D(1099, 2150),
            };

        private static Point2D[] m_ForetEquateur60 = new Point2D[]
            {
                new Point2D(1734, 1516),
                new Point2D(2434, 1556),
                new Point2D(1831, 1627),
                new Point2D(2223, 1690),
                new Point2D(2125, 1694),
                new Point2D(1939, 1697),
                new Point2D(2404, 1712),
                new Point2D(1839, 1733),
                new Point2D(1341, 1742),
                new Point2D(1447, 1748),
                new Point2D(1149, 1750),
                new Point2D(1243, 1751),
                new Point2D(2016, 1828),
                new Point2D(1857, 1867),
                new Point2D(1564, 1889),
                new Point2D(1933, 1901),
                new Point2D(1564, 1990),
                new Point2D(1929, 2009),
                new Point2D(1587, 2095),
                new Point2D(1263, 2114),
                new Point2D(1885, 2140),
                new Point2D(2266, 2146),
                new Point2D(2379, 2164),
                new Point2D(1632, 2183),
                new Point2D(1695, 2197),
                new Point2D(1806, 2198),
                new Point2D(2163, 2201),
                new Point2D(1015, 2222),
                new Point2D(922, 2240),
            };

        private static Point2D[] m_ForetEquateur40 = new Point2D[]
            {
                new Point2D(1078, 1585),
                new Point2D(1702, 1636),
                new Point2D(925, 1678),
                new Point2D(2185, 1739),
                new Point2D(2077, 1760),
                new Point2D(2968, 1810),
                new Point2D(2541, 1819),
                new Point2D(1791, 1831),
                new Point2D(2589, 1844),
                new Point2D(2740, 1847),
                new Point2D(2512, 1880),
                new Point2D(2415, 1909),
                new Point2D(1624, 1916),
                new Point2D(2295, 1919),
                new Point2D(2416, 2090),
                new Point2D(1551, 2165),
                new Point2D(2410, 2222),
                new Point2D(1267, 2225),
            };

        private static Point2D[] m_ForetEquateur20 = new Point2D[]
            {
                new Point2D(757, 1394),
                new Point2D(759, 1430),
                new Point2D(892, 1436),
                new Point2D(1071, 1436),
                new Point2D(817, 1441),
                new Point2D(954, 1445),
                new Point2D(1026, 1445),
                new Point2D(1102, 1478),
                new Point2D(1035, 1481),
                new Point2D(1023, 1538),
                new Point2D(1627, 1859),
                new Point2D(1387, 2227),
                new Point2D(2329, 2279),
            };

        private static Point2D[] m_Marais80 = new Point2D[]
            {
                new Point2D(906, 916),
                new Point2D(2163, 1304),
                new Point2D(3048, 1308),
                new Point2D(517, 2058),
                new Point2D(490, 2176),
                new Point2D(596, 2251),
                new Point2D(1388, 2336),
                new Point2D(3130, 3511),
                new Point2D(3266, 3530),
                new Point2D(3150, 3631),
            };

        private static Point2D[] m_Marais60 = new Point2D[]
            {
                new Point2D(1586, 625),
                new Point2D(1908, 742),
                new Point2D(827, 1000),
                new Point2D(1643, 1169),
                new Point2D(2054, 1350),
                new Point2D(2220, 1737),
                new Point2D(502, 2313),
            };

        private static Point2D[] m_Marais40 = new Point2D[]
            {
                new Point2D(1130, 352),
                new Point2D(1424, 420),
                new Point2D(1221, 437),
                new Point2D(1193, 589),
                new Point2D(1415, 638),
                new Point2D(1235, 701),
                new Point2D(1419, 855),
                new Point2D(1234, 1026),
                new Point2D(3450, 1193),
                new Point2D(3061, 1406),
                new Point2D(1005, 1423),
                new Point2D(800, 1502),
                new Point2D(738, 1524),
                new Point2D(882, 2360),
                new Point2D(837, 2416),
                new Point2D(1569, 2902),
                new Point2D(3251, 3627),
            };

        private static Point2D[] m_Marais20 = new Point2D[]
            {
                new Point2D(1126, 613),
            };

        public static void Initialize()
        {
            CommandSystem.Register("GeneratePlantSpawner", AccessLevel.Administrator, new CommandEventHandler(GeneratePlantSpawner_OnCommand));
        }

        public static void GeneratePlantSpawner_OnCommand(CommandEventArgs e)
        {
            /*Generate(m_Desert20, TileType.Desert, PlantType.Heliophage, PlantType.Heliophage, PlantType.Heliophage, PlantType.Heliophage, 20);
            Generate(m_Desert40, TileType.Desert, PlantType.Heliophage, PlantType.Heliophage, PlantType.Heliophage, PlantType.Heliophage, 40);
            Generate(m_Desert60, TileType.Desert, PlantType.Heliophage, PlantType.Heliophage, PlantType.Heliophage, PlantType.Heliophage, 60);
            Generate(m_Desert80, TileType.Desert, PlantType.Heliophage, PlantType.Heliophage, PlantType.Heliophage, PlantType.Heliophage, 80);

            Generate(m_Jungle20, TileType.Jungle, PlantType.Sophialyctes, PlantType.Terralgua, PlantType.Terralgua, PlantType.PerceNeige, 20);
            Generate(m_Jungle40, TileType.Jungle, PlantType.Sophialyctes, PlantType.Terralgua, PlantType.Terralgua, PlantType.PerceNeige, 40);
            Generate(m_Jungle60, TileType.Jungle, PlantType.Sophialyctes, PlantType.Terralgua, PlantType.Terralgua, PlantType.PerceNeige, 60);
            Generate(m_Jungle80, TileType.Jungle, PlantType.Sophialyctes, PlantType.Terralgua, PlantType.Terralgua, PlantType.PerceNeige, 80);

            Generate(m_ForetNord40, TileType.Forest, PlantType.ChampignonsMortulars, PlantType.RoncesRampantes, PlantType.RoncesRampantes, PlantType.Hydragore, 40);
            Generate(m_ForetNord60, TileType.Forest, PlantType.ChampignonsMortulars, PlantType.RoncesRampantes, PlantType.RoncesRampantes, PlantType.Hydragore, 60);
            Generate(m_ForetNord80, TileType.Forest, PlantType.ChampignonsMortulars, PlantType.RoncesRampantes, PlantType.RoncesRampantes, PlantType.Hydragore, 80);

            Generate(m_ForetEquateur20, TileType.Forest, PlantType.LysCircaniques, PlantType.GrandRouge, PlantType.GrandRouge, PlantType.Teiliasis, 20);
            Generate(m_ForetEquateur40, TileType.Forest, PlantType.LysCircaniques, PlantType.GrandRouge, PlantType.GrandRouge, PlantType.Teiliasis, 40);
            Generate(m_ForetEquateur60, TileType.Forest, PlantType.LysCircaniques, PlantType.GrandRouge, PlantType.GrandRouge, PlantType.Teiliasis, 60);
            Generate(m_ForetEquateur80, TileType.Forest, PlantType.LysCircaniques, PlantType.GrandRouge, PlantType.GrandRouge, PlantType.Teiliasis, 80);

            Generate(m_ForetSud20, TileType.Forest, PlantType.HerbesNatiris, PlantType.Theokalon, PlantType.Theokalon, PlantType.Pyrodoron, 20);
            Generate(m_ForetSud40, TileType.Forest, PlantType.HerbesNatiris, PlantType.Theokalon, PlantType.Theokalon, PlantType.Pyrodoron, 40);
            Generate(m_ForetSud60, TileType.Forest, PlantType.HerbesNatiris, PlantType.Theokalon, PlantType.Theokalon, PlantType.Pyrodoron, 60);
            Generate(m_ForetSud80, TileType.Forest, PlantType.HerbesNatiris, PlantType.Theokalon, PlantType.Theokalon, PlantType.Pyrodoron, 80);

            Generate(m_Marais20, TileType.Swamp, PlantType.Thanatophylie, PlantType.Thanatophylie, PlantType.Thanatophylie, PlantType.Thanatophylie, 20);
            Generate(m_Marais40, TileType.Swamp, PlantType.Thanatophylie, PlantType.Thanatophylie, PlantType.Thanatophylie, PlantType.Thanatophylie, 40);
            Generate(m_Marais60, TileType.Swamp, PlantType.Thanatophylie, PlantType.Thanatophylie, PlantType.Thanatophylie, PlantType.Thanatophylie, 60);
            Generate(m_Marais80, TileType.Swamp, PlantType.Thanatophylie, PlantType.Thanatophylie, PlantType.Thanatophylie, PlantType.Thanatophylie, 80);*/
        }

        public static void Generate(Point2D[] points, TileType type, PlantType tSpring, PlantType tSummer, PlantType tAutomn, PlantType tWinter, int range)
        {
            for (int i = 0; i < points.Length; ++i)
            {
                Point2D p = points[i];
                //Console.WriteLine(p.ToString());
                int count;

                if (range == 80)
                    count = 10;
                else if (range == 60)
                    count = 7;
                else if (range == 40)
                    count = 3;
                else
                    count = 1;

                PlantSpawner ps = new PlantSpawner(p, type, tSpring, tSummer, tAutomn, tWinter, range, count, BaseMinDelay, BaseMaxDelay);
            }
        }
    }
}