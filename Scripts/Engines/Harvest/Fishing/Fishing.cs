using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Harvest
{
	public class Fishing : HarvestSystem
	{
		private static Fishing m_System;

		public static Fishing System
		{
			get
			{
				if ( m_System == null )
					m_System = new Fishing();

				return m_System;
			}
		}

		private HarvestDefinition m_Definition;

		public HarvestDefinition Definition
		{
			get{ return m_Definition; }
		}

		private Fishing()
		{
			HarvestResource[] res;
			HarvestVein[] veins;

			#region Fishing
			HarvestDefinition fish = new HarvestDefinition();

			// Resource banks are every 8x8 tiles
			fish.BankWidth = 1;
			fish.BankHeight = 1;

			// Every bank holds from 5 to 15 fish
			fish.MinTotal = 8;
			fish.MaxTotal = 15;

			// A resource bank will respawn its content every 10 to 20 minutes
			fish.MinRespawn = TimeSpan.FromMinutes( 15.0 );
			fish.MaxRespawn = TimeSpan.FromMinutes( 25.0 );

			// Skill checking is done on the Fishing skill
			fish.Skill = SkillName.Cuisine;

			// Set the list of harvestable tiles
			fish.Tiles = m_WaterTiles;
			fish.RangedTiles = true;

			// Players must be within 4 tiles to harvest
			fish.MaxRange = 8;

			// One fish per harvest action
            //fish.MinConsumedPerHarvest = 1;
            //fish.MaxConsumedPerHarvest = 1;

			// The fishing
			fish.EffectActions = new int[]{ 12 };
			fish.EffectSounds = new int[0];
			fish.EffectCounts = new int[]{ 1 };
			fish.EffectDelay = TimeSpan.Zero;
			fish.EffectSoundDelay = TimeSpan.FromSeconds( 8.0 );

			fish.NoResourcesMessage = 503172; // The fish don't seem to be biting here.
			fish.FailMessage = 503171; // You fish a while, but fail to catch anything.
			fish.TimedOutOfRangeMessage = 500976; // You need to be closer to the water to fish!
			fish.OutOfRangeMessage = 500976; // You need to be closer to the water to fish!
			fish.PackFullMessage = 503176; // You do not have room in your backpack for a fish.
			fish.ToolBrokeMessage = 503174; // You broke your fishing pole.

            res = HarvestZone.Resources;

			veins = new HarvestVein[] //Partout ailleurs...
				{
				    new HarvestVein( 40.0, 0.0, HarvestZone.Resources[24], null ), //Truite
				    new HarvestVein( 15.0, 0.0, HarvestZone.Resources[25], null ), //Dore
				    new HarvestVein( 15.0, 0.0, HarvestZone.Resources[27], null ), //Anguille
				};

			fish.Resources = res;
			fish.Veins = veins;

			m_Definition = fish;
			Definitions.Add( fish );
			#endregion
		}

		public override void OnConcurrentHarvest( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
		{
			from.SendLocalizedMessage( 500972 ); // You are already fishing.
        }

        public override bool CheckRange(Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc, bool timed)
        {
            int maxRange = def.MaxRange;

            if (tool is Harpoon)
                maxRange = 4;
            else if (tool is FishingNet)
                maxRange = 3;

            bool inRange = (from.Map == map && from.InRange(loc, maxRange));

            if (!inRange)
                def.SendMessageTo(from, timed ? def.TimedOutOfRangeMessage : def.OutOfRangeMessage);

            return inRange;
        }

        /*private class MutateEntry
        {
            public double m_ReqSkill, m_MinSkill, m_MaxSkill;
            public Type[] m_Types;

            public MutateEntry(double reqSkill, double minSkill, double maxSkill, params Type[] types)
            {
                m_ReqSkill = reqSkill;
                m_MinSkill = minSkill;
                m_MaxSkill = maxSkill;
                m_Types = types;
            }
        }

        private static MutateEntry[] m_MutateTable = new MutateEntry[]
			{
				new MutateEntry(  80.0,  80.0,  4080.0, typeof( SpecialFishingNet ) ),
				new MutateEntry(  80.0,  80.0,  4080.0, typeof( BigFish ) ),
				new MutateEntry(  90.0,  80.0,  4080.0, typeof( TreasureMap ) ),
				new MutateEntry( 100.0,  80.0,  4080.0, typeof( MessageInABottle ) ),
				new MutateEntry(   0.0, 125.0, -2375.0, typeof( PrizedFish ), typeof( WondrousFish ), typeof( TrulyRareFish ), typeof( PeculiarFish ) ),
				new MutateEntry(   0.0, 105.0,  -420.0, typeof( Boots ), typeof( Shoes ), typeof( Sandals ), typeof( ThighBoots ) ),
				new MutateEntry(   0.0, 200.0,  -200.0, new Type[1]{ null } )
			};

        public override Type MutateType(Type type, Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc, HarvestResource resource)
        {
            double fishing = from.Skills[SkillName.Fishing].Base;

            for (int i = 0; i < m_MutateTable.Length; ++i)
            {
                MutateEntry entry = m_MutateTable[i];

                if (fishing >= entry.m_ReqSkill)
                {
                    double chance = (fishing - entry.m_MinSkill) / (entry.m_MaxSkill - entry.m_MinSkill);

                    if (chance > Utility.RandomDouble())
                        return entry.m_Types[Utility.Random(entry.m_Types.Length)];
                }
            }

            return type;
        }

        public override void SendSuccessTo(Mobile from, Item item, HarvestResource resource)
        {
            if (item is BaseAlga)
                from.SendMessage("Vous pêchez une algue et la déposez dans votre sac.");
            else
                base.SendSuccessTo(from, item, resource);
        }*/

		public override void OnHarvestStarted( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
		{
			base.OnHarvestStarted( from, tool, def, toHarvest );

			int tileID;
			Map map;
			Point3D loc;

			if ( GetHarvestDetails( from, tool, toHarvest, out tileID, out map, out loc ) )
				Timer.DelayCall( TimeSpan.FromSeconds( 1.5 ), new TimerStateCallback( Splash_Callback ), new object[]{ loc, map } );
		}

		private void Splash_Callback( object state )
		{
			object[] args = (object[])state;
			Point3D loc = (Point3D)args[0];
			Map map = (Map)args[1];

			Effects.SendLocationEffect( loc, map, 0x352D, 16, 4 );
			Effects.PlaySound( loc, map, 0x364 );
		}

        public override void StartHarvesting(Mobile from, Item tool, object toHarvest)
        {
            int tileID;
            Map map;
            Point3D loc;

            GetHarvestDetails(from, tool, toHarvest, out tileID, out map, out loc);

            if (tool is Harpoon && !HarvestDefinition.IsSea(loc.X, loc.Y))
            {
                from.SendMessage("Vous devez utiliser le harpon en haute mer.");
                return;
            }

            base.StartHarvesting(from, tool, toHarvest);
        }

		public override bool BeginHarvesting( Mobile from, Item tool )
		{
			if ( !base.BeginHarvesting( from, tool ) )
				return false;

			from.SendLocalizedMessage( 500974 ); // What water do you want to fish in?
			return true;
		}

        public override void FinishHarvesting(Mobile from, Item tool, HarvestDefinition def, object toHarvest, object locked)
        {
            if (tool is IFishingPole)
            {
                IFishingPole pole = (IFishingPole)tool;

                if (pole.Bait != Bait.Aucun && pole.Charge > 0)
                {
                    pole.Charge--;

                    if (pole.Charge <= 0)
                    {
                        pole.Bait = Bait.Aucun;
                        from.SendMessage("Votre appât s'est détruit.");
                    }
                }
            }

            base.FinishHarvesting(from, tool, def, toHarvest, locked);
        }

		public override bool CheckHarvest( Mobile from, Item tool )
		{
			if ( !base.CheckHarvest( from, tool ) )
				return false;

			if ( from.Mounted )
			{
				from.SendLocalizedMessage( 500971 ); // You can't fish while riding!
				return false;
			}

			return true;
		}

		public override bool CheckHarvest( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
		{
			if ( !base.CheckHarvest( from, tool, def, toHarvest ) )
				return false;

			if ( from.Mounted )
			{
				from.SendLocalizedMessage( 500971 ); // You can't fish while riding!
				return false;
			}

			return true;
        }

        public override bool Give(Mobile m, Item item, bool placeAtFeet, Point3D loc)
        {
            if (item is RequinGrisFish || item is RequinBlancFish)
            {
                Map map = m.Map;

                if (map == null)
                    return false;

                item.Amount = 151;
                item.MoveToWorld(loc, map);
                return true;
            }

            return base.Give(m, item, placeAtFeet, loc);
        }

		private static int[] m_WaterTiles = new int[]
			{
				0x00A8, 0x00AB,
				0x0136, 0x0137,
				0x5797, 0x579C,
				0x746E, 0x7485,
				0x7490, 0x74AB,
				0x74B5, 0x75D5
			};
	}
}