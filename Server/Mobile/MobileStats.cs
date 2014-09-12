using Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    public partial class Mobile
    {
        #region Regeneration

		private static RegenRateHandler m_HitsRegenRate, m_StamRegenRate, m_ManaRegenRate;
		private static TimeSpan m_DefaultHitsRate, m_DefaultStamRate, m_DefaultManaRate;

		public static RegenRateHandler HitsRegenRateHandler
		{
			get { return m_HitsRegenRate; }
			set { m_HitsRegenRate = value; }
		}

		public static TimeSpan DefaultHitsRate
		{
			get { return m_DefaultHitsRate; }
			set { m_DefaultHitsRate = value; }
		}

		public static RegenRateHandler StamRegenRateHandler
		{
			get { return m_StamRegenRate; }
			set { m_StamRegenRate = value; }
		}

		public static TimeSpan DefaultStamRate
		{
			get { return m_DefaultStamRate; }
			set { m_DefaultStamRate = value; }
		}

		public static RegenRateHandler ManaRegenRateHandler
		{
			get { return m_ManaRegenRate; }
			set { m_ManaRegenRate = value; }
		}

		public static TimeSpan DefaultManaRate
		{
			get { return m_DefaultManaRate; }
			set { m_DefaultManaRate = value; }
		}

		public static TimeSpan GetHitsRegenRate( Mobile m )
		{
			if( m_HitsRegenRate == null )
				return m_DefaultHitsRate;
			else
				return m_HitsRegenRate( m );
		}

		public static TimeSpan GetStamRegenRate( Mobile m )
		{
			if( m_StamRegenRate == null )
				return m_DefaultStamRate;
			else
				return m_StamRegenRate( m );
		}

		public static TimeSpan GetManaRegenRate( Mobile m )
		{
			if( m_ManaRegenRate == null )
				return m_DefaultManaRate;
			else
				return m_ManaRegenRate( m );
		}

		#endregion
        private int m_StatCap;
        private int m_Str, m_Dex, m_Int;
		private int m_Hits, m_Stam, m_Mana;
		private List<StatMod> m_StatMods;

		private StatLockType m_StrLock, m_DexLock, m_IntLock;


		/// <summary>
		/// Gets or sets the <see cref="StatLockType">lock state</see> for the <see cref="RawStr" /> property.
		/// </summary>
		[CommandProperty( AccessLevel.Counselor, AccessLevel.Batisseur )]
		public StatLockType StrLock
		{
			get
			{
				return m_StrLock;
			}
			set
			{
				if( m_StrLock != value )
				{
					m_StrLock = value;

					if( m_NetState != null )
						m_NetState.Send( new StatLockInfo( this ) );
				}
			}
		}

		/// <summary>
		/// Gets or sets the <see cref="StatLockType">lock state</see> for the <see cref="RawDex" /> property.
		/// </summary>
		[CommandProperty( AccessLevel.Counselor, AccessLevel.Batisseur )]
		public StatLockType DexLock
		{
			get
			{
				return m_DexLock;
			}
			set
			{
				if( m_DexLock != value )
				{
					m_DexLock = value;

					if( m_NetState != null )
						m_NetState.Send( new StatLockInfo( this ) );
				}
			}
		}

		/// <summary>
		/// Gets or sets the <see cref="StatLockType">lock state</see> for the <see cref="RawInt" /> property.
		/// </summary>
		[CommandProperty( AccessLevel.Counselor, AccessLevel.Batisseur )]
		public StatLockType IntLock
		{
			get
			{
				return m_IntLock;
			}
			set
			{
				if( m_IntLock != value )
				{
					m_IntLock = value;

					if( m_NetState != null )
						m_NetState.Send( new StatLockInfo( this ) );
				}
			}
		}
        
		private static bool m_GlobalRegenThroughPoison = true;

		public static bool GlobalRegenThroughPoison
		{
			get { return m_GlobalRegenThroughPoison; }
			set { m_GlobalRegenThroughPoison = value; }
		}

		public virtual bool RegenThroughPoison { get { return m_GlobalRegenThroughPoison; } }

		public virtual bool CanRegenHits { get { return this.Alive && (RegenThroughPoison || !this.Poisoned); } }
		public virtual bool CanRegenStam { get { return this.Alive; } }
		public virtual bool CanRegenMana { get { return this.Alive; } }

		private class ManaTimer : Timer
		{
			private Mobile m_Owner;

			public ManaTimer( Mobile m )
				: base( Mobile.GetManaRegenRate( m ), Mobile.GetManaRegenRate( m ) )
			{
				this.Priority = TimerPriority.FiftyMS;
				m_Owner = m;
			}

			protected override void OnTick()
			{
				if( m_Owner.CanRegenMana )// m_Owner.Alive )
					m_Owner.Mana++;

				Delay = Interval = Mobile.GetManaRegenRate( m_Owner );
			}
		}

		private class HitsTimer : Timer
		{
			private Mobile m_Owner;

			public HitsTimer( Mobile m )
				: base( Mobile.GetHitsRegenRate( m ), Mobile.GetHitsRegenRate( m ) )
			{
				this.Priority = TimerPriority.FiftyMS;
				m_Owner = m;
			}

			protected override void OnTick()
			{
				if( m_Owner.CanRegenHits )// m_Owner.Alive && !m_Owner.Poisoned )
					m_Owner.Hits++;

				Delay = Interval = Mobile.GetHitsRegenRate( m_Owner );
			}
		}

		private class StamTimer : Timer
		{
			private Mobile m_Owner;

			public StamTimer( Mobile m )
				: base( Mobile.GetStamRegenRate( m ), Mobile.GetStamRegenRate( m ) )
			{
				this.Priority = TimerPriority.FiftyMS;
				m_Owner = m;
			}

			protected override void OnTick()
			{
				if( m_Owner.CanRegenStam )// m_Owner.Alive )
					m_Owner.Stam++;

				Delay = Interval = Mobile.GetStamRegenRate( m_Owner );
			}
		}


		public virtual bool ShouldCheckStatTimers { get { return true; } }

		public virtual void CheckStatTimers()
		{
			if( m_Deleted )
				return;

			if( Hits < HitsMax )
			{
				if( CanRegenHits )
				{
					if( m_HitsTimer == null )
						m_HitsTimer = new HitsTimer( this );

					m_HitsTimer.Start();
				}
				else if( m_HitsTimer != null )
				{
					m_HitsTimer.Stop();
				}
			}
			else
			{
				Hits = HitsMax;
			}

			if( Stam < StamMax )
			{
				if( CanRegenStam )
				{
					if( m_StamTimer == null )
						m_StamTimer = new StamTimer( this );

					m_StamTimer.Start();
				}
				else if( m_StamTimer != null )
				{
					m_StamTimer.Stop();
				}
			}
			else
			{
				Stam = StamMax;
			}

			if( Mana < ManaMax )
			{
				if( CanRegenMana )
				{
					if( m_ManaTimer == null )
						m_ManaTimer = new ManaTimer( this );

					m_ManaTimer.Start();
				}
				else if( m_ManaTimer != null )
				{
					m_ManaTimer.Stop();
				}
			}
			else
			{
				Mana = ManaMax;
			}
		}


		public void Heal( int amount )
		{
			Heal( amount, this, true );
		}

		public void Heal( int amount, Mobile from )
		{
			Heal( amount, from, true );
		}

		public void Heal( int amount, Mobile from, bool message )
		{
			if( !Alive || IsDeadBondedPet )
				return;

			if( !Region.OnHeal( this, ref amount ) )
				return;

			OnHeal( ref amount, from );

			if( (Hits + amount) > HitsMax )
			{
				amount = HitsMax - Hits;
			}

			Hits += amount;

			if( message && amount > 0 && m_NetState != null )
				m_NetState.Send( new MessageLocalizedAffix( Serial.MinusOne, -1, MessageType.Label, 0x3B2, 3, 1008158, "", AffixType.Append | AffixType.System, amount.ToString(), "" ) );
		}

		public virtual void OnHeal( ref int amount, Mobile from )
		{
		}


		#region Stats

		/// <summary>
		/// Gets a list of all <see cref="StatMod">StatMod's</see> currently active for the Mobile.
		/// </summary>
		public List<StatMod> StatMods { get { return m_StatMods; } }

		public bool RemoveStatMod( string name )
		{
			for( int i = 0; i < m_StatMods.Count; ++i )
			{
				StatMod check = m_StatMods[i];

				if( check.Name == name )
				{
					m_StatMods.RemoveAt( i );
					CheckStatTimers();
					Delta( MobileDelta.Stat | GetStatDelta( check.Type ) );
					return true;
				}
			}

			return false;
		}

		public StatMod GetStatMod( string name )
		{
			for( int i = 0; i < m_StatMods.Count; ++i )
			{
				StatMod check = m_StatMods[i];

				if( check.Name == name )
					return check;
			}

			return null;
		}

		public void AddStatMod( StatMod mod )
		{
			for( int i = 0; i < m_StatMods.Count; ++i )
			{
				StatMod check = m_StatMods[i];

				if( check.Name == mod.Name )
				{
					Delta( MobileDelta.Stat | GetStatDelta( check.Type ) );
					m_StatMods.RemoveAt( i );
					break;
				}
			}

			m_StatMods.Add( mod );
			Delta( MobileDelta.Stat | GetStatDelta( mod.Type ) );
			CheckStatTimers();
		}

		private MobileDelta GetStatDelta( StatType type )
		{
			MobileDelta delta = 0;

			if( (type & StatType.Str) != 0 )
				delta |= MobileDelta.Hits;

			if( (type & StatType.Dex) != 0 )
				delta |= MobileDelta.Stam;

			if( (type & StatType.Int) != 0 )
				delta |= MobileDelta.Mana;

			return delta;
		}

		/// <summary>
		/// Computes the total modified offset for the specified stat type. Expired <see cref="StatMod" /> instances are removed.
		/// </summary>
		public int GetStatOffset( StatType type )
		{
			int offset = 0;

			for( int i = 0; i < m_StatMods.Count; ++i )
			{
				StatMod mod = m_StatMods[i];

				if( mod.HasElapsed() )
				{
					m_StatMods.RemoveAt( i );
					Delta( MobileDelta.Stat | GetStatDelta( mod.Type ) );
					CheckStatTimers();

					--i;
				}
				else if( (mod.Type & type) != 0 )
				{
					offset += mod.Offset;
				}
			}

			return offset;
		}

		/// <summary>
		/// Overridable. Virtual event invoked when the <see cref="RawStr" /> changes.
		/// <seealso cref="RawStr" />
		/// <seealso cref="OnRawStatChange" />
		/// </summary>
		public virtual void OnRawStrChange( int oldValue )
		{
		}

		/// <summary>
		/// Overridable. Virtual event invoked when <see cref="RawDex" /> changes.
		/// <seealso cref="RawDex" />
		/// <seealso cref="OnRawStatChange" />
		/// </summary>
		public virtual void OnRawDexChange( int oldValue )
		{
		}

		/// <summary>
		/// Overridable. Virtual event invoked when the <see cref="RawInt" /> changes.
		/// <seealso cref="RawInt" />
		/// <seealso cref="OnRawStatChange" />
		/// </summary>
		public virtual void OnRawIntChange( int oldValue )
		{
		}

		/// <summary>
		/// Overridable. Virtual event invoked when the <see cref="RawStr" />, <see cref="RawDex" />, or <see cref="RawInt" /> changes.
		/// <seealso cref="OnRawStrChange" />
		/// <seealso cref="OnRawDexChange" />
		/// <seealso cref="OnRawIntChange" />
		/// </summary>
		public virtual void OnRawStatChange( StatType stat, int oldValue )
		{
		}

		/// <summary>
		/// Gets or sets the base, unmodified, strength of the Mobile. Ranges from 1 to 65000, inclusive.
		/// <seealso cref="Str" />
		/// <seealso cref="StatMod" />
		/// <seealso cref="OnRawStrChange" />
		/// <seealso cref="OnRawStatChange" />
		/// </summary>
		[CommandProperty( AccessLevel.Batisseur )]
		public int RawStr
		{
			get
			{
				return m_Str;
			}
			set
			{
				if( value < 1 )
					value = 1;
				else if( value > 65000 )
					value = 65000;

				if( m_Str != value )
				{
					int oldValue = m_Str;

					m_Str = value;
					Delta( MobileDelta.Stat | MobileDelta.Hits );

					if( Hits < HitsMax )
					{
						if( m_HitsTimer == null )
							m_HitsTimer = new HitsTimer( this );

						m_HitsTimer.Start();
					}
					else if( Hits > HitsMax )
					{
						Hits = HitsMax;
					}

					OnRawStrChange( oldValue );
					OnRawStatChange( StatType.Str, oldValue );
				}
			}
		}

		/// <summary>
		/// Gets or sets the effective strength of the Mobile. This is the sum of the <see cref="RawStr" /> plus any additional modifiers. Any attempts to set this value when under the influence of a <see cref="StatMod" /> will result in no change. It ranges from 1 to 65000, inclusive.
		/// <seealso cref="RawStr" />
		/// <seealso cref="StatMod" />
		/// </summary>
		[CommandProperty( AccessLevel.Batisseur )]
		public virtual int Str
		{
			get
			{
				int value = m_Str + GetStatOffset( StatType.Str );

				if( value < 1 )
					value = 1;
				else if( value > 65000 )
					value = 65000;

				return value;
			}
			set
			{
				if( m_StatMods.Count == 0 )
					RawStr = value;
			}
		}

        //Temrael

		/// <summary>
		/// Gets or sets the base, unmodified, dexterity of the Mobile. Ranges from 1 to 65000, inclusive.
		/// <seealso cref="Dex" />
		/// <seealso cref="StatMod" />
		/// <seealso cref="OnRawDexChange" />
		/// <seealso cref="OnRawStatChange" />
		/// </summary>
		[CommandProperty( AccessLevel.Batisseur )]
		public int RawDex
		{
			get
			{
				return m_Dex;
			}
			set
			{
				if( value < 1 )
					value = 1;
				else if( value > 65000 )
					value = 65000;

				if( m_Dex != value )
				{
					int oldValue = m_Dex;

					m_Dex = value;
					Delta( MobileDelta.Stat | MobileDelta.Stam );

					if( Stam < StamMax )
					{
						if( m_StamTimer == null )
							m_StamTimer = new StamTimer( this );

						m_StamTimer.Start();
					}
					else if( Stam > StamMax )
					{
						Stam = StamMax;
					}

					OnRawDexChange( oldValue );
					OnRawStatChange( StatType.Dex, oldValue );
				}
			}
		}

		/// <summary>
		/// Gets or sets the effective dexterity of the Mobile. This is the sum of the <see cref="RawDex" /> plus any additional modifiers. Any attempts to set this value when under the influence of a <see cref="StatMod" /> will result in no change. It ranges from 1 to 65000, inclusive.
		/// <seealso cref="RawDex" />
		/// <seealso cref="StatMod" />
		/// </summary>
		[CommandProperty( AccessLevel.Batisseur )]
		public virtual int Dex
		{
			get
			{
				int value = m_Dex + GetStatOffset( StatType.Dex );

				if( value < 1 )
					value = 1;
				else if( value > 65000 )
					value = 65000;

				return value;
			}
			set
			{
				if( m_StatMods.Count == 0 )
					RawDex = value;
			}
		}

		/// <summary>
		/// Gets or sets the base, unmodified, intelligence of the Mobile. Ranges from 1 to 65000, inclusive.
		/// <seealso cref="Int" />
		/// <seealso cref="StatMod" />
		/// <seealso cref="OnRawIntChange" />
		/// <seealso cref="OnRawStatChange" />
		/// </summary>
		[CommandProperty( AccessLevel.Batisseur )]
		public int RawInt
		{
			get
			{
				return m_Int;
			}
			set
			{
				if( value < 1 )
					value = 1;
				else if( value > 65000 )
					value = 65000;

				if( m_Int != value )
				{
					int oldValue = m_Int;

					m_Int = value;
					Delta( MobileDelta.Stat | MobileDelta.Mana );

					if( Mana < ManaMax )
					{
						if( m_ManaTimer == null )
							m_ManaTimer = new ManaTimer( this );

						m_ManaTimer.Start();
					}
					else if( Mana > ManaMax )
					{
						Mana = ManaMax;
					}

					OnRawIntChange( oldValue );
					OnRawStatChange( StatType.Int, oldValue );
				}
			}
		}

		/// <summary>
		/// Gets or sets the effective intelligence of the Mobile. This is the sum of the <see cref="RawInt" /> plus any additional modifiers. Any attempts to set this value when under the influence of a <see cref="StatMod" /> will result in no change. It ranges from 1 to 65000, inclusive.
		/// <seealso cref="RawInt" />
		/// <seealso cref="StatMod" />
		/// </summary>
		[CommandProperty( AccessLevel.Batisseur )]
		public virtual int Int
		{
			get
			{
				int value = m_Int + GetStatOffset( StatType.Int );

				if( value < 1 )
					value = 1;
				else if( value > 65000 )
					value = 65000;

				return value;
			}
			set
			{
				if( m_StatMods.Count == 0 )
					RawInt = value;
			}
		}

		public virtual void OnHitsChange( int oldValue )
		{
		}

		public virtual void OnStamChange( int oldValue )
		{
		}

		public virtual void OnManaChange( int oldValue )
		{
		}

		/// <summary>
		/// Gets or sets the current hit point of the Mobile. This value ranges from 0 to <see cref="HitsMax" />, inclusive. When set to the value of <see cref="HitsMax" />, the <see cref="AggressorInfo.CanReportMurder">CanReportMurder</see> flag of all aggressors is reset to false, and the list of damage entries is cleared.
		/// </summary>
		[CommandProperty( AccessLevel.Batisseur )]
		public int Hits
		{
			get
			{
				return m_Hits;
			}
			set
			{
				if( m_Deleted )
					return;

				if( value < 0 )
				{
					value = 0;
				}
				else if( value >= HitsMax )
				{
					value = HitsMax;

					if( m_HitsTimer != null )
						m_HitsTimer.Stop();

					for( int i = 0; i < m_Aggressors.Count; i++ ) //reset reports on full HP
						m_Aggressors[i].CanReportMurder = false;

					if( m_DamageEntries.Count > 0 )
						m_DamageEntries.Clear(); // reset damage entries on full HP
				}

				if( value < HitsMax )
				{
					if( CanRegenHits )
					{
						if( m_HitsTimer == null )
							m_HitsTimer = new HitsTimer( this );

						m_HitsTimer.Start();
					}
					else if( m_HitsTimer != null )
					{
						m_HitsTimer.Stop();
					}
				}

				if( m_Hits != value )
				{
					int oldValue = m_Hits;
					m_Hits = value;
					Delta( MobileDelta.Hits );
					OnHitsChange( oldValue );
				}
			}
		}

		/// <summary>
		/// Overridable. Gets the maximum hit point of the Mobile. By default, this returns: <c>50 + (<see cref="Str" /> / 2)</c>
		/// </summary>
		[CommandProperty( AccessLevel.Batisseur )]
		public virtual int HitsMax
		{
			get
			{
				return 50 + (Str / 2);
			}
		}

		/// <summary>
		/// Gets or sets the current stamina of the Mobile. This value ranges from 0 to <see cref="StamMax" />, inclusive.
		/// </summary>
		[CommandProperty( AccessLevel.Batisseur )]
		public int Stam
		{
			get
			{
				return m_Stam;
			}
			set
			{
				if( m_Deleted )
					return;

				if( value < 0 )
				{
					value = 0;
				}
				else if( value >= StamMax )
				{
					value = StamMax;

					if( m_StamTimer != null )
						m_StamTimer.Stop();
				}

				if( value < StamMax )
				{
					if( CanRegenStam )
					{
						if( m_StamTimer == null )
							m_StamTimer = new StamTimer( this );

						m_StamTimer.Start();
					}
					else if( m_StamTimer != null )
					{
						m_StamTimer.Stop();
					}
				}

				if( m_Stam != value )
				{
					int oldValue = m_Stam;
					m_Stam = value;
					Delta( MobileDelta.Stam );
					OnStamChange( oldValue );
				}
			}
		}

		/// <summary>
		/// Overridable. Gets the maximum stamina of the Mobile. By default, this returns: <c><see cref="Dex" /></c>
		/// </summary>
		[CommandProperty( AccessLevel.Batisseur )]
		public virtual int StamMax
		{
			get
			{
				return 2 * Dex;
			}
		}

		/// <summary>
		/// Gets or sets the current stamina of the Mobile. This value ranges from 0 to <see cref="ManaMax" />, inclusive.
		/// </summary>
		[CommandProperty( AccessLevel.Batisseur )]
		public int Mana
		{
			get
			{
				return m_Mana;
			}
			set
			{
				if( m_Deleted )
					return;

				if( value < 0 )
				{
					value = 0;
				}
				else if( value >= ManaMax )
				{
					value = ManaMax;

					if( m_ManaTimer != null )
						m_ManaTimer.Stop();

					if( Meditating )
					{
						Meditating = false;
						SendLocalizedMessage( 501846 ); // You are at peace.
					}
				}

				if( value < ManaMax )
				{
					if( CanRegenMana )
					{
						if( m_ManaTimer == null )
							m_ManaTimer = new ManaTimer( this );

						m_ManaTimer.Start();
					}
					else if( m_ManaTimer != null )
					{
						m_ManaTimer.Stop();
					}
				}

				if( m_Mana != value )
				{
					int oldValue = m_Mana;
					m_Mana = value;
					Delta( MobileDelta.Mana );
					OnManaChange( oldValue );
				}
			}
		}

		/// <summary>
		/// Overridable. Gets the maximum mana of the Mobile. By default, this returns: <c><see cref="Int" /></c>
		/// </summary>
		[CommandProperty( AccessLevel.Batisseur )]
		public virtual int ManaMax
		{
			get
			{
				return 2 * Int;
			}
		}

		#endregion
		

		[CommandProperty( AccessLevel.Batisseur )]
		public DateTime LastStrGain
		{
			get
			{
				return m_LastStrGain;
			}
			set
			{
				m_LastStrGain = value;
			}
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public DateTime LastIntGain
		{
			get
			{
				return m_LastIntGain;
			}
			set
			{
				m_LastIntGain = value;
			}
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public DateTime LastDexGain
		{
			get
			{
				return m_LastDexGain;
			}
			set
			{
				m_LastDexGain = value;
			}
		}

		public DateTime LastStatGain
		{
			get
			{
				DateTime d = m_LastStrGain;

				if( m_LastIntGain > d )
					d = m_LastIntGain;

				if( m_LastDexGain > d )
					d = m_LastDexGain;

				return d;
			}
			set
			{
				m_LastStrGain = value;
				m_LastIntGain = value;
				m_LastDexGain = value;
			}
		}
        
		public void InitStats( int str, int dex, int intel )
		{
			m_Str = str;
			m_Dex = dex;
			m_Int = intel;

			Hits = HitsMax;
			Stam = StamMax;
			Mana = ManaMax;

			Delta( MobileDelta.Stat | MobileDelta.Hits | MobileDelta.Stam | MobileDelta.Mana );
		}

		/// <summary>
		/// Gets or sets the maximum attainable value for <see cref="RawStr" />, <see cref="RawDex" />, and <see cref="RawInt" />.
		/// </summary>
        [CommandProperty(AccessLevel.Batisseur)]
        public int StatCap
        {
            get
            {
                return m_StatCap;
            }
            set
            {
                if (m_StatCap != value)
                {
                    m_StatCap = value;

                    Delta(MobileDelta.StatCap);
                }
            }
        }


		[CommandProperty( AccessLevel.Batisseur )]
		public int RawStatTotal
		{
			get
			{
				return RawStr + RawDex + RawInt;
			}
		}
    }
}
