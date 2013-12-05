using System;
using System.Collections;
using Server;
using Server.Mobiles;

namespace Server
{
    public enum TileType
    {
        Desert,
        Jungle,
        Forest,
        Snow,
        Swamp,
        Other,
        Dirt
    }
}

namespace Server.Movement
{
    public class Deplacement
    {
        public Deplacement()
		{
        }

        public static bool IsActive(Mobile from)
        {
            return IsActive(from.Location, from.Map);
        }

        public static bool IsActive(Point3D p, Map map)
        {
            if (map == null)
                return false;

            LandTile landTile = map.Tiles.GetLandTile(p.X, p.Y);
            StaticTile[] tiles = map.Tiles.GetStaticTiles(p.X, p.Y, true);

            for (int i = 0; i < tiles.Length; ++i)
            {
                if (tiles[i].Z == p.Z)
                    return false;
            }

            if (landTile.Z == p.Z)
                return true;

            return false;
        }

        public static TileType GetTileType(Mobile from)
        {
			try
			{
				return GetTileType(from.Location, from.Map);
			}
			catch
			{
			}

			return TileType.Other;
        }

        public static TileType GetTileType(Point3D p, Map map)
        {
			try
			{
				bool contains = false;
				int[] landType;
				LandTile landTile = map.Tiles.GetLandTile(p.X, p.Y);
				TileType type = TileType.Other;

				for (int i = 0; !contains && i < 5; ++i)
				{
					switch (i)
					{
						case 0: landType = m_DesertTiles; break;
						case 1: landType = m_JungleTiles; break;
						case 2: landType = m_ForestTiles; break;
						case 3: landType = m_SnowTiles; break;
                        case 4: landType = m_SwampTiles; break;
                        case 5: landType = m_OtherTiles; break;
                        case 6: landType = m_DirtTiles; break;
						default: landType = m_SwampTiles; break;
					}

					for (int j = 0; !contains && j < landType.Length; ++j)
					{
						if (landTile.ID == landType[j])
						{
							contains = true;
							type = (TileType)i;
						}
					}
				}

				return type;
			}
			catch
			{
			}

			return TileType.Other;
        }

        #region Gestion des tiles
        public static int[] m_DesertTiles = new int[]
			{
				22, 23, 24, 25, 51, 52, 53, 54, 55, 56, 57, 58,	59,
                60, 61, 62, 286, 287, 288, 289, 294, 295, 296, 297,
                426, 427, 642, 643, 644, 645, 650, 651, 652, 653,
				654, 655, 656, 657, 821, 822, 823, 824, 825, 826,
				827, 828, 833, 834, 835, 836, 845, 846, 847, 848,
				849, 850, 851, 852, 857, 858, 859, 860, 951, 952,
				953, 954, 955, 956, 957, 958, 967, 968, 969, 970,
				1447, 1448, 1449, 1450, 1451, 1452, 1453, 1454, 1455,
				1456, 1457, 1458, 1611, 1612, 1613, 1614, 1615, 1616,
				1617, 1618, 1623, 1624, 1625, 1626, 1635, 1636, 1637,
				1638, 1639, 1640, 1641, 1642, 1647, 1648, 1649, 1650,
				1981, 1982, 1983, 1984, 1985, 1986, 1987, 1988, 1989,
				1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998,
                306, 307, 308, 309, 3133, 3134, 3135, 3136, 3137,
                3138, 3139, 3140, 3141, 3142, 3143, 3144, 3145, 3146,
                3147, 3148, 3149, 3150, 3151, 
			};

        public static int[] m_JungleTiles = new int[]
			{
				172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182,
                183, 184, 185, 186, 187, 188, 189, 190, 191, 252, 253,
				254, 255, 256, 257, 258, 259, 264, 265, 266, 267, 496,
                497, 498, 499, 622, 623, 624, 625, 630, 631, 632, 633,
                634, 635, 636, 637, 646, 647, 648, 649, 658, 659, 660,
                661, 1409, 1410, 1411, 1412, 1413, 1414, 1415, 1416,
				1421, 1422, 1423, 1424, 1439, 1440, 1441, 1442, 1443,
				1444, 1445, 1446, 1459, 1460, 1461, 1462, 1463, 1464,
				1465, 1466, 1525, 1526, 1527, 1528, 1541, 1542, 1543,
				1544, 1545, 1546, 1547, 1548, 1549, 1550, 1551, 1552,
				1557, 1558, 1559, 1560, 1831, 1832, 1833, 1834, 1843,
				1844, 1845, 1846, 1847, 1848, 1849, 1850, 1855, 1856,
				1857, 1858,
			};

        public static int[] m_ForestTiles = new int[]
			{
				196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206,
                207, 208, 209, 210, 211, 212, 213, 214, 215, 236, 237,
				238, 239, 240, 241, 242, 243, 248, 249, 250, 251, 349,
                350, 351, 352, 353, 354, 355, 356, 357, 358, 359, 360,
                804, 805, 806, 807, 808, 809, 810, 811, 1359, 1360, 1361,
                1362, 1521, 1522, 1523, 1524, 1529, 1530, 1531, 1532,
				1533, 1534, 1535, 1536, 1537, 1538, 1539, 1540, 1553,
				1554, 1555, 1556, 1619, 1620, 1621, 1622, 1627, 1628,
				1629, 1630, 1631, 1632, 1633, 1634, 1643, 1644, 1645,
				1646, 1711, 1712, 1713, 1714, 1715, 1716, 1723, 1724,
				1725, 1726, 1801, 1802, 1803, 1804, 1813, 1814, 1815,
				1816, 1817, 1818, 1819, 1820, 1849, 1850, 1855, 1856,
				1857, 1858, 395, 396, 397, 398, 399, 400, 401, 403,
                404, 405, 406, 407, 3122, 3123, 3124, 3125, 3126,
                3127, 3128, 3129,
			};

        public static int[] m_SnowTiles = new int[]
			{
				268, 269, 270, 271, 276, 277, 278, 279, 280, 281, 282,
                283, 284, 285, 901, 902, 903, 904, 905, 906, 907, 908,
				913, 914, 915, 916, 925, 926, 927, 928, 929, 930, 931,
                932, 937, 938, 939, 940, 1471, 1472, 1473, 1474, 1475,
                1476, 1477, 1478, 1479, 1480, 1481, 1482, 1483, 1484,
                1485, 1486, 1487, 1488, 1489, 1490, 1491, 1492, 1493,
				1494, 1503, 1504, 1505, 1506, 1861, 1862, 1863, 1864,
				1873, 1874, 1875, 1876, 1877, 1878, 1879, 1880, 1885,
				1886, 1887, 1888,
			};

        public static int[] m_SwampTiles = new int[]
			{
				15809, 15810, 15835, 15836, 15838, 15839, 15840, 15841,
                15842, 15843, 15844, 15845, 15846, 15847, 15848, 15849,
				15850, 15851, 15852, 15853
			};

        public static int[] m_WaterTiles = new int[]
			{
				168, 169, 170, 171
			};

        public static int[] m_OtherTiles = new int[]
			{

			};

        public static int[] m_DirtTiles = new int[]
			{
				113, 134, 135, 136, 137, 138, 139, 140,
                9, 10, 11, 12, 13, 14, 15, 16, 17, 18,
                19, 20, 21
			};
        #endregion
    }
}
