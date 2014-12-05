using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Engines.Harvest
{
    public class Mining : HarvestSystem
    {
        private static Mining m_System;

        public static Mining System
        {
            get
            {
                if (m_System == null)
                    m_System = new Mining();

                return m_System;
            }
        }

        private HarvestDefinition m_OreAndStone;

        public HarvestDefinition OreAndStone
        {
            get { return m_OreAndStone; }
        }

        private Mining()
        {
            HarvestResource[] res;
            HarvestVein[] veins;

            #region Mining for ore and stone
            HarvestDefinition oreAndStone = m_OreAndStone = new HarvestDefinition();

            // Resource banks are every 8x8 tiles
            oreAndStone.BankWidth = 1;
            oreAndStone.BankHeight = 1;

            // Every bank holds from 5 to 12 ore
            oreAndStone.MinTotal = 5;
            oreAndStone.MaxTotal = 12;

            // A resource bank will respawn its content every 10 to 20 minutes
            oreAndStone.MinRespawn = TimeSpan.FromMinutes(45.0);
            oreAndStone.MaxRespawn = TimeSpan.FromMinutes(60.0);

            // Skill checking is done on the Mining skill
            oreAndStone.Skill = SkillName.Excavation;

            // Set the list of harvestable tiles
            oreAndStone.Tiles = m_MountainAndCaveTiles;

            // Players must be within 2 tiles to harvest
            oreAndStone.MaxRange = 1;

            // One ore per harvest action
            oreAndStone.MinConsumedPerHarvest = 1;
            oreAndStone.MaxConsumedPerHarvest = 2;

            // The digging effect
            oreAndStone.EffectActions = new int[] { 11 };
            oreAndStone.EffectSounds = new int[] { 0x125, 0x126 };
            oreAndStone.EffectCounts = new int[] { 5 };
            oreAndStone.EffectDelay = TimeSpan.FromSeconds(1.4); // 1.6
            oreAndStone.EffectSoundDelay = TimeSpan.FromSeconds(0.8); // 0.9

            oreAndStone.NoResourcesMessage = 503040; // There is no metal here to mine.
            oreAndStone.ImpossibleMessage = 501862; // You can't mine there.
            oreAndStone.TimedOutOfRangeMessage = 503041; // You have moved too far away to continue mining.
            oreAndStone.OutOfRangeMessage = 500446; // That is too far away.
            oreAndStone.FailMessage = 503043; // You loosen some rocks but fail to find any useable ore.
            oreAndStone.PackFullMessage = 1010481; // Your backpack is full, so the ore you mined is lost.
            oreAndStone.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = HarvestZone.Resources;

            veins = new HarvestVein[]
                {
					new HarvestVein( 100, 0.0, res[0], null ), // Iron
                    //new HarvestVein( 10.0, 0.0, res[1], res[0] ), // Copper
                    //new HarvestVein( 5.0, 0.0, res[2], res[0] ), // Bronze
                    //new HarvestVein( 4.0, 0.0, res[3], res[0] ), // Lithiar
                    //new HarvestVein( 3.0, 0.0, res[4], res[0] ), // Argent
                    //new HarvestVein( 2.0, 0.0, res[5], res[0] ), // Boreale
                    //new HarvestVein( 1.0, 0.0, res[6], res[0] ), // Chrysteliar
                    //new HarvestVein( 0.9, 0.0, res[7], res[0] ), // Glacias
                    //new HarvestVein( 0.8, 0.0, res[8], res[0] ), // Sonne
                    //new HarvestVein( 0.7, 0.0, res[9], res[0] ), // Volcanium
                    //new HarvestVein( 0.6, 0.0, res[10], res[0] ), // Acier
                    //new HarvestVein( 0.5, 0.0, res[11], res[0] ), // Agapite
                    //new HarvestVein( 0.4, 0.0, res[12], res[0] ), // Durian
                    //new HarvestVein( 0.3, 0.0, res[13], res[0] ), // Equilibrum
                    //new HarvestVein( 0.2, 0.0, res[14], res[0] ), // Etheryl
				};

            oreAndStone.Resources = res;
            oreAndStone.Veins = veins;

            Definitions.Add(oreAndStone);
            #endregion
        }

        public override bool CheckHarvest(Mobile from, Item tool)
        {
            if (!base.CheckHarvest(from, tool))
                return false;

            if (from.Mounted)
            {
                from.SendLocalizedMessage(501864); // You can't mine while riding.
                return false;
            }
            /*else if (from is PlayerMobile && ((PlayerMobile)from).HasTransformSpell())
            {
                from.SendLocalizedMessage(501865); // You can't mine while polymorphed.
                return false;
            }*/

            return true;
        }

        public override bool CheckHarvest(Mobile from, Item tool, HarvestDefinition def, object toHarvest)
        {
            if (!base.CheckHarvest(from, tool, def, toHarvest))
                return false;

            if (from.Mounted)
            {
                from.SendLocalizedMessage(501864); // You can't mine while riding.
                return false;
            }
            /*else if (from is PlayerMobile && ((PlayerMobile)from).HasTransformSpell())
            {
                from.SendLocalizedMessage(501865); // You can't mine while polymorphed.
                return false;
            }*/

            return true;
        }

        public override bool BeginHarvesting(Mobile from, Item tool)
        {
            if (!base.BeginHarvesting(from, tool))
                return false;

            from.SendLocalizedMessage(503033); // Where do you wish to dig?
            return true;
        }

        public override void OnBadHarvestTarget(Mobile from, Item tool, object toHarvest)
        {
            if (toHarvest is LandTarget)
                from.SendLocalizedMessage(501862); // You can't mine there.
            else
                from.SendLocalizedMessage(501863); // You can't mine that.
        }

        #region Tile lists
        public static int[] m_MountainAndCaveTiles = new int[]
			{
				220, 221, 222, 223, 224, 225, 226, 227, 228, 229,
				230, 231, 236, 237, 238, 239, 240, 241, 242, 243,
				244, 245, 246, 247, 252, 253, 254, 255, 256, 257,
				258, 259, 260, 261, 262, 263, 268, 269, 270, 271,
				272, 273, 274, 275, 276, 277, 278, 279, 286, 287,
				288, 289, 290, 291, 292, 293, 294, 296, 296, 297,
				321, 322, 323, 324, 467, 468, 469, 470, 471, 472,
				473, 474, 476, 477, 478, 479, 480, 481, 482, 483,
				484, 485, 486, 487, 492, 493, 494, 495, 543, 544,
				545, 546, 547, 548, 549, 550, 551, 552, 553, 554,
				555, 556, 557, 558, 559, 560, 561, 562, 563, 564,
				565, 566, 567, 568, 569, 570, 571, 572, 573, 574,
				575, 576, 577, 578, 579, 581, 582, 583, 584, 585,
				586, 587, 588, 589, 590, 591, 592, 593, 594, 595,
				596, 597, 598, 599, 600, 601, 610, 611, 612, 613,

				1010, 1741, 1742, 1743, 1744, 1745, 1746, 1747, 1748, 1749,
				1750, 1751, 1752, 1753, 1754, 1755, 1756, 1757, 1771, 1772,
				1773, 1774, 1775, 1776, 1777, 1778, 1779, 1780, 1781, 1782,
				1783, 1784, 1785, 1786, 1787, 1788, 1789, 1790, 1801, 1802,
				1803, 1804, 1805, 1806, 1807, 1808, 1809, 1811, 1812, 1813,
				1814, 1815, 1816, 1817, 1818, 1819, 1820, 1821, 1822, 1823,
				1824, 1831, 1832, 1833, 1834, 1835, 1836, 1837, 1838, 1839,
				1840, 1841, 1842, 1843, 1844, 1845, 1846, 1847, 1848, 1849,
				1850, 1851, 1852, 1853, 1854, 1861, 1862, 1863, 1864, 1865,
				1866, 1867, 1868, 1869, 1870, 1871, 1872, 1873, 1874, 1875,
				1876, 1877, 1878, 1879, 1880, 1881, 1882, 1883, 1884, 1981,
				1982, 1983, 1984, 1985, 1986, 1987, 1988, 1989, 1990, 1991,
				1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999, 2000, 2001,
				2002, 2003, 2004, 2028, 2029, 2030, 2031, 2032, 2033, 2100,
				2101, 2102, 2103, 2104, 2105,

				0x453B, 0x453C, 0x453D, 0x453E, 0x453F, 0x4540, 0x4541,
				0x4542, 0x4543, 0x4544,	0x4545, 0x4546, 0x4547, 0x4548,
				0x4549, 0x454A, 0x454B, 0x454C, 0x454D, 0x454E,	0x454F
			};
        #endregion
    }
}