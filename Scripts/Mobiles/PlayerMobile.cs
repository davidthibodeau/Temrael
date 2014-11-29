using System;
using System.Collections;
using System.Collections.Generic;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using Server.Multis;
using Server.Engines.Help;
using Server.ContextMenus;
using Server.Network;
using Server.Spells;
using Server.Targeting;

using Server.Regions;
using Server.Accounting;
using Server.Engines.Craft;
using Server.Engines.PartySystem;
using Server.Engines.Langues;
using Server.Engines.Identities;
using Server.Engines.Races;
using Server.Engines.Evolution;
using Server.Engines.Mort;
using Server.Commands;
using Server.Engines.Possess;
using Server.Engines.Equitation;
using Server.Engines.Transformations;
using Server.Gumps.Fiche;

namespace Server.Mobiles
{
	#region Enums
	[Flags]
	public enum PlayerFlag // First 16 bits are reserved for default-distro use, start custom flags at 0x00010000
	{
		None					= 0x00000000,
		Glassblowing			= 0x00000001,
		Masonry					= 0x00000002,
		SandMining				= 0x00000004,
		StoneMining				= 0x00000008,
		ToggleMiningStone		= 0x00000010,
		KarmaLocked				= 0x00000020,
		UseOwnFilter			= 0x00000040,
		PublicMyRunUO			= 0x00000080,
		PagingSquelched			= 0x00000100,
		AcceptGuildInvites		= 0x00000200,
		DisplayChampionTitle	= 0x00000400,
		HasStatReward			= 0x00000800
	}

	public enum SolenFriendship
	{
		None,
		Red,
		Black
	}
	#endregion

	public class PlayerMobile : ScriptMobile
	{
		private class CountAndTimeStamp
		{
			private int m_Count;
			private DateTime m_Stamp;

			public CountAndTimeStamp()
			{
			}

			public DateTime TimeStamp { get{ return m_Stamp; } }
			public int Count
			{
				get { return m_Count; }
				set	{ m_Count = value; m_Stamp = DateTime.Now; }
			}
		}

		private DesignContext m_DesignContext;

		private DateTime m_NextBODTurnInTime;
		private PlayerFlag m_Flags;
		private int m_StepsTaken;
		private int m_Profession;
		private bool m_IgnoreMobiles; // IgnoreMobiles should be moved to Server.Mobiles
        private int m_LastTeinture = 0;

        private Point3D m_OldLocation;
		/*
		 * a value of zero means, that the mobile is not executing the spell. Otherwise,
		 * the value should match the BaseMana required
		*/

		private DateTime m_LastOnline;
		private Server.Guilds.RankDefinition m_GuildRank;

		private int m_GuildMessageHue, m_AllianceMessageHue;

		private List<Mobile> m_AutoStabled;
		private List<Mobile> m_AllFollowers;
		private List<Mobile> m_RecentlyReported;
        private Race race;

		#region Getters & Setters

		public List<Mobile> RecentlyReported
		{
			get
			{
				return m_RecentlyReported;
			}
			set
			{
				m_RecentlyReported = value;
			}
		}

		public List<Mobile> AutoStabled { get { return m_AutoStabled; } }

		public List<Mobile> AllFollowers
		{
			get
			{
				if( m_AllFollowers == null )
					m_AllFollowers = new List<Mobile>();
				return m_AllFollowers;
			}
		}

