using System;
using System.Collections;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class HarvestDefinition
    {
        private int m_BankWidth, m_BankHeight;
        private int m_MinTotal, m_MaxTotal;
        private int[] m_Tiles;
        private bool m_RangedTiles;
        private TimeSpan m_MinRespawn, m_MaxRespawn;
        private int m_MaxRange;
        private int m_ConsumedPerHarvest, m_ConsumedPerFeluccaHarvest;
        private int m_MinConsumedPerHarvest, m_MaxConsumedPerHarvest;
        private bool m_PlaceAtFeetIfFull;
        private SkillName m_Skill;
        private int[] m_EffectActions;
        private int[] m_EffectCounts;
        private int[] m_EffectSounds;
        private TimeSpan m_EffectSoundDelay;
        private TimeSpan m_EffectDelay;
        private object m_NoResourcesMessage, m_OutOfRangeMessage, m_TimedOutOfRangeMessage, m_DoubleHarvestMessage, m_FailMessage, m_PackFullMessage, m_ToolBrokeMessage, m_ImpossibleMessage;
        private HarvestResource[] m_Resources;
        private HarvestVein[] m_Veins;

        public int BankWidth { get { return m_BankWidth; } set { m_BankWidth = value; } }
        public int BankHeight { get { return m_BankHeight; } set { m_BankHeight = value; } }
        public int MinTotal { get { return m_MinTotal; } set { m_MinTotal = value; } }
        public int MaxTotal { get { return m_MaxTotal; } set { m_MaxTotal = value; } }
        public int[] Tiles { get { return m_Tiles; } set { m_Tiles = value; } }
        public bool RangedTiles { get { return m_RangedTiles; } set { m_RangedTiles = value; } }
        public TimeSpan MinRespawn { get { return m_MinRespawn; } set { m_MinRespawn = value; } }
        public TimeSpan MaxRespawn { get { return m_MaxRespawn; } set { m_MaxRespawn = value; } }
        public int MaxRange { get { return m_MaxRange; } set { m_MaxRange = value; } }
        public int ConsumedPerHarvest { get { return m_ConsumedPerHarvest; } set { m_ConsumedPerHarvest = value; } }
        public int ConsumedPerFeluccaHarvest { get { return m_ConsumedPerFeluccaHarvest; } set { m_ConsumedPerFeluccaHarvest = value; } }
        public int MinConsumedPerHarvest { get { return m_MinConsumedPerHarvest; } set { m_MinConsumedPerHarvest = value; } }
        public int MaxConsumedPerHarvest { get { return m_MaxConsumedPerHarvest; } set { m_MaxConsumedPerHarvest = value; } }
        public bool PlaceAtFeetIfFull { get { return m_PlaceAtFeetIfFull; } set { m_PlaceAtFeetIfFull = value; } }
        public SkillName Skill { get { return m_Skill; } set { m_Skill = value; } }
        public int[] EffectActions { get { return m_EffectActions; } set { m_EffectActions = value; } }
        public int[] EffectCounts { get { return m_EffectCounts; } set { m_EffectCounts = value; } }
        public int[] EffectSounds { get { return m_EffectSounds; } set { m_EffectSounds = value; } }
        public TimeSpan EffectSoundDelay { get { return m_EffectSoundDelay; } set { m_EffectSoundDelay = value; } }
        public TimeSpan EffectDelay { get { return m_EffectDelay; } set { m_EffectDelay = value; } }
        public object NoResourcesMessage { get { return m_NoResourcesMessage; } set { m_NoResourcesMessage = value; } }
        public object OutOfRangeMessage { get { return m_OutOfRangeMessage; } set { m_OutOfRangeMessage = value; } }
        public object TimedOutOfRangeMessage { get { return m_TimedOutOfRangeMessage; } set { m_TimedOutOfRangeMessage = value; } }
        public object DoubleHarvestMessage { get { return m_DoubleHarvestMessage; } set { m_DoubleHarvestMessage = value; } }
        public object ImpossibleMessage { get { return m_ImpossibleMessage; } set { m_ImpossibleMessage = value; } }
        public object FailMessage { get { return m_FailMessage; } set { m_FailMessage = value; } }
        public object PackFullMessage { get { return m_PackFullMessage; } set { m_PackFullMessage = value; } }
        public object ToolBrokeMessage { get { return m_ToolBrokeMessage; } set { m_ToolBrokeMessage = value; } }
        public HarvestResource[] Resources { get { return m_Resources; } set { m_Resources = value; } }
        public HarvestVein[] Veins { get { return m_Veins; } set { m_Veins = value; } }

        private Hashtable m_BanksByMap;

        public Hashtable Banks { get { return m_BanksByMap; } set { m_BanksByMap = value; } }

        public void SendMessageTo(Mobile from, object message)
        {
            if (message is int)
                from.SendLocalizedMessage((int)message);
            else if (message is string)
                from.SendMessage((string)message);
        }

        public static bool IsWater(int id)
        {
            if ((id >= 168 && id <= 171) || (id >= 310 && id <= 311))
                return true;

            return false;
        }

        public HarvestBank GetBank(Mobile from, Map map, int x, int y, Item tool, int tileID)
        {
            if (map == null || map == Map.Internal)
                return null;

            ////Changement de location des minerais à chaque 2 heures.
            //if (DateTime.Now >= HarvestSystem.m_BankClear)
            //{
            //    m_BanksByMap[map] = new Hashtable();
            //    HarvestSystem.m_BankClear = DateTime.Now + TimeSpan.FromHours(2);
            //}

            x /= m_BankWidth;
            y /= m_BankHeight;

            Hashtable banks = (Hashtable)m_BanksByMap[map];

            if (banks == null)
                m_BanksByMap[map] = banks = new Hashtable();

            Point2D key = new Point2D(x, y);
            HarvestBank bank = (HarvestBank)banks[key];

            if (bank == null)
                banks[key] = bank = new HarvestBank(this, GetVeinsAt(from, map, x, y, tool, tileID));

            return bank;
        }

        public static Bait ToBait(string name)
        {
            switch (name)
            {
                case "TruiteFish": return Bait.Truite;
                case "DoreFish": return Bait.Dore;
                case "CarpeFish": return Bait.Carpe;
                case "AnguilleFish": return Bait.Anguille;
                case "EsturgeonFish": return Bait.Esturgeon;
                case "BrochetFish": return Bait.Brochet;
                case "MorueFish": return Bait.Morue;
                case "FletanFish": return Bait.Fletan;
                case "MaquereauFish": return Bait.Maquereau;
                case "SoleFish": return Bait.Sole;
                case "ThonFish": return Bait.Thon;
                case "SaumonFish": return Bait.Saumon;
                case "RaieFish": return Bait.Raie;
                case "EspadonFish": return Bait.Espadon;
                default: return Bait.Aucun;
            }
        }

        public HarvestVein[] GetVeinsAt(Mobile from, Map map, int x, int y, Item tool, int tileID)
        {
            //double randomValue = Utility.RandomDouble() * 100;

            ///*if (from is PlayerMobile)
            //    randomValue -= ((PlayerMobile)from).GetAptitudeValue(NAptitude.Exploitation) * 2;

            //if (AOS.Testing)
            //    from.SendMessage("Chance : " + randomValue.ToString());*/

            //if (tool is IFishingPole)
            //{
            //    IFishingPole pole = (IFishingPole)tool;

            //    HarvestVein[] veins = GetVeins(from, tool, x, y);

            //    if (veins == null)
            //        veins = m_Veins;

            //    for (int i = veins.Length - 1; i >= 0; i--)
            //    {
            //        if (ToBait(veins[i].PrimaryResource.Types[0].Name) == pole.Bait && pole.Charge > 0)
            //        {
            //            if (randomValue - 40 <= veins[i].VeinChance)
            //                return veins[i];

            //            //if (AOS.Testing)
            //            //    from.SendMessage("Bait : " + ((int)randomValue).ToString() + " / " + ((int)veins[i].VeinChance).ToString());
            //        }
            //        else if (pole.Bait == Bait.Aucun || pole.Charge <= 0)
            //        {
            //            if (randomValue <= veins[i].VeinChance)
            //                return veins[i];

            //            randomValue -= veins[i].VeinChance;

            //            //if (AOS.Testing)
            //            //    from.SendMessage("No Bait : " + ((int)randomValue).ToString() + " / " + ((int)veins[i].VeinChance).ToString());
            //        }
            //    }

            //    return null;
            //}
            //else 
            if (Skill == SkillName.Excavation)
            {
                return GetVeins(from, tool, x, y);
            }
            else if (Skill == SkillName.Hache)
            {
                Point2D p = new Point2D(x, y);

                if (Lumberjacking.cheneList.Count > 0)
                    foreach (DictionaryEntry de in Lumberjacking.cheneList)
                    {
                        if (((Region)de.Value).Contains(p))
                            return new HarvestVein[] { new HarvestVein(100.0, 0.0, m_Resources[20], null) };
                    }

                if (Lumberjacking.pinList.Count > 0)
                    foreach (DictionaryEntry de in Lumberjacking.pinList)
                    {
                        if (((Region)de.Value).Contains(p))
                            return new HarvestVein[] { new HarvestVein(100.0, 0.0, m_Resources[16], null) };
                    }

                if (Lumberjacking.cedreList.Count > 0)
                    foreach (DictionaryEntry de in Lumberjacking.cedreList)
                    {
                        if (((Region)de.Value).Contains(p))
                            return new HarvestVein[] { new HarvestVein(100.0, 0.0, m_Resources[18], null) };
                    }

                if (Lumberjacking.cypresList.Count > 0)
                    foreach (DictionaryEntry de in Lumberjacking.cypresList)
                    {
                        if (((Region)de.Value).Contains(p))
                            return new HarvestVein[] { new HarvestVein(100.0, 0.0, m_Resources[17], null) };
                    }

                if (Lumberjacking.ebeneList.Count > 0)
                    foreach (DictionaryEntry de in Lumberjacking.ebeneList)
                    {
                        if (((Region)de.Value).Contains(p))
                            return new HarvestVein[] { new HarvestVein(100.0, 0.0, m_Resources[21], null) };
                    }

                if (Lumberjacking.acajouList.Count > 0)
                    foreach (DictionaryEntry de in Lumberjacking.acajouList)
                    {
                        if (((Region)de.Value).Contains(p))
                            return new HarvestVein[] { new HarvestVein(100.0, 0.0, m_Resources[22], null) };
                    }

                if (Lumberjacking.sauleList.Count > 0)
                    foreach (DictionaryEntry de in Lumberjacking.sauleList)
                    {
                        if (((Region)de.Value).Contains(p))
                            return new HarvestVein[] { new HarvestVein(100.0, 0.0, m_Resources[19], null) };
                    }

                if (Lumberjacking.erableList.Count > 0)
                    foreach (DictionaryEntry de in Lumberjacking.erableList)
                    {
                        if (((Region)de.Value).Contains(p))
                            return new HarvestVein[] { new HarvestVein(100.0, 0.0, m_Resources[15], null) };
                    }
            }

            return m_Veins;
        }

        public static bool IsSea(int x, int y)
        {
            LandTile tile1 = Map.Felucca.Tiles.GetLandTile(x - 60, y - 60);
            LandTile tile2 = Map.Felucca.Tiles.GetLandTile(x + 60, y - 60);
            LandTile tile3 = Map.Felucca.Tiles.GetLandTile(x - 60, y + 60);
            LandTile tile4 = Map.Felucca.Tiles.GetLandTile(x + 60, y + 60);

            LandTile tile5 = Map.Felucca.Tiles.GetLandTile(x - 30, y - 30);
            LandTile tile6 = Map.Felucca.Tiles.GetLandTile(x + 30, y - 30);
            LandTile tile7 = Map.Felucca.Tiles.GetLandTile(x - 30, y + 30);
            LandTile tile8 = Map.Felucca.Tiles.GetLandTile(x + 30, y + 30);

            if (IsWater(tile1.ID) && IsWater(tile2.ID) && IsWater(tile3.ID) && IsWater(tile4.ID) &&
                IsWater(tile5.ID) && IsWater(tile6.ID) && IsWater(tile7.ID) && IsWater(tile8.ID))
            {
                return true;
            }

            return false;
        }

        public HarvestVein[] GetVeins(Mobile from, Item tool, int x, int y)
        {
            if (Skill == SkillName.Excavation)
            {
                HarvestVein[] def = new HarvestVein[] { new HarvestVein(100.0, 0.0, m_Resources[0], null) };
                HarvestZone zone;
                def = new HarvestVein[]
                {
					          new HarvestVein( 70.6, 0.0, m_Resources[0], null ), // Iron
                    /*new HarvestVein( 10.0, 0.0, m_Resources[1], m_Resources[0] ), // Copper
                    new HarvestVein( 5.0, 0.0, m_Resources[2], m_Resources[0] ), // Bronze
                    new HarvestVein( 4.0, 0.0, m_Resources[3], m_Resources[0] ), // Lithiar
                    new HarvestVein( 3.0, 0.0, m_Resources[4], m_Resources[0] ), // Argent
                    new HarvestVein( 2.0, 0.0, m_Resources[5], m_Resources[0] ), // Boreale
                    new HarvestVein( 1.0, 0.0, m_Resources[6], m_Resources[0] ), // Chrysteliar
                    new HarvestVein( 0.9, 0.0, m_Resources[7], m_Resources[0] ), // Glacias
                    new HarvestVein( 0.8, 0.0, m_Resources[8], m_Resources[0] ), // Sonne
                    new HarvestVein( 0.7, 0.0, m_Resources[9], m_Resources[0] ), // Volcanium
                    new HarvestVein( 0.6, 0.0, m_Resources[10], m_Resources[0] ), // Acier
                    new HarvestVein( 0.5, 0.0, m_Resources[11], m_Resources[0] ), // Agapite
                    new HarvestVein( 0.4, 0.0, m_Resources[12], m_Resources[0] ), // Durian
                    new HarvestVein( 0.3, 0.0, m_Resources[13], m_Resources[0] ), // Equilibrum
                    new HarvestVein( 0.2, 0.0, m_Resources[14], m_Resources[0] ), // Etheryl*/
				        };

                //Console.WriteLine("Location X : " + x);
                //Console.WriteLine("Location Y : " + y);

                for (int i = 0; i < HarvestZone.HarvestZones.Count; ++i)
                {
                    zone = (HarvestZone)HarvestZone.HarvestZones[i];

                    if (zone != null && zone.ZoneType == ZoneType.Mining)
                    {
                        if (zone.Map != from.Map)
                            continue;

                        foreach (Rectangle3D rect in zone.Area)
                        {
                            Rectangle2D rectangle = new Rectangle2D((IPoint2D)(rect.Start), (IPoint2D)(rect.End));

                            /*Console.WriteLine(zone.GetType().Name);
                            Console.WriteLine("Rectangle X : " + rectangle.X + " Rectangle Y : " + rectangle.Y + " Rectangle Width : " + rectangle.Width);
                            Console.WriteLine("Rect Start X : " + rect.Start + " Rect End : " + rect.End);
                            Console.WriteLine("---------------------");*/

                            if (rectangle.Contains(new Point2D(x, y)))
                            {
                                //Console.WriteLine(zone.GetType().Name);
                                return zone.Veins;
                            }
                        }
                    }
                }
                
                return def;
            }
            else if (Skill == SkillName.Cuisine)
            {
                HarvestVein[] def = Veins;
                HarvestZone zone;

                for (int i = 0; i < HarvestZone.HarvestZones.Count; ++i)
                {
                    zone = (HarvestZone)HarvestZone.HarvestZones[i];

                    if (zone != null && zone.ZoneType == ZoneType.Fishing && zone.RequiredTool != null && tool.GetType() == zone.RequiredTool)
                    {
                        foreach (Rectangle3D rect in zone.Area)
                        {
                            Rectangle2D rectangle = new Rectangle2D((IPoint2D)(rect.Start), (IPoint2D)(rect.End));

                            if (rectangle.Contains(new Point2D(x, y)))
                            {
                                return zone.Veins;
                            }
                        }
                    }
                }

                return def;
            }

            return null;
        }

        public HarvestDefinition()
        {
            m_BanksByMap = new Hashtable();
        }

        public bool Validate(int tileID)
        {
            if (m_RangedTiles)
            {
                bool contains = false;

                for (int i = 0; !contains && i < m_Tiles.Length; i += 2)
                    contains = (tileID >= m_Tiles[i] && tileID <= m_Tiles[i + 1]);

                return contains;
            }
            else
            {
                for (int i = 0; i < m_Tiles.Length; ++i)
                    if (tileID == m_Tiles[i])
                        return true;

                return false;
            }
        }
    }
}