		public Server.Guilds.RankDefinition GuildRank
		{
			get
			{
				if( this.AccessLevel >= AccessLevel.Batisseur )
					return Server.Guilds.RankDefinition.Leader;
				else
					return m_GuildRank;
			}
			set{ m_GuildRank = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int GuildMessageHue
		{
			get{ return m_GuildMessageHue; }
			set{ m_GuildMessageHue = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int AllianceMessageHue
		{
			get { return m_AllianceMessageHue; }
			set { m_AllianceMessageHue = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int Profession
		{
			get{ return m_Profession; }
			set{ m_Profession = value; }
		}

		public int StepsTaken
		{
			get{ return m_StepsTaken; }
			set{ m_StepsTaken = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool IgnoreMobiles // IgnoreMobiles should be moved to Server.Mobiles
		{
			get
			{
				return m_IgnoreMobiles;
			}
			set
			{
				if( m_IgnoreMobiles != value )
				{
					m_IgnoreMobiles = value;
					Delta( MobileDelta.Flags );
				}
			}
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public DateTime NextBODTurnInTime
		{
			get{ return m_NextBODTurnInTime; }
			set{ m_NextBODTurnInTime = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public DateTime LastOnline
		{
			get{ return m_LastOnline; }
			set{ m_LastOnline = value; }
		}

		private int m_ToTItemsTurnedIn;

		[CommandProperty( AccessLevel.Batisseur )]
		public int ToTItemsTurnedIn
		{
			get { return m_ToTItemsTurnedIn; }
			set { m_ToTItemsTurnedIn = value; }
		}

		private int m_ToTTotalMonsterFame;

		[CommandProperty( AccessLevel.Batisseur )]
		public int ToTTotalMonsterFame
		{
			get { return m_ToTTotalMonsterFame; }
			set { m_ToTTotalMonsterFame = value; }
		}

        [CommandProperty(AccessLevel.Batisseur)]
        public Langues Langues
        {
            get;
            set;
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public Identities Identities
        {
            get;
            set;
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public Race Race
        {
            get
            {
                if (race == null)
                    return new AucuneRace();
                return race;
            }
            set
            {
                Race.SupprimerSkin(this);
                if (value != null)
                {
                    race = value;
                    Hue = value.Hue;
                    if (value.Skin != null)
                    {
                        RaceSkin r = (RaceSkin)Activator.CreateInstance(value.Skin);
                        r.Hue = value.Hue;
                        AddItem(r);
                    }
                }
                else
                    race = new AucuneRace();
            }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public QuiOptions QuiOptions
        {
            get;
            set;
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public Experience Experience
        {
            get;
            set;
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public MortEngine MortEngine
        {
            get;
            set;
        }

        public Possess Possess
        {
            get;
            set;
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public Transformation Transformation
        {
            get;
            set;
        }

        #region QuickSpells
        private ArrayList m_QuickSpells = new ArrayList();

        public ArrayList QuickSpells
        {
            get { return m_QuickSpells; }
        }
        #endregion
		#endregion

		#region PlayerFlags
		public PlayerFlag Flags
		{
			get{ return m_Flags; }
			set{ m_Flags = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool PagingSquelched
		{
			get{ return GetFlag( PlayerFlag.PagingSquelched ); }
			set{ SetFlag( PlayerFlag.PagingSquelched, value ); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool Glassblowing
		{
			get{ return GetFlag( PlayerFlag.Glassblowing ); }
			set{ SetFlag( PlayerFlag.Glassblowing, value ); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool Masonry
		{
			get{ return GetFlag( PlayerFlag.Masonry ); }
			set{ SetFlag( PlayerFlag.Masonry, value ); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool SandMining
		{
			get{ return GetFlag( PlayerFlag.SandMining ); }
			set{ SetFlag( PlayerFlag.SandMining, value ); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool StoneMining
		{
			get{ return GetFlag( PlayerFlag.StoneMining ); }
			set{ SetFlag( PlayerFlag.StoneMining, value ); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool ToggleMiningStone
		{
			get{ return GetFlag( PlayerFlag.ToggleMiningStone ); }
			set{ SetFlag( PlayerFlag.ToggleMiningStone, value ); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool KarmaLocked
		{
			get{ return GetFlag( PlayerFlag.KarmaLocked ); }
			set{ SetFlag( PlayerFlag.KarmaLocked, value ); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool UseOwnFilter
		{
			get{ return GetFlag( PlayerFlag.UseOwnFilter ); }
			set{ SetFlag( PlayerFlag.UseOwnFilter, value ); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool PublicMyRunUO
		{
			get{ return GetFlag( PlayerFlag.PublicMyRunUO ); }
			set{ SetFlag( PlayerFlag.PublicMyRunUO, value ); InvalidateMyRunUO(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool AcceptGuildInvites
		{
			get{ return GetFlag( PlayerFlag.AcceptGuildInvites ); }
			set{ SetFlag( PlayerFlag.AcceptGuildInvites, value ); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public bool HasStatReward
		{
			get{ return GetFlag( PlayerFlag.HasStatReward ); }
			set{ SetFlag( PlayerFlag.HasStatReward, value ); }
		}

        [CommandProperty(AccessLevel.Batisseur)]
        public int LastTeinture
        {
            get { return m_LastTeinture; }
            set { m_LastTeinture = value; }
        }

        public Point3D OldLocation { get { return m_OldLocation; } set { m_OldLocation = value; } }
		#endregion

		#region Auto Arrow Recovery
		private Dictionary<Type, int> m_RecoverableAmmo = new Dictionary<Type,int>();

		public Dictionary<Type, int> RecoverableAmmo
		{
			get { return m_RecoverableAmmo; }
		}

		public void RecoverAmmo()
		{
			if ( Core.SE && Alive )
			{
				foreach ( KeyValuePair<Type, int> kvp in m_RecoverableAmmo )
				{
					if ( kvp.Value > 0 )
					{
						Item ammo = null;

						try
						{
							ammo = Activator.CreateInstance( kvp.Key ) as Item;
						}
						catch
						{
						}

						if ( ammo != null )
						{
							string name = ammo.Name;
							ammo.Amount = kvp.Value;

							if ( name == null )
							{
								if ( ammo is Arrow )
									name = "arrow";
								else if ( ammo is Bolt )
									name = "bolt";
							}

							if ( name != null && ammo.Amount > 1 )
								name = String.Format( "{0}s", name );

							if ( name == null )
								name = String.Format( "#{0}", ammo.LabelNumber );

							PlaceInBackpack( ammo );
							SendLocalizedMessage( 1073504, String.Format( "{0}t{1}", ammo.Amount, name ) ); // You recover ~1_NUM~ ~2_AMMO~.
						}
					}
				}

				m_RecoverableAmmo.Clear();
			}
		}

		#endregion

		private DateTime m_PeacedUntil;

		[CommandProperty( AccessLevel.Batisseur )]
		public DateTime PeacedUntil
		{
			get { return m_PeacedUntil; }
			set { m_PeacedUntil = value; }
		}

		#region Scroll of Alacrity
		private DateTime m_AcceleratedStart;

		[CommandProperty(AccessLevel.Batisseur)]
		public DateTime AcceleratedStart
		{
			get { return m_AcceleratedStart; }
			set { m_AcceleratedStart = value; }
		}

		private SkillName m_AcceleratedSkill;

		[CommandProperty(AccessLevel.Batisseur)]
		public SkillName AcceleratedSkill
		{
			get { return m_AcceleratedSkill; }
			set { m_AcceleratedSkill = value; }
		}
		#endregion

		public static Direction GetDirection4( Point3D from, Point3D to )
		{
			int dx = from.X - to.X;
			int dy = from.Y - to.Y;

			int rx = dx - dy;
			int ry = dx + dy;

			Direction ret;

			if ( rx >= 0 && ry >= 0 )
				ret = Direction.West;
			else if ( rx >= 0 && ry < 0 )
				ret = Direction.South;
			else if ( rx < 0 && ry < 0 )
				ret = Direction.East;
			else
				ret = Direction.North;

			return ret;
		}

        public override bool OnDroppedItemToMobile(Item item, Mobile target)
        {
            if(!base.OnDroppedItemToMobile(item, target))
                return false;

            if (Region is ZoneCreation && AccessLevel == AccessLevel.Player)
            {
                SendMessage("Vous ne pouvez transférer un objet dans la zone de création.");
                return false;
            }

            return true;
        }

		public override bool OnDroppedItemToWorld( Item item, Point3D location )
		{
			if ( !base.OnDroppedItemToWorld( item, location ) )
				return false;

            if (Region is ZoneCreation && AccessLevel == AccessLevel.Player)
            {
                SendMessage("Vous ne pouvez déposer un objet dans la zone de création.");
                return false;
            }

			IPooledEnumerable mobiles = Map.GetMobilesInRange( location, 0 );

			foreach ( Mobile m in mobiles )
			{
				if ( m.Z >= location.Z && m.Z < location.Z + 16 )
				{
					mobiles.Free();
					return false;
				}
			}

			mobiles.Free();

			BounceInfo bi = item.GetBounce();

			if ( bi != null )
			{
				Type type = item.GetType();

				if ( type.IsDefined( typeof( FurnitureAttribute ), true ) || type.IsDefined( typeof( DynamicFlipingAttribute ), true ) )
				{
					object[] objs = type.GetCustomAttributes( typeof( FlipableAttribute ), true );

					if ( objs != null && objs.Length > 0 )
					{
						FlipableAttribute fp = objs[0] as FlipableAttribute;

						if ( fp != null )
						{
							int[] itemIDs = fp.ItemIDs;

							Point3D oldWorldLoc = bi.m_WorldLoc;
							Point3D newWorldLoc = location;

							if ( oldWorldLoc.X != newWorldLoc.X || oldWorldLoc.Y != newWorldLoc.Y )
							{
								Direction dir = GetDirection4( oldWorldLoc, newWorldLoc );

								if ( itemIDs.Length == 2 )
								{
									switch ( dir )
									{
										case Direction.North:
										case Direction.South: item.ItemID = itemIDs[0]; break;
										case Direction.East:
										case Direction.West: item.ItemID = itemIDs[1]; break;
									}
								}
								else if ( itemIDs.Length == 4 )
								{
									switch ( dir )
									{
										case Direction.South: item.ItemID = itemIDs[0]; break;
										case Direction.East: item.ItemID = itemIDs[1]; break;
										case Direction.North: item.ItemID = itemIDs[2]; break;
										case Direction.West: item.ItemID = itemIDs[3]; break;
									}
								}
							}
						}
					}
				}
			}

			return true;
		}

		public override int GetPacketFlags()
		{
			int flags = base.GetPacketFlags();

			if ( m_IgnoreMobiles )
				flags |= 0x10;

			return flags;
		}

		public override int GetOldPacketFlags()
		{
			int flags = base.GetOldPacketFlags();

			if ( m_IgnoreMobiles )
				flags |= 0x10;

			return flags;
		}

		public bool GetFlag( PlayerFlag flag )
		{
			return ( (m_Flags & flag) != 0 );
		}

		public void SetFlag( PlayerFlag flag, bool value )
		{
			if ( value )
				m_Flags |= flag;
			else
				m_Flags &= ~flag;
		}

		public DesignContext DesignContext
		{
			get{ return m_DesignContext; }
			set{ m_DesignContext = value; }
		}

		public static void Initialize()
		{
			if ( FastwalkPrevention )
				PacketHandlers.RegisterThrottler( 0x02, new ThrottlePacketCallback( MovementThrottle_Callback ) );

			EventSink.Login += new LoginEventHandler( OnLogin );
			EventSink.Logout += new LogoutEventHandler( OnLogout );
			EventSink.Connected += new ConnectedEventHandler( EventSink_Connected );
			EventSink.Disconnected += new DisconnectedEventHandler( EventSink_Disconnected );

			if( Core.SE )
			{
				Timer.DelayCall( TimeSpan.Zero, new TimerCallback( CheckPets ) );
			}
		}

		private static void CheckPets()
		{
			foreach( Mobile m in World.Mobiles.Values )
			{
				if( m is PlayerMobile )
				{
					PlayerMobile pm = (PlayerMobile)m;

					if((( !pm.Mounted || ( pm.Mount != null && pm.Mount is EtherealMount )) && ( pm.AllFollowers.Count > pm.AutoStabled.Count )) ||
						( pm.Mounted && ( pm.AllFollowers.Count  > ( pm.AutoStabled.Count +1 ))))
					{
						pm.AutoStablePets(); /* autostable checks summons, et al: no need here */
					}
				}
			}
		}

		public override void OnSkillInvalidated( Skill skill )
		{
			if ( Core.AOS && skill.SkillName == SkillName.Meditation )
				UpdateResistances();
		}

		public override int GetMaxResistance( ResistanceType type )
		{
			if ( AccessLevel > AccessLevel.Player )
				return int.MaxValue;

			int max = base.GetMaxResistance( type );

			return max;
		}

		private int m_LastGlobalLight = -1, m_LastPersonalLight = -1;

		public override void OnNetStateChanged()
		{
			m_LastGlobalLight = -1;
			m_LastPersonalLight = -1;
		}

		public override void ComputeBaseLightLevels( out int global, out int personal )
		{
			global = LightCycle.ComputeLevelFor( this );
            personal = this.LightLevel;
		}

		public override void CheckLightLevels( bool forceResend )
		{
			NetState ns = this.NetState;

			if ( ns == null )
				return;

			int global, personal;

			ComputeLightLevels( out global, out personal );

			if ( !forceResend )
				forceResend = ( global != m_LastGlobalLight || personal != m_LastPersonalLight );

			if ( !forceResend )
				return;

			m_LastGlobalLight = global;
			m_LastPersonalLight = personal;

			ns.Send( GlobalLightLevel.Instantiate( global ) );
			ns.Send( new PersonalLightLevel( this, personal ) );
		}

		public override int GetMinResistance( ResistanceType type )
		{
			//int magicResist = (int)(Skills[SkillName.Concentration].Value * 10);
			int min = int.MinValue;

			/*if ( magicResist >= 1000 )
				min = 40 + ((magicResist - 1000) / 50);
			else if ( magicResist >= 400 )
				min = (magicResist - 400) / 15;*/

			if ( min > MaxPlayerResistance )
				min = MaxPlayerResistance;

			int baseMin = base.GetMinResistance( type );

			if ( min < baseMin )
				min = baseMin;

			return min;
		}

		public override void OnManaChange(int oldValue)
		{
			base.OnManaChange(oldValue);
			//if (m_ExecutesLightningStrike > 0)
			//{
			//	if (Mana < m_ExecutesLightningStrike)
			//	{
			//		LightningStrike.ClearCurrentMove(this);
			//	}
			//}
		}

		private static void OnLogin( LoginEventArgs e )
		{
			Mobile from = e.Mobile;

			if ( AccountHandler.LockdownLevel > AccessLevel.Player )
			{
				string notice;

				Accounting.Account acct = from.Account as Accounting.Account;

				if ( acct == null || !acct.HasAccess( from.NetState ) )
				{
					if ( from.AccessLevel == AccessLevel.Player )
						notice = "The server is currently under lockdown. No players are allowed to log in at this time.";
					else
						notice = "The server is currently under lockdown. You do not have sufficient access level to connect.";

					Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Disconnect ), from );
				}
				else if ( from.AccessLevel >= AccessLevel.Coordinateur )
				{
					notice = "The server is currently under lockdown. As you are an administrator, you may change this from the [Admin gump.";
				}
				else
				{
					notice = "The server is currently under lockdown. You have sufficient access level to connect.";
				}

				from.SendGump( new NoticeGump( 1060637, 30720, notice, 0xFFC000, 300, 140, null, null ) );
				return;
			}

			if( from is PlayerMobile )
				((PlayerMobile)from).ClaimAutoStabledPets();
		}

		private bool m_NoDeltaRecursion;

		public void ValidateEquipment()
		{
			if ( m_NoDeltaRecursion || Map == null || Map == Map.Internal )
				return;

			if ( this.Items == null )
				return;

			m_NoDeltaRecursion = true;
			Timer.DelayCall( TimeSpan.Zero, new TimerCallback( ValidateEquipment_Sandbox ) );
		}

		private void ValidateEquipment_Sandbox()
		{
			try
			{
				if ( Map == null || Map == Map.Internal )
					return;

				List<Item> items = this.Items;

				if ( items == null )
					return;

				bool moved = false;

                int str = this.RawStr;  //this.Str;
                int dex = this.RawDex;  //this.Dex;
                int intel = this.RawInt;  //this.Int;

				#region Factions
				int factionItemCount = 0;
				#endregion

				Mobile from = this;

				for ( int i = items.Count - 1; i >= 0; --i )
				{
					if ( i >= items.Count )
						continue;

					Item item = items[i];

					/*if ( item is BaseWeapon )
					{
						BaseWeapon weapon = (BaseWeapon)item;

						bool drop = false;

						if( str < AOS.Scale( weapon.StrRequirement, 100 - weapon.GetLowerStatReq() ) )
							drop = true;

						if ( drop )
						{
							string name = weapon.Name;

							if ( name == null )
								name = String.Format( "#{0}", weapon.LabelNumber );

							from.SendLocalizedMessage( 1062001, name ); // You can no longer wield your ~1_WEAPON~
							from.AddToBackpack( weapon );
							moved = true;
						}
					}
					else */if ( item is BaseArmor )
					{
						BaseArmor armor = (BaseArmor)item;

						bool drop = false;

						if ( !armor.AllowMaleWearer && !from.Female && from.AccessLevel < AccessLevel.Batisseur )
						{
							drop = true;
						}
						else if ( !armor.AllowFemaleWearer && from.Female && from.AccessLevel < AccessLevel.Batisseur )
						{
							drop = true;
						}
						else
						{
							int strReq = armor.ComputeStatReq( StatType.Str );
							int dexReq = armor.ComputeStatReq( StatType.Dex );
							int intReq = armor.ComputeStatReq( StatType.Int );

                            if (dex < dexReq || dex < 1)
                                drop = true;
                            else if (str < strReq || str < 1)
                                drop = true;
                            else if (intel < intReq || intel < 1)
                                drop = true;
						}

						if ( drop )
						{
							string name = armor.Name;

							if ( name == null )
								name = String.Format( "#{0}", armor.LabelNumber );

							if ( armor is BaseShield )
								from.SendLocalizedMessage( 1062003, name ); // You can no longer equip your ~1_SHIELD~
							else
								from.SendLocalizedMessage( 1062002, name ); // You can no longer wear your ~1_ARMOR~

							from.AddToBackpack( armor );
							moved = true;
						}
					}
					else if ( item is BaseClothing )
					{
						BaseClothing clothing = (BaseClothing)item;

						bool drop = false;

						if ( !clothing.AllowMaleWearer && !from.Female && from.AccessLevel < AccessLevel.Batisseur )
						{
							drop = true;
						}
						else if ( !clothing.AllowFemaleWearer && from.Female && from.AccessLevel < AccessLevel.Batisseur )
						{
							drop = true;
						}
						else
						{
							int strReq = clothing.ComputeStatReq( StatType.Str );

							if( str < strReq)
								drop = true;
						}

						if ( drop )
						{
							string name = clothing.Name;

							if ( name == null )
								name = String.Format( "#{0}", clothing.LabelNumber );

							from.SendLocalizedMessage( 1062002, name ); // You can no longer wear your ~1_ARMOR~

							from.AddToBackpack( clothing );
							moved = true;
						}
					}
				}

				if ( moved )
					from.SendLocalizedMessage( 500647 ); // Some equipment has been moved to your backpack.
			}
			catch ( Exception e )
			{
				Console.WriteLine( e );
			}
			finally
			{
				m_NoDeltaRecursion = false;
			}
		}

		public override void Delta( MobileDelta flag )
		{
			base.Delta( flag );

			if ( (flag & MobileDelta.Stat) != 0 )
				ValidateEquipment();

			if ( (flag & (MobileDelta.Name | MobileDelta.Hue)) != 0 )
				InvalidateMyRunUO();
		}

		private static void Disconnect( object state )
		{
			NetState ns = ((Mobile)state).NetState;

			if ( ns != null )
				ns.Dispose();
		}

		private static void OnLogout( LogoutEventArgs e )
		{
			if( e.Mobile is PlayerMobile )
				((PlayerMobile)e.Mobile).AutoStablePets();
		}

        public override string GetNameUseBy(Mobile from)
        {           
            return Identities.GetNameUseBy(from);
        }

		private static void EventSink_Connected( ConnectedEventArgs e )
		{
			PlayerMobile pm = e.Mobile as PlayerMobile;

			if ( pm != null )
			{
				pm.m_SessionStart = DateTime.Now;

				pm.BedrollLogout = false;
				pm.LastOnline = DateTime.Now;
			}

			DisguiseTimers.StartTimer( e.Mobile );

			//Timer.DelayCall( TimeSpan.Zero, new TimerStateCallback( ClearSpecialMovesCallback ), e.Mobile );
		}

		/*private static void ClearSpecialMovesCallback( object state )
		{
			Mobile from = (Mobile)state;

			SpecialMove.ClearAllMoves( from );
		}*/

		private static void EventSink_Disconnected( DisconnectedEventArgs e )
		{
			Mobile from = e.Mobile;
			DesignContext context = DesignContext.Find( from );

			if ( context != null )
			{
				/* Client disconnected
				 *  - Remove design context
				 *  - Eject all from house
				 *  - Restore relocated entities
				 */

				// Remove design context
				DesignContext.Remove( from );

				// Eject all from house
				from.RevealingAction();

				foreach ( Item item in context.Foundation.GetItems() )
					item.Location = context.Foundation.BanLocation;

				foreach ( Mobile mobile in context.Foundation.GetMobiles() )
					mobile.Location = context.Foundation.BanLocation;

				// Restore relocated entities
				context.Foundation.RestoreRelocatedEntities();
			}

			PlayerMobile pm = e.Mobile as PlayerMobile;

			if ( pm != null )
			{
				pm.m_GameTime += (DateTime.Now - pm.m_SessionStart);

				pm.m_SpeechLog = null;
				pm.LastOnline = DateTime.Now;
			}

			DisguiseTimers.StopTimer( from );
		}

		public override void OnHiddenChanged()
		{
			base.OnHiddenChanged();

			RemoveBuff(BuffIcon.Invisibility);	//Always remove, default to the hiding icon EXCEPT in the invis spell where it's explicitly set

			if (!Hidden)
			{
				RemoveBuff(BuffIcon.HidingAndOrStealth);
			}
			else// if( !InvisibilitySpell.HasTimer( this ) )
			{
				BuffInfo.AddBuff(this, new BuffInfo(BuffIcon.HidingAndOrStealth, 1075655));	//Hidden/Stealthing & You Are Hidden
			}
		}

		public override void OnSubItemAdded( Item item )
		{
			if ( AccessLevel < AccessLevel.Batisseur && item.IsChildOf( this.Backpack ) )
			{
				int maxWeight = WeightOverloading.GetMaxWeight( this );
				int curWeight = Mobile.BodyWeight + this.TotalWeight;

				if ( curWeight > maxWeight )
					this.SendLocalizedMessage( 1019035, true, String.Format( " : {0} / {1}", curWeight, maxWeight ) );
			}
		}

		public override bool CanBeHarmful( Mobile target, bool message, bool ignoreOurBlessedness )
		{
			if ( m_DesignContext != null || (target is PlayerMobile && ((PlayerMobile)target).m_DesignContext != null) )
				return false;

			if ( (target is BaseVendor && ((BaseVendor)target).IsInvulnerable) || target is PlayerVendor || target is TownCrier )
			{
				if ( message )
				{
					if ( target.Title == null )
						SendMessage( "{0} the vendor cannot be harmed.", target.Name );
					else
						SendMessage( "{0} {1} cannot be harmed.", target.Name, target.Title );
				}

				return false;
			}

			return base.CanBeHarmful( target, message, ignoreOurBlessedness );
		}

		public override bool CanBeBeneficial( Mobile target, bool message, bool allowDead )
		{
			if ( m_DesignContext != null || (target is PlayerMobile && ((PlayerMobile)target).m_DesignContext != null) )
				return false;

			return base.CanBeBeneficial( target, message, allowDead );
		}

		public override bool CheckContextMenuDisplay( IEntity target )
		{
			return ( m_DesignContext == null );
		}

		public override void OnItemAdded( Item item )
		{
			base.OnItemAdded( item );

			if ( item is BaseArmor || item is BaseWeapon )
			{
				Hits=Hits; Stam=Stam; Mana=Mana;
			}

			if ( this.NetState != null )
				CheckLightLevels( false );

			InvalidateMyRunUO();
		}

		public override void OnItemRemoved( Item item )
		{
			base.OnItemRemoved( item );

			if ( item is BaseArmor || item is BaseWeapon )
			{
				Hits=Hits; Stam=Stam; Mana=Mana;
			}

			if ( this.NetState != null )
				CheckLightLevels( false );

			InvalidateMyRunUO();
		}

		public override double ArmorRating
		{
			get
			{
                return VirtualArmor + VirtualArmorMod;
			}
		}

		#region [Stats]Max
		[CommandProperty( AccessLevel.Batisseur )]
		public override int HitsMax
		{
            get { return Str + (RawStr >= 100 ? 125 : 100); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public override int StamMax
		{
            get { return 2 * Dex + (RawDex >= 100 ? 25 : 0); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public override int ManaMax
		{
			get { return 2 * Int + (RawInt >= 100 ? 25 : 0); }
		}
		#endregion

		#region Stat Getters/Setters

		[CommandProperty( AccessLevel.Batisseur )]
		public override int Str
		{
			get
			{
				if( Core.ML && this.AccessLevel == AccessLevel.Player )
					return Math.Min( base.Str, 150 );

				return base.Str;
			}
			set
			{
				base.Str = value;
			}
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public override int Int
		{
			get
			{
				if( Core.ML && this.AccessLevel == AccessLevel.Player )
					return Math.Min( base.Int, 150 );

				return base.Int;
			}
			set
			{
				base.Int = value;
			}
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public override int Dex
		{
			get
			{
				if( Core.ML && this.AccessLevel == AccessLevel.Player )
					return Math.Min( base.Dex, 150 );

				return base.Dex;
			}
			set
			{
				base.Dex = value;
			}
		}

		#endregion

		public override bool Move( Direction d )
		{
            Equitation.CheckEquitation(this, EquitationType.Running);

            if (Hidden && CheckRevealStealth() && AccessLevel == AccessLevel.Player)
            {
                RevealingAction();
            }

			NetState ns = this.NetState;

			if ( ns != null )
			{
				if ( HasGump( typeof( ResurrectGump ) ) ) {
					if ( Alive ) {
						CloseGump( typeof( ResurrectGump ) );
					} else {
						SendLocalizedMessage( 500111 ); // You are frozen and cannot move.
						return false;
					}
				}
			}

			int speed = ComputeMovementSpeed( d );

			bool res;

			if ( !Alive )
				Server.Movement.MovementImpl.IgnoreMovableImpassables = true;

			res = base.Move( d );

			Server.Movement.MovementImpl.IgnoreMovableImpassables = false;

			if ( !res )
				return false;

			m_NextMovementTime += speed;

			return true;
		}

        public bool CheckRevealStealth()
        {
            double stealth = this.Skills[SkillName.Infiltration].Base;

            if (stealth >= 100)
                return false;

            double chance = 0.80 * GetBagFilledRatio(this);

            if (chance >= Utility.RandomDouble())
                return true;

            return false;
        }

        public static double GetBagFilledRatio(PlayerMobile pm)
        {
            Container pack = pm.Backpack;

            if (pm.AccessLevel >= AccessLevel.Batisseur)
                return 0;

            if (pack != null)
            {
                int maxweight = WeightOverloading.GetMaxWeight(pm);

                double value = (pm.TotalWeight / maxweight) - 0.50;

                if (value < 0)
                    value = 0;

                if (value > 0.50)
                    value = 0.50;

                return value;
            }

            return 0;
        }

		public override bool CheckMovement( Direction d, out int newZ )
		{
			DesignContext context = m_DesignContext;

			if ( context == null )
				return base.CheckMovement( d, out newZ );

			HouseFoundation foundation = context.Foundation;

			newZ = foundation.Z + HouseFoundation.GetLevelZ( context.Level, context.Foundation );

			int newX = this.X, newY = this.Y;
			Movement.Movement.Offset( d, ref newX, ref newY );

			int startX = foundation.X + foundation.Components.Min.X + 1;
			int startY = foundation.Y + foundation.Components.Min.Y + 1;
			int endX = startX + foundation.Components.Width - 1;
			int endY = startY + foundation.Components.Height - 2;

			return ( newX >= startX && newY >= startY && newX < endX && newY < endY && Map == foundation.Map );
		}

		public override bool AllowItemUse( Item item )
		{
			return DesignContext.Check( this );
		}

		public override bool AllowSkillUse( SkillName skill )
		{
			/*if ( AnimalForm.UnderTransformation( this ) )
			
				for( int i = 0; i < m_AnimalFormRestrictedSkills.Length; i++ )
				{
					if( m_AnimalFormRestrictedSkills[i] == skill )
					{
						SendLocalizedMessage( 1070771 ); // You cannot use that skill in this form.
						return false;
					}
				}
			}*/

			return DesignContext.Check( this );
		}

		private bool m_LastProtectedMessage;
		private int m_NextProtectionCheck = 10;

		public virtual void RecheckTownProtection()
		{
			m_NextProtectionCheck = 10;

			Regions.GuardedRegion reg = (Regions.GuardedRegion) this.Region.GetRegion( typeof( Regions.GuardedRegion ) );
			bool isProtected = ( reg != null && !reg.IsDisabled() );

			if ( isProtected != m_LastProtectedMessage )
			{
				if ( isProtected )
					SendLocalizedMessage( 500112 ); // You are now under the protection of the town guards.
				else
					SendLocalizedMessage( 500113 ); // You have left the protection of the town guards.

				m_LastProtectedMessage = isProtected;
			}
		}

		public override void MoveToWorld( Point3D loc, Map map )
		{
			base.MoveToWorld( loc, map );

			RecheckTownProtection();
		}

		public override void SetLocation( Point3D loc, bool isTeleport )
		{
			if ( !isTeleport && AccessLevel == AccessLevel.Player )
			{
				// moving, not teleporting
				int zDrop = ( this.Location.Z - loc.Z );

				if ( zDrop > 20 ) // we fell more than one story
					Hits -= ((zDrop / 20) * 10) - 5; // deal some damage; does not kill, disrupt, etc
			}

			base.SetLocation( loc, isTeleport );

			if ( isTeleport || --m_NextProtectionCheck == 0 )
				RecheckTownProtection();
		}

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            if (from == this)
            {
                BaseHouse house = BaseHouse.FindHouseAt(this);

                if (house != null)
                {
                    if (Alive && house.InternalizedVendors.Count > 0 && house.IsOwner(this))
                        list.Add(new CallbackEntry(6204, new ContextCallback(GetVendor)));

                    if (house.IsAosRules)
                        list.Add(new CallbackEntry(6207, new ContextCallback(LeaveHouse)));
                }

                list.Add(new CallbackEntry(6098, new ContextCallback(LaunchFicheGump)));
                if (Race != null && (Race.isAasimaar || Race.isTieffelin))
                {
                    if (!Race.Transformed)
                        list.Add(new TransformerEntry(this));
                    else
                        list.Add(new DetransformerEntry(this));
                }
            }
            if (from != this)
            {
                if (Alive && Core.Expansion >= Expansion.AOS)
                {
                    Party theirParty = from.Party as Party;
                    Party ourParty = this.Party as Party;

                    if (theirParty == null && ourParty == null)
                    {
                        list.Add(new AddToPartyEntry(from, this));
                    }
                    else if (theirParty != null && theirParty.Leader == from)
                    {
                        if (ourParty == null)
                        {
                            list.Add(new AddToPartyEntry(from, this));
                        }
                        else if (ourParty == theirParty)
                        {
                            list.Add(new RemoveFromPartyEntry(from, this));
                        }
                    }
                }

                BaseHouse curhouse = BaseHouse.FindHouseAt(this);

                if (curhouse != null)
                {
                    if (Alive && Core.Expansion >= Expansion.AOS && curhouse.IsAosRules && curhouse.IsFriend(from))
                        list.Add(new EjectPlayerEntry(from, this));
                }

                if (from is PlayerMobile)
                    list.Add(new RenameEntry((PlayerMobile)from, this));

            }
        }

        private void LaunchFicheGump()
        {
            this.SendGump(new FicheRaceGump(this));
        }

		private void GetVendor()
		{
			BaseHouse house = BaseHouse.FindHouseAt( this );

			if ( CheckAlive() && house != null && house.IsOwner( this ) && house.InternalizedVendors.Count > 0 )
			{
				CloseGump( typeof( ReclaimVendorGump ) );
				SendGump( new ReclaimVendorGump( house ) );
			}
		}

		private void LeaveHouse()
		{
			BaseHouse house = BaseHouse.FindHouseAt( this );

			if ( house != null )
				this.Location = house.BanLocation;
		}

		public delegate void ContextCallback();

		public class CallbackEntry : ContextMenuEntry
		{
			private ContextCallback m_Callback;

			public CallbackEntry( int number, ContextCallback callback ) : this( number, -1, callback )
			{
			}

			public CallbackEntry( int number, int range, ContextCallback callback ) : base( number, range )
			{
				m_Callback = callback;
			}

			public override void OnClick()
			{
				if ( m_Callback != null )
					m_Callback();
			}
		}

		public override void DisruptiveAction()
		{
			if( Meditating )
			{
				RemoveBuff( BuffIcon.ActiveMeditation );
			}

			base.DisruptiveAction();
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( this == from && !Warmode )
			{
				IMount mount = Mount;

				if ( mount != null && !DesignContext.Check( this ) )
					return;
			}

			base.OnDoubleClick( from );
		}

		public override void DisplayPaperdollTo( Mobile to )
		{
			if ( DesignContext.Check( this ) )
				base.DisplayPaperdollTo( to );
		}

		private static bool m_NoRecursion;

		public override bool CheckEquip( Item item )
		{
			if ( !base.CheckEquip( item ) )
				return false;

			if ( this.AccessLevel < AccessLevel.Batisseur && item.Layer != Layer.Mount && this.HasTrade )
			{
				BounceInfo bounce = item.GetBounce();

				if ( bounce != null )
				{
					if ( bounce.m_Parent is Item )
					{
						Item parent = (Item) bounce.m_Parent;

						if ( parent == this.Backpack || parent.IsChildOf( this.Backpack ) )
							return true;
					}
					else if ( bounce.m_Parent == this )
					{
						return true;
					}
				}

				SendLocalizedMessage( 1004042 ); // You can only equip what you are already carrying while you have a trade pending.
				return false;
			}

            if (item is BaseClothing)
                if (((BaseClothing)item).Disguise)
                    Identities.DisguiseHidden = true;

			return true;
		}

		public override bool CheckTrade( Mobile to, Item item, SecureTradeContainer cont, bool message, bool checkItems, int plusItems, int plusWeight )
		{
			int msgNum = 0;

			if ( cont == null )
			{
				if ( to.Holding != null )
					msgNum = 1062727; // You cannot trade with someone who is dragging something.
				else if ( this.HasTrade )
					msgNum = 1062781; // You are already trading with someone else!
				else if ( to.HasTrade )
					msgNum = 1062779; // That person is already involved in a trade
			}

			if ( msgNum == 0 )
			{
				if ( cont != null )
				{
					plusItems += cont.TotalItems;
					plusWeight += cont.TotalWeight;
				}

				if ( this.Backpack == null || !this.Backpack.CheckHold( this, item, false, checkItems, plusItems, plusWeight ) )
					msgNum = 1004040; // You would not be able to hold this if the trade failed.
				else if ( to.Backpack == null || !to.Backpack.CheckHold( to, item, false, checkItems, plusItems, plusWeight ) )
					msgNum = 1004039; // The recipient of this trade would not be able to carry this.
				else
					msgNum = CheckContentForTrade( item );
			}

			if ( msgNum != 0 )
			{
				if ( message )
					this.SendLocalizedMessage( msgNum );

				return false;
			}

			return true;
		}

		private static int CheckContentForTrade( Item item )
		{
			if ( item is TrapableContainer && ((TrapableContainer)item).TrapType != TrapType.None )
				return 1004044; // You may not trade trapped items.

			if ( SkillHandlers.StolenItem.IsStolen( item ) )
				return 1004043; // You may not trade recently stolen items.

			if ( item is Container )
			{
				foreach ( Item subItem in item.Items )
				{
					int msg = CheckContentForTrade( subItem );

					if ( msg != 0 )
						return msg;
				}
			}

			return 0;
		}

		public override bool CheckNonlocalDrop( Mobile from, Item item, Item target )
		{
			if ( !base.CheckNonlocalDrop( from, item, target ) )
				return false;

			if ( from.AccessLevel >= AccessLevel.Batisseur )
				return true;

			Container pack = this.Backpack;
			if ( from == this && this.HasTrade && ( target == pack || target.IsChildOf( pack ) ) )
			{
				BounceInfo bounce = item.GetBounce();

				if ( bounce != null && bounce.m_Parent is Item )
				{
					Item parent = (Item) bounce.m_Parent;

					if ( parent == pack || parent.IsChildOf( pack ) )
						return true;
				}

				SendLocalizedMessage( 1004041 ); // You can't do that while you have a trade pending.
				return false;
			}

			return true;
		}

		protected override void OnLocationChange( Point3D oldLocation )
		{
			CheckLightLevels( false );

			DesignContext context = m_DesignContext;

			if ( context == null || m_NoRecursion )
				return;

			m_NoRecursion = true;

			HouseFoundation foundation = context.Foundation;

			int newX = this.X, newY = this.Y;
			int newZ = foundation.Z + HouseFoundation.GetLevelZ( context.Level, context.Foundation );

			int startX = foundation.X + foundation.Components.Min.X + 1;
			int startY = foundation.Y + foundation.Components.Min.Y + 1;
			int endX = startX + foundation.Components.Width - 1;
			int endY = startY + foundation.Components.Height - 2;

			if ( newX >= startX && newY >= startY && newX < endX && newY < endY && Map == foundation.Map )
			{
				if ( Z != newZ )
					Location = new Point3D( X, Y, newZ );

				m_NoRecursion = false;
				return;
			}

			Location = new Point3D( foundation.X, foundation.Y, newZ );
			Map = foundation.Map;

			m_NoRecursion = false;
		}

        public override bool OnMoveOver(Mobile m)
        {
            if (m.Hidden && m.AccessLevel > AccessLevel.Player)
            {
                return true;
            }
            if (Hidden)
            {
                return true;
            }
            if (m.Hidden)
            {
                m.Hidden = false;
            }
            if (!Mounted)
            {
                if (m.Stam == m.StamMax)
                {
                    if (m is PlayerMobile)
                    {
                        PlayerMobile from = (PlayerMobile)m;
                        from.SendMessage("Vous poussez le personnage hors de votre chemin.");
                        from.Stam -= 10;
                        this.SendMessage("Vous êtes poussé(e) hors du chemin par " + from.GetNameUseBy(this));
                        return true;
                    }
                    else
                    {
                        m.SendMessage("Vous poussez le personnage hors de votre chemin.");
                        m.Stam -= 10;
                        this.SendMessage("Vous êtes poussé(e) hors du chemin");
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

		public override bool CheckShove( Mobile shoved )
		{
			//if( m_IgnoreMobiles || TransformationSpellHelper.UnderTransformation( shoved, typeof( WraithFormSpell ) ) )
			//	return true;
			//else
				return base.CheckShove( shoved );
		}


        public override void AddNameProperties(ObjectPropertyList list)
        {
            string name = "";

            if (name == null)
                name = String.Empty;

            string color = "#ba52ff"; //"#FFFFFF";

            list.Add(1060526, String.Format("<h3><BASEFONT COLOR={0}>{1}, {2}</BASEFONT></h3>", color, name, Title)); // ~1_PREFIX~~2_NAME~~3_SUFFIX~
        }

        public override void SendPropertiesTo(Mobile from)
        {
            string color = "#ba52ff"; //"#FFFFFF";

            string displayName = GetNameUseBy(from);
            //if (!CanBeginAction(typeof(IncognitoSpell)))
            //{
            //    displayName = "Anonyme";
            //}

            ObjectPropertyList list = new ObjectPropertyList(this);

            list.Add("<h3><basefont color=" + color + ">" + displayName + (Title == "" ? "" : (", " + Title)) + "<basefont></h3>");

            from.Send(list);

        }

		protected override void OnMapChange( Map oldMap )
		{
			DesignContext context = m_DesignContext;

			if ( context == null || m_NoRecursion )
				return;

			m_NoRecursion = true;

			HouseFoundation foundation = context.Foundation;

			if ( Map != foundation.Map )
				Map = foundation.Map;

			m_NoRecursion = false;
		}

		public override void OnBeneficialAction( Mobile target, bool isCriminal )
		{
			base.OnBeneficialAction( target, isCriminal );
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			int disruptThreshold;

			if ( !Core.AOS )
				disruptThreshold = 0;
			else if ( from != null && from.Player )
				disruptThreshold = 18;
			else
				disruptThreshold = 25;

			if ( amount > disruptThreshold )
			{
				BandageContext c = BandageContext.GetContext( this );

				if ( c != null )
					c.Slip();
			}

			//if( Confidence.IsRegenerating( this ) )
			//	Confidence.StopRegenerating( this );

			WeightOverloading.FatigueOnDamage( this, amount );

			if ( willKill && from is PlayerMobile )
				Timer.DelayCall( TimeSpan.FromSeconds( 10 ), new TimerCallback( ((PlayerMobile) from).RecoverAmmo ) );

            if (from != null && Hidden && from.CanSee(this) && from.InLOS(this))
                RevealingAction();

			base.OnDamage( amount, from, willKill );
		}

		public override void Resurrect()
		{
			bool wasAlive = this.Alive;

			base.Resurrect();

			if ( this.Alive && !wasAlive )
			{
				/*Item deathRobe = new DeathRobe();

				if ( !EquipItem( deathRobe ) )
					deathRobe.Delete();*/
			}
		}

		public override void OnWarmodeChanged()
		{
			if ( !Warmode )
				Timer.DelayCall( TimeSpan.FromSeconds( 10 ), new TimerCallback( RecoverAmmo ) );
		}

		private bool FindItems_Callback(Item item)
		{
			if (!item.Deleted && (item.LootType == LootType.Blessed))
			{
				if (this.Backpack != item.Parent)
				{
					return true;
				}
			}
			return false;
		}

		public override bool OnBeforeDeath()
		{
            if (!Possess.OnBeforeDeath())
                return false;
            
			NetState state = NetState;

			if ( state != null )
				state.CancelAllTrades();

			DropHolding();

			if (Backpack != null && !Backpack.Deleted)
			{
				List<Item> ilist = Backpack.FindItemsByType<Item>(FindItems_Callback);

				for (int i = 0; i < ilist.Count; i++)
				{
					Backpack.AddItem(ilist[i]);
				}
			}

			RecoverAmmo();

			return base.OnBeforeDeath();
		}

        public override void OnDeath(Container c)
        {
            if (LastKiller is BaseCreature)
            {
                LastKiller.RemoveAggressor(this);
            }
            //if (PourrissementSpell.m_PourrissementTable.Contains(this))
            //{
            //    FixedParticles(14000, 10, 15, 5013, 264, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
            //    PlaySound(1099);

            //    double damage = (double)PourrissementSpell.m_PourrissementTable[this] + Utility.Random(1, 10);
            //    Mobile Caster = (Mobile)PourrissementSpell.m_PourrissementRegistry[this];

            //    ArrayList targets = new ArrayList();

            //    Map map = this.Map;

            //    if (map != null && Caster != null)
            //    {
            //        foreach (Mobile m in this.GePlayerMobilesInRange(5))
            //        {
            //            if (this != m && SpellHelper.ValidIndirectTarget(this, m) && !(this.Party == m.Party))
            //            {
            //                targets.Add(m);
            //            }
            //        }
            //    }

            //    if (targets.Count > 0 && Caster != null)
            //    {
            //        for (int i = 0; i < targets.Count; ++i)
            //        {
            //            Mobile m = (Mobile)targets[i];

            //            m.Paralyzed = false;

            //            this.DoHarmful(m);
            //            AOS.Damage(m, Caster, (int)damage, 0, 0, 0, 100, 0);

            //            m.FixedParticles(14000, 10, 15, 5013, 264, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
            //            m.PlaySound(1099);
            //        }
            //    }
            //}

            base.OnDeath(c);

            HueMod = -1;
            NameMod = null;

            SetHairMods(-1, -1);

            PolymorphSpell.StopTimer(this);
            IncognitoSpell.StopTimer(this);
            DisguiseTimers.RemoveTimer(this);

            EndAction(typeof(PolymorphSpell));
            EndAction(typeof(IncognitoSpell));

            SkillHandlers.StolenItem.ReturnOnDeath(this, c);

            if (m_PermaFlags.Count > 0)
            {
                m_PermaFlags.Clear();

                if (c is Corpse)
                    ((Corpse)c).Criminal = true;
            }

            Mobile killer = this.FindMostRecentDamager(true);

            if (killer is BaseCreature)
            {
                BaseCreature bc = (BaseCreature)killer;

                Mobile master = bc.GetMaster();
                if (master != null)
                    killer = master;
            }

            Server.Guilds.Guild.HandleDeath(this, killer);

            if (m_BuffTable != null)
            {
                List<BuffInfo> list = new List<BuffInfo>();

                foreach (BuffInfo buff in m_BuffTable.Values)
                {
                    if (!buff.RetainThroughDeath)
                    {
                        list.Add(buff);
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    RemoveBuff(list[i]);
                }
            }

            //EndAction(typeof(ChauveSouris));
            Transformation.DispelAllTransformations();
            //CheckEtude();

            if (!MortEngine.RisqueDeMort)
            {
                MortEngine.Corps = c;

                EvanouieTimer timer = new EvanouieTimer(this, c, (int)Direction, MortEngine.RisqueDeMort);
                MortEngine.TimerEvanouie = timer;
                timer.Start();

                Transformation.OnTransformationChange(0, null, -1, true); //Retirer spell transformation

                CheckRaceSkin();

                BaseArmor.ValidateMobile(this);

                if (Blessed && AccessLevel == AccessLevel.Player)
                    Blessed = false;

                MortEngine.MortCurrentState = MortState.Assomage;

                //SendMessage("Vous êtes assommé pour une minute.");
            }
            else
            {
                /*if (m_DeguisementInfos != null)
                {
                    Deguisements.RemoveDeguisement(this);
                }*/

                //Disguised = false;

                NameMod = null;
                BodyMod = 0;
                HueMod = -1;

                CheckRaceSkin();

                BaseArmor.ValidateMobile(this);

                MortEngine.RisqueDeMort = false;
                MortEngine.Mort = true;
                Send(PlayMusic.GetInstance(MusicName.Death));
                Location = Utility.RandomBool() ? new Point3D(5280, 2160, 5) : new Point3D(5283, 2013, 60);
                Frozen = false;

                if (Blessed && AccessLevel == AccessLevel.Player)
                    Blessed = false;

                //m_MortState = MortState.MortDefinitive;
            }
        }

        public virtual void CheckRaceSkin()
        {
            Item racegump = FindItemOnLayer(Layer.Shirt);

            if (racegump != null && racegump is RaceSkin)
                ((RaceSkin)racegump).AddProperties(this);
        }

		private List<Mobile> m_PermaFlags;
		private List<Mobile> m_VisList;
		private Hashtable m_AntiMacroTable;
		private TimeSpan m_GameTime;
		private TimeSpan m_ShortTermElapse;
		private TimeSpan m_LongTermElapse;
		private DateTime m_SessionStart;
		private DateTime m_NextSmithBulkOrder;
		private DateTime m_NextTailorBulkOrder;
		private SkillName m_Learning = (SkillName)(-1);

		public SkillName Learning
		{
			get{ return m_Learning; }
			set{ m_Learning = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public TimeSpan NextSmithBulkOrder
		{
			get
			{
				TimeSpan ts = m_NextSmithBulkOrder - DateTime.Now;

				if ( ts < TimeSpan.Zero )
					ts = TimeSpan.Zero;

				return ts;
			}
			set
			{
				try{ m_NextSmithBulkOrder = DateTime.Now + value; }
				catch{}
			}
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public TimeSpan NextTailorBulkOrder
		{
			get
			{
				TimeSpan ts = m_NextTailorBulkOrder - DateTime.Now;

				if ( ts < TimeSpan.Zero )
					ts = TimeSpan.Zero;

				return ts;
			}
			set
			{
				try{ m_NextTailorBulkOrder = DateTime.Now + value; }
				catch{}
			}
		}

		public PlayerMobile()
		{
			m_AutoStabled = new List<Mobile>();

			m_VisList = new List<Mobile>();
			m_PermaFlags = new List<Mobile>();
			m_AntiMacroTable = new Hashtable();
			m_RecentlyReported = new List<Mobile>();

			m_BOBFilter = new Engines.BulkOrders.BOBFilter();

			m_GameTime = TimeSpan.Zero;
			m_ShortTermElapse = TimeSpan.FromHours( 8.0 );
			m_LongTermElapse = TimeSpan.FromHours( 40.0 );
			m_GuildRank = Guilds.RankDefinition.Lowest;

            Langues = new Langues(this);
            Identities = new Identities(this);
            Experience = new Experience();
            MortEngine = new MortEngine(this);
            Transformation = new Transformation(this);
            Possess = new Possess(this);

            SkillsCap = 1000;
            FollowersMax = 5;

			InvalidateMyRunUO();
		}

		public override bool MutateSpeech( List<Mobile> hears, ref string text, ref object context )
		{
            if (Alive)
            {
                for (int h = 0; h < hears.Count; ++h)
                {
                    Mobile o = hears[h];
                    if (o is PlayerMobile)
                    {
                        PlayerMobile player = o as PlayerMobile;

                        bool isEmote = false;

                        char debut = text[0];
                        char fin = text[text.Length - 1];

                        isEmote = (debut.ToString() == "*" && fin.ToString() == "*");

                        if (isEmote)
                            return false;

                        return Langues.MutateSpeech(ref text);
                    }
                }

            }

			return base.MutateSpeech( hears, ref text, ref context );
		}

        public override bool CheckHearsMutatedSpeech(Mobile m, object context)
        {
            if (m is PlayerMobile)
            {
                PlayerMobile player = m as PlayerMobile;

                return Langues.HearsGibberish(player);
            }
            return true;
        }

        public override void OnSaid(SpeechEventArgs e)
        {
            ArrayList targets = new ArrayList();

            if (e.Speech.StartsWith("[") || e.Speech.StartsWith("."))
            {
                CommandSystem.Handle(this, String.Format("{0}{1}", CommandSystem.Prefix, e.Speech.Substring(1)));
                e.Blocked = true;
                base.OnSaid(e);
                return;
            }

            if (e.Type == MessageType.Whisper)
            {
                foreach (Mobile m in this.GetMobilesInRange(10))
                {
                    if (m.AccessLevel >= AccessLevel.Counselor)
                        targets.Add(m);
                }

                if (targets.Count > 0)
                {
                    for (int i = 0; i < targets.Count; ++i)
                    {
                        Mobile m = (Mobile)targets[i];
                        m.SendMessage(91, "Chuchottement de {0} : {1}", e.Mobile.Name, e.Speech);
                    }
                }
            }

            //PublicOverheadFontMessage(this, MessageType.Regular, SpeechHue, 1, e.Speech, true);
            //e.Blocked = true;

            //if (!e.Blocked && e.Type != MessageType.Whisper)
            //   RevealingAction(true);
        }

		public override void DoSpeech( string text, int[] keywords, MessageType type, int hue )
		{
			if( Guilds.Guild.NewGuildSystem && (type == MessageType.Guild || type == MessageType.Alliance) )
			{
				Guilds.Guild g = this.Guild as Guilds.Guild;
				if( g == null )
				{
					SendLocalizedMessage( 1063142 ); // You are not in a guild!
				}
				else if( type == MessageType.Alliance )
				{
					if( g.Alliance != null && g.Alliance.IsMember( g ) )
					{
						//g.Alliance.AllianceTextMessage( hue, "[Alliance][{0}]: {1}", this.Name, text );
						g.Alliance.AllianceChat( this, text );
						SendToStaffMessage( this, "[Alliance]: {0}", text );

						m_AllianceMessageHue = hue;
					}
					else
					{
						SendLocalizedMessage( 1071020 ); // You are not in an alliance!
					}
				}
				else	//Type == MessageType.Guild
				{
					m_GuildMessageHue = hue;

					g.GuildChat( this, text );
					SendToStaffMessage( this, "[Guild]: {0}", text );
				}
			}
			else
			{
				base.DoSpeech( text, keywords, type, hue );
			}
		}

		private static void SendToStaffMessage( Mobile from, string text )
		{
			Packet p = null;

			foreach( NetState ns in from.GetClientsInRange( 8 ) )
			{
				Mobile mob = ns.Mobile;

				if( mob != null && mob.AccessLevel >= AccessLevel.Batisseur && mob.AccessLevel > from.AccessLevel )
				{
					if( p == null )
						p = Packet.Acquire( new UnicodeMessage( from.Serial, from.Body, MessageType.Regular, from.SpeechHue, 3, from.Language, from.Name, text ) );

					ns.Send( p );
				}
			}

			Packet.Release( p );
		}

		private static void SendToStaffMessage( Mobile from, string format, params object[] args )
		{
			SendToStaffMessage( from, String.Format( format, args ) );
		}

		public override void Damage( int amount, Mobile from )
		{
			if ( Spells.EvilOmenSpell.CheckEffect( this ) )
				amount = (int)(amount * 1.25);

			base.Damage( amount, from );
		}

        public override void OnAosSingleClick(Mobile from)
        {
            ObjectPropertyList opl = new ObjectPropertyList(this);
            string name = GetNameUseBy(from);
            opl.Add(name);

            if (opl.Header > 0)
            {
                int hue = 11;
                from.Send(new MessageLocalized(this.Serial, Body, MessageType.Label, hue, 3, opl.Header, name, opl.HeaderArgs));
            }
        }

		#region Poison

		public override ApplyPoisonResult ApplyPoison( Mobile from, Poison poison )
		{
			if ( !Alive )
				return ApplyPoisonResult.Immune;

			if ( Spells.EvilOmenSpell.CheckEffect( this ) )
				poison = PoisonImpl.IncreaseLevel( poison );

			ApplyPoisonResult result = base.ApplyPoison( from, poison );

			if ( from != null && result == ApplyPoisonResult.Poisoned && PoisonTimer is PoisonImpl.PoisonTimer )
				(PoisonTimer as PoisonImpl.PoisonTimer).From = from;

			return result;
		}
		#endregion

		public PlayerMobile( Serial s ) : base( s )
		{
			m_VisList = new List<Mobile>();
			m_AntiMacroTable = new Hashtable();
			InvalidateMyRunUO();
		}

		public List<Mobile> VisibilityList
		{
			get{ return m_VisList; }
		}

		public List<Mobile> PermaFlags
		{
			get{ return m_PermaFlags; }
		}

		public bool AntiMacroCheck( Skill skill, object obj )
		{
			if ( obj == null || m_AntiMacroTable == null || this.AccessLevel != AccessLevel.Player )
				return true;

			Hashtable tbl = (Hashtable)m_AntiMacroTable[skill];
			if ( tbl == null )
				m_AntiMacroTable[skill] = tbl = new Hashtable();

			CountAndTimeStamp count = (CountAndTimeStamp)tbl[obj];
			if ( count != null )
			{
				if ( count.TimeStamp + SkillCheck.AntiMacroExpire <= DateTime.Now )
				{
					count.Count = 1;
					return true;
				}
				else
				{
					++count.Count;
					if ( count.Count <= SkillCheck.Allowance )
						return true;
					else
						return false;
				}
			}
			else
			{
				tbl[obj] = count = new CountAndTimeStamp();
				count.Count = 1;

				return true;
			}
		}

		private void RevertHair()
		{
			SetHairMods( -1, -1 );
		}

		private Engines.BulkOrders.BOBFilter m_BOBFilter;

		public Engines.BulkOrders.BOBFilter BOBFilter
		{
			get{ return m_BOBFilter; }
		}

		public override void Deserialize( GenericReader reader )
		{
            base.Deserialize(reader);
            int version = reader.ReadInt();

            Langues = new Langues(this, reader);
            Identities = new Identities(this, reader);
            QuiOptions = (QuiOptions)reader.ReadInt();
            Experience = new Experience(reader);
            MortEngine = new MortEngine(this, reader);
            Possess = new Possess(this, reader);
            Transformation = new Transformation(this);
            if (version > 0)
                Race = Race.Deserialize(reader);

            m_QuickSpells = new ArrayList();
            int count = reader.ReadInt();
            for (int i = 0; i < count; i++)
            {
                m_QuickSpells.Add((int)reader.ReadInt());
            }

            m_LastTeinture = reader.ReadInt();

            m_PeacedUntil = reader.ReadDateTime();

            m_AutoStabled = reader.ReadStrongMobileList();

            int recipeCount = reader.ReadInt();

            if (recipeCount > 0)
            {
                m_AcquiredRecipes = new Dictionary<int, bool>();

                for (int i = 0; i < recipeCount; i++)
                {
                    int r = reader.ReadInt();
                    if (reader.ReadBool())	//Don't add in recipies which we haven't gotten or have been removed
                        m_AcquiredRecipes.Add(r, true);
                }
            }

            m_ToTItemsTurnedIn = reader.ReadEncodedInt();
            m_ToTTotalMonsterFame = reader.ReadInt();

            m_AllianceMessageHue = reader.ReadEncodedInt();
            m_GuildMessageHue = reader.ReadEncodedInt();


            int rank = reader.ReadEncodedInt();
            int maxRank = Guilds.RankDefinition.Ranks.Length - 1;
            if (rank > maxRank)
                rank = maxRank;

            m_GuildRank = Guilds.RankDefinition.Ranks[rank];
            m_LastOnline = reader.ReadDateTime();

            m_Profession = reader.ReadEncodedInt();

            m_BOBFilter = new Engines.BulkOrders.BOBFilter(reader);

            if (reader.ReadBool())
            {
                m_HairModID = reader.ReadInt();
                m_HairModHue = reader.ReadInt();
                m_BeardModID = reader.ReadInt();
                m_BeardModHue = reader.ReadInt();
            }

            m_PermaFlags = reader.ReadStrongMobileList();

            NextTailorBulkOrder = reader.ReadTimeSpan();

            NextSmithBulkOrder = reader.ReadTimeSpan();

            m_Flags = (PlayerFlag)reader.ReadInt();

            m_LongTermElapse = reader.ReadTimeSpan();
            m_ShortTermElapse = reader.ReadTimeSpan();
            m_GameTime = reader.ReadTimeSpan();

			if (m_RecentlyReported == null)
				m_RecentlyReported = new List<Mobile>();

			// Professions weren't verified on 1.0 RC0
			if ( !CharacterCreation.VerifyProfession( m_Profession ) )
				m_Profession = 0;

			if ( m_PermaFlags == null )
				m_PermaFlags = new List<Mobile>();

			if ( m_BOBFilter == null )
				m_BOBFilter = new Engines.BulkOrders.BOBFilter();

			if( m_GuildRank == null )
				m_GuildRank = Guilds.RankDefinition.Member;	//Default to member if going from older verstion to new version (only time it should be null)

			if( m_LastOnline == DateTime.MinValue && Account != null )
				m_LastOnline = ((Account)Account).LastLogin;

			if ( AccessLevel > AccessLevel.Player )
				m_IgnoreMobiles = true;

			List<Mobile> list = this.Stabled;

			for ( int i = 0; i < list.Count; ++i )
			{
				BaseCreature bc = list[i] as BaseCreature;

				if ( bc != null )
					bc.IsStabled = true;
			}

			if( Hidden )	//Hiding is the only buff where it has an effect that's serialized.
				AddBuff( new BuffInfo( BuffIcon.HidingAndOrStealth, 1075655 ) );

            if (Blessed && AccessLevel == AccessLevel.Player)
                Blessed = false;

            CheckRaceSkin();

            BaseArmor.ValidateMobile(this);
		}

		public override void Serialize( GenericWriter writer )
		{
			//cleanup our anti-macro table
			foreach ( Hashtable t in m_AntiMacroTable.Values )
			{
				ArrayList remove = new ArrayList();
				foreach ( CountAndTimeStamp time in t.Values )
				{
					if ( time.TimeStamp + SkillCheck.AntiMacroExpire <= DateTime.Now )
						remove.Add( time );
				}

				for (int i=0;i<remove.Count;++i)
					t.Remove( remove[i] );
			}

			base.Serialize( writer );

            writer.Write((int)1); // version

            Langues.Serialize(writer);
            Identities.Serialize(writer);
            writer.Write((int)QuiOptions);
            Experience.Serialize(writer);
            MortEngine.Serialize(writer);
            Possess.Serialize(writer);
            Race.SerializeRace(Race, writer);

            writer.Write(m_QuickSpells.Count);
            for (int i = 0; i < m_QuickSpells.Count; i++)
                writer.Write((int)m_QuickSpells[i]);
            
            writer.Write((int)m_LastTeinture);

			writer.Write( (DateTime) m_PeacedUntil );

			writer.Write( m_AutoStabled, true );

			if( m_AcquiredRecipes == null )
			{
				writer.Write( (int)0 );
			}
			else
			{
				writer.Write( m_AcquiredRecipes.Count );

				foreach( KeyValuePair<int, bool> kvp in m_AcquiredRecipes )
				{
					writer.Write( kvp.Key );
					writer.Write( kvp.Value );
				}
			}

			writer.WriteEncodedInt( m_ToTItemsTurnedIn );
			writer.Write( m_ToTTotalMonsterFame );	//This ain't going to be a small #.

			writer.WriteEncodedInt( m_AllianceMessageHue );
			writer.WriteEncodedInt( m_GuildMessageHue );

			writer.WriteEncodedInt( m_GuildRank.Rank );
			writer.Write( m_LastOnline );

			writer.WriteEncodedInt( (int) m_Profession );

			m_BOBFilter.Serialize( writer );

			bool useMods = ( m_HairModID != -1 || m_BeardModID != -1 );

			writer.Write( useMods );

			if ( useMods )
			{
				writer.Write( (int) m_HairModID );
				writer.Write( (int) m_HairModHue );
				writer.Write( (int) m_BeardModID );
				writer.Write( (int) m_BeardModHue );
			}

			writer.Write( m_PermaFlags, true );

			writer.Write( NextTailorBulkOrder );

			writer.Write( NextSmithBulkOrder );

			writer.Write( (int) m_Flags );

			writer.Write( m_LongTermElapse );
			writer.Write( m_ShortTermElapse );
			writer.Write( this.GameTime );
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public DateTime SessionStart
		{
			get{ return m_SessionStart; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public TimeSpan GameTime
		{
			get
			{
				if ( NetState != null )
					return m_GameTime + (DateTime.Now - m_SessionStart);
				else
					return m_GameTime;
			}
		}

		public override bool CanSee( Mobile m )
		{
			if ( m is PlayerMobile && ((PlayerMobile)m).m_VisList.Contains( this ) )
				return true;

			return base.CanSee( m );
		}

		public override bool CanSee( Item item )
		{
			if ( m_DesignContext != null && m_DesignContext.Foundation.IsHiddenToCustomizer( item ) )
				return false;

			return base.CanSee( item );
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			BaseHouse.HandleDeletion( this );

			DisguiseTimers.RemoveTimer( this );
		}

		public override bool NewGuildDisplay { get { return Server.Guilds.Guild.NewGuildSystem; } }

		public override void OnAfterNameChange( string oldName, string newName )
		{
            Identities.NewCharacterSetName();
		}

        public override void OnAfterMove(Direction d)
        {
            if (Hidden && DesignContext.Find(this) == null)	//Hidden & NOT customizing a house
            {
                if (AccessLevel > AccessLevel.Player)
                    return;

                if (!Mounted && Skills.Infiltration.Value >= 25.0)
                {
                    if ((d & Direction.Running) != 0) // isRunning
                    {
                        if ((AllowedStealthSteps -= Server.SkillHandlers.Stealth.CoutPasCourse) <= 0)
                        {
                            Server.SkillHandlers.Stealth.OnUse(this);
                        }
                    }
                    else if ((AllowedStealthSteps -= Server.SkillHandlers.Stealth.CoutPasMarche) <= 0)
                    {
                        Server.SkillHandlers.Stealth.OnUse(this);
                    }
                }
                else
                {
                    RevealingAction();
                }
            }
        }

		private bool m_BedrollLogout;

		public bool BedrollLogout
		{
			get{ return m_BedrollLogout; }
			set{ m_BedrollLogout = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public override bool Paralyzed
		{
			get
			{
				return base.Paralyzed;
			}
			set
			{
				base.Paralyzed = value;

				if( value )
					AddBuff( new BuffInfo( BuffIcon.Paralyze, 1075827 ) );	//Paralyze/You are frozen and can not move
				else
					RemoveBuff( BuffIcon.Paralyze );
			}
		}

		#region MyRunUO Invalidation
		private bool m_ChangedMyRunUO;

		public bool ChangedMyRunUO
		{
			get{ return m_ChangedMyRunUO; }
			set{ m_ChangedMyRunUO = value; }
		}

		public void InvalidateMyRunUO()
		{
			if ( !Deleted && !m_ChangedMyRunUO )
			{
				m_ChangedMyRunUO = true;
				Engines.MyRunUO.MyRunUO.QueueMobileUpdate( this );
			}
		}

		public override void OnGenderChanged( bool oldFemale )
		{
			InvalidateMyRunUO();
		}

		public override void OnGuildChange( Server.Guilds.BaseGuild oldGuild )
		{
			InvalidateMyRunUO();
		}

		public override void OnGuildTitleChange( string oldTitle )
		{
			InvalidateMyRunUO();
		}


		public override void OnSkillChange( SkillName skill, double oldBase )
		{
            if (skill == SkillName.Langues)
                Langues.FixLangues();

			InvalidateMyRunUO();
		}

		public override void OnAccessLevelChanged( AccessLevel oldLevel )
		{
			if ( AccessLevel == AccessLevel.Player )
				IgnoreMobiles = false;
			else
				IgnoreMobiles = true;

			InvalidateMyRunUO();
		}

		public override void OnRawStatChange( StatType stat, int oldValue )
		{
			InvalidateMyRunUO();
		}

		public override void OnDelete()
		{
			InvalidateMyRunUO();
		}

		#endregion

		#region Fastwalk Prevention
		private static bool FastwalkPrevention = true; // Is fastwalk prevention enabled?
		private static int FastwalkThreshold = 400; // Fastwalk prevention will become active after 0.4 seconds

		private long m_NextMovementTime;
        private bool m_HasMoved;

		public virtual bool UsesFastwalkPrevention{ get{ return ( AccessLevel < AccessLevel.Counselor ); } }

		public override int ComputeMovementSpeed( Direction dir, bool checkTurning )
		{
			if ( checkTurning && (dir & Direction.Mask) != (this.Direction & Direction.Mask) )
				return Mobile.RunMount;	// We are NOT actually moving (just a direction change)

			//TransformContext context = TransformationSpellHelper.GetContext( this );

			//if ( context != null && context.Type == typeof( ReaperFormSpell ) )
			//	return Mobile.WalkFoot;

			bool running = ( (dir & Direction.Running) != 0 );

			bool onHorse = ( this.Mount != null );

			//AnimalFormContext animalContext = AnimalForm.GetContext( this );

			if( onHorse /*|| (animalContext != null && animalContext.SpeedBoost)*/ )
				return ( running ? Mobile.RunMount : Mobile.WalkMount );

			return ( running ? Mobile.RunFoot : Mobile.WalkFoot );
		}

		public static bool MovementThrottle_Callback( NetState ns )
		{
			PlayerMobile pm = ns.Mobile as PlayerMobile;

			if ( pm == null || !pm.UsesFastwalkPrevention )
				return true;

            if (!pm.m_HasMoved)
            {
                // has not yet moved				
                pm.m_NextMovementTime = Core.TickCount;
                pm.m_HasMoved = true;
                return true;
            }

            long ts = pm.m_NextMovementTime - Core.TickCount;

            if (ts < 0)
            {
                // been a while since we've last moved
                pm.m_NextMovementTime = Core.TickCount;
                return true;
            }

			return ( ts < FastwalkThreshold );
		}

		#endregion

		#region Hair and beard mods
		private int m_HairModID = -1, m_HairModHue;
		private int m_BeardModID = -1, m_BeardModHue;

		public void SetHairMods( int hairID, int beardID )
		{
			if ( hairID == -1 )
				InternalRestoreHair( true, ref m_HairModID, ref m_HairModHue );
			else if ( hairID != -2 )
				InternalChangeHair( true, hairID, ref m_HairModID, ref m_HairModHue );

			if ( beardID == -1 )
				InternalRestoreHair( false, ref m_BeardModID, ref m_BeardModHue );
			else if ( beardID != -2 )
				InternalChangeHair( false, beardID, ref m_BeardModID, ref m_BeardModHue );
		}

		private void CreateHair( bool hair, int id, int hue )
		{
			if( hair )
			{
				//TODO Verification?
				HairItemID = id;
				HairHue = hue;
			}
			else
			{
				FacialHairItemID = id;
				FacialHairHue = hue;
			}
		}

		private void InternalRestoreHair( bool hair, ref int id, ref int hue )
		{
			if ( id == -1 )
				return;

			if ( hair )
				HairItemID = 0;
			else
				FacialHairItemID = 0;

			//if( id != 0 )
			CreateHair( hair, id, hue );

			id = -1;
			hue = 0;
		}

		private void InternalChangeHair( bool hair, int id, ref int storeID, ref int storeHue )
		{
			if ( storeID == -1 )
			{
				storeID = hair ? HairItemID : FacialHairItemID;
				storeHue = hair ? HairHue : FacialHairHue;
			}
			CreateHair( hair, id, 0 );
		}

		#endregion

		#region Speech log
		private SpeechLog m_SpeechLog;

		public SpeechLog SpeechLog{ get{ return m_SpeechLog; } }

		public override void OnSpeech( SpeechEventArgs e )
		{
			if ( SpeechLog.Enabled && this.NetState != null )
			{
				if ( m_SpeechLog == null )
					m_SpeechLog = new SpeechLog();

				m_SpeechLog.Add(this, e.Mobile, e.Speech );
			}
		}

		#endregion

		#region Recipes

		private Dictionary<int, bool> m_AcquiredRecipes;

		public virtual bool HasRecipe( Recipe r )
		{
			if( r == null )
				return false;

			return HasRecipe( r.ID );
		}

		public virtual bool HasRecipe( int recipeID )
		{
			if( m_AcquiredRecipes != null && m_AcquiredRecipes.ContainsKey( recipeID ) )
				return m_AcquiredRecipes[recipeID];

			return false;
		}

		public virtual void AcquireRecipe( Recipe r )
		{
			if( r != null )
				AcquireRecipe( r.ID );
		}

		public virtual void AcquireRecipe( int recipeID )
		{
			if( m_AcquiredRecipes == null )
				m_AcquiredRecipes = new Dictionary<int, bool>();

			m_AcquiredRecipes[recipeID] = true;
		}

		public virtual void ResetRecipes()
		{
			m_AcquiredRecipes = null;
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int KnownRecipes
		{
			get
			{
				if( m_AcquiredRecipes == null )
					return 0;

				return m_AcquiredRecipes.Count;
			}
		}

		#endregion

		#region Buff Icons

		public void ResendBuffs()
		{
			if( !BuffInfo.Enabled || m_BuffTable == null )
				return;

			NetState state = this.NetState;

			if( state != null && state.BuffIcon )
			{
				foreach( BuffInfo info in m_BuffTable.Values )
				{
					state.Send( new AddBuffPacket( this, info ) );
				}
			}
		}

		private Dictionary<BuffIcon, BuffInfo> m_BuffTable;

		public void AddBuff( BuffInfo b )
		{
			if( !BuffInfo.Enabled || b == null )
				return;

			RemoveBuff( b );	//Check & subsequently remove the old one.

			if( m_BuffTable == null )
				m_BuffTable = new Dictionary<BuffIcon, BuffInfo>();

			m_BuffTable.Add( b.ID, b );

			NetState state = this.NetState;

			if( state != null && state.BuffIcon )
			{
				state.Send( new AddBuffPacket( this, b ) );
			}
		}

		public void RemoveBuff( BuffInfo b )
		{
			if( b == null )
				return;

			RemoveBuff( b.ID );
		}

		public void RemoveBuff( BuffIcon b )
		{
			if( m_BuffTable == null || !m_BuffTable.ContainsKey( b ) )
				return;

			BuffInfo info = m_BuffTable[b];

			if( info.Timer != null && info.Timer.Running )
				info.Timer.Stop();

			m_BuffTable.Remove( b );

			NetState state = this.NetState;

			if( state != null && state.BuffIcon )
			{
				state.Send( new RemoveBuffPacket( this, b ) );
			}

			if( m_BuffTable.Count <= 0 )
				m_BuffTable = null;
		}

		#endregion

		public void AutoStablePets()
		{
			if ( Core.SE && AllFollowers.Count > 0 )
			{
				for ( int i = m_AllFollowers.Count - 1; i >= 0; --i )
				{
					BaseCreature pet = AllFollowers[i] as BaseCreature;

					if (pet == null || pet.ControlMaster == null)
						continue;

					if (pet.Summoned)
					{
						if (pet.Map != Map)
						{
							pet.PlaySound( pet.GetAngerSound() );
							Timer.DelayCall( TimeSpan.Zero, new TimerCallback( pet.Delete ) );
						}
						continue;
					}

					if ( pet is IMount && ((IMount)pet).Rider != null )
						continue;

					if ( (pet is PackHorse || pet is Scarabee) && (pet.Backpack != null && pet.Backpack.Items.Count > 0) )
						continue;

					pet.ControlTarget = null;
					pet.ControlOrder = OrderType.Stay;
					pet.Internalize();

					pet.SetControlMaster( null );
					pet.SummonMaster = null;

					pet.IsStabled = true;

					pet.Loyalty = BaseCreature.MaxLoyalty; // Wonderfully happy

					Stabled.Add( pet );
					m_AutoStabled.Add( pet );
				}
			}
		}

		public void ClaimAutoStabledPets()
		{
			if ( !Core.SE || m_AutoStabled.Count <= 0 )
				return;

			if ( !Alive )
			{
				SendLocalizedMessage( 1076251 ); // Your pet was unable to join you while you are a ghost.  Please re-login once you have ressurected to claim your pets.
				return;
			}

			for ( int i = m_AutoStabled.Count - 1; i >= 0; --i )
			{
				BaseCreature pet = m_AutoStabled[i] as BaseCreature;

				if ( pet == null || pet.Deleted )
				{
					pet.IsStabled = false;

					if ( Stabled.Contains( pet ) )
						Stabled.Remove( pet );

					continue;
				}

				if ( (Followers + pet.ControlSlots) <= FollowersMax )
				{
					pet.SetControlMaster( this );

					if ( pet.Summoned )
						pet.SummonMaster = this;

					pet.ControlTarget = this;
					pet.ControlOrder = OrderType.Follow;

					pet.MoveToWorld( Location, Map );

					pet.IsStabled = false;

					pet.Loyalty = BaseCreature.MaxLoyalty; // Wonderfully Happy

					if ( Stabled.Contains( pet ) )
						Stabled.Remove( pet );
				}
				else
				{
					SendLocalizedMessage( 1049612, pet.Name ); // ~1_NAME~ remained in the stables because you have too many followers.
				}
			}

			m_AutoStabled.Clear();
		}
	}
}