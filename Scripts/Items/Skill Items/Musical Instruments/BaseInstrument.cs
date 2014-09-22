using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using Server.Engines.Craft;
using Server.ContextMenus;
using System.Collections.Generic;
using Server.Gumps;

namespace Server.Items
{
	public delegate void InstrumentPickedCallback( Mobile from, BaseInstrument instrument );

	public enum InstrumentQuality
	{
		Low,
		Regular,
		Exceptional
	}

	public abstract class BaseInstrument : Item, ICraftable
	{
		private int m_WellSound, m_BadlySound;
		private InstrumentQuality m_Quality;
		private Mobile m_Crafter;
		private int m_UsesRemaining;

		[CommandProperty( AccessLevel.Batisseur )]
		public int SuccessSound
		{
			get{ return m_WellSound; }
			set{ m_WellSound = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public int FailureSound
		{
			get{ return m_BadlySound; }
			set{ m_BadlySound = value; }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public InstrumentQuality Quality
		{
			get{ return m_Quality; }
			set{ UnscaleUses(); m_Quality = value; InvalidateProperties(); ScaleUses(); }
		}

		[CommandProperty( AccessLevel.Batisseur )]
		public Mobile Crafter
		{
			get{ return m_Crafter; }
			set{ m_Crafter = value; InvalidateProperties(); }
		}

		public virtual int InitMinUses{ get{ return 350; } }
		public virtual int InitMaxUses{ get{ return 450; } }

		public virtual TimeSpan ChargeReplenishRate { get { return TimeSpan.FromMinutes( 5.0 ); } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int UsesRemaining
		{
			get{ CheckReplenishUses(); return m_UsesRemaining; }
			set{ m_UsesRemaining = value; InvalidateProperties(); }
		}

		private DateTime m_LastReplenished;

		[CommandProperty( AccessLevel.Batisseur )]
		public DateTime LastReplenished
		{
			get { return m_LastReplenished; }
			set { m_LastReplenished = value; CheckReplenishUses(); }
		}

		private bool m_ReplenishesCharges;
		[CommandProperty( AccessLevel.Batisseur )]
		public bool ReplenishesCharges
		{
			get { return m_ReplenishesCharges; }
			set 
			{
				if( value != m_ReplenishesCharges && value )
					m_LastReplenished = DateTime.Now;

				m_ReplenishesCharges = value; 
			}
		}

		public void CheckReplenishUses()
		{
			CheckReplenishUses( true );
		}

		public void CheckReplenishUses( bool invalidate )
		{
			if( !m_ReplenishesCharges || m_UsesRemaining >= InitMaxUses )
				return;

			if( m_LastReplenished + ChargeReplenishRate < DateTime.Now )
			{
				TimeSpan timeDifference = DateTime.Now - m_LastReplenished;

				m_UsesRemaining = Math.Min( m_UsesRemaining + (int)( timeDifference.Ticks / ChargeReplenishRate.Ticks), InitMaxUses );	//How rude of TimeSpan to not allow timespan division.
				m_LastReplenished = DateTime.Now;

				if( invalidate )
					InvalidateProperties();

			}
		}

		public void ScaleUses()
		{
			UsesRemaining = (UsesRemaining * GetUsesScalar()) / 100;
			//InvalidateProperties();
		}

		public void UnscaleUses()
		{
			UsesRemaining = (UsesRemaining * 100) / GetUsesScalar();
		}

		public int GetUsesScalar()
		{
			if ( m_Quality == InstrumentQuality.Exceptional )
				return 200;

			return 100;
		}

        private class LivreEntry : ContextMenuEntry
        {
            private Mobile m_from;
            private BaseInstrument m_instrument;

            public LivreEntry(Mobile from, BaseInstrument instrument)
                : base(6269, -1)
            {
                m_from = from;
                m_instrument = instrument;
            }
        }

        private class QSLEntry : ContextMenuEntry
        {
            private TMobile m_from;
            private BaseInstrument m_instrument;

            public QSLEntry(TMobile from, BaseInstrument instrument)
                : base(6268, -1)
            {
                m_from = from;
                m_instrument = instrument;
            }

            public override void OnClick()
            {
                m_from.CloseGump(typeof(QuickSpellLaunchGump));
                m_from.SendGump(new QuickSpellLaunchGump(m_from, m_instrument, null));
            }
        }

        public override void GetContextMenuEntries(Mobile m_from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(m_from, list);

            Container pack = m_from.Backpack;

            if (Parent == m_from || (pack != null && Parent == pack))
            {
                list.Add(new LivreEntry(m_from, this));
                if (m_from is TMobile)
                    list.Add(new QSLEntry(((TMobile)m_from), this));
            }
        }

		public void ConsumeUse( Mobile from )
		{
			// TODO: Confirm what must happen here?

			if ( UsesRemaining > 1 )
			{
				--UsesRemaining;
			}
			else
			{
				if ( from != null )
					from.SendLocalizedMessage( 502079 ); // The instrument played its last tune.

				Delete();
			}
		}

		private static Hashtable m_Instruments = new Hashtable();

		public static BaseInstrument GetInstrument( Mobile from )
		{
			BaseInstrument item = m_Instruments[from] as BaseInstrument;

			if ( item == null )
				return null;

			if ( !item.IsChildOf( from.Backpack ) )
			{
				m_Instruments.Remove( from );
				return null;
			}

			return item;
		}

		public static int GetBardRange( Mobile bard, SkillName skill )
		{
			return 8 + (int)(bard.Skills[skill].Value / 15);
		}

		public static void PickInstrument( Mobile from, InstrumentPickedCallback callback )
		{
			BaseInstrument instrument = GetInstrument( from );

			if ( instrument != null )
			{
				if ( callback != null )
					callback( from, instrument );
			}
			else
			{
				from.SendLocalizedMessage( 500617 ); // What instrument shall you play?
				from.BeginTarget( 1, false, TargetFlags.None, new TargetStateCallback( OnPickedInstrument ), callback );
			}
		}

		public static void OnPickedInstrument( Mobile from, object targeted, object state )
		{
			BaseInstrument instrument = targeted as BaseInstrument;

			if ( instrument == null )
			{
				from.SendLocalizedMessage( 500619 ); // That is not a musical instrument.
			}
			else
			{
				SetInstrument( from, instrument );

				InstrumentPickedCallback callback = state as InstrumentPickedCallback;

				if ( callback != null )
					callback( from, instrument );
			}
		}

		public static bool IsMageryCreature( BaseCreature bc )
		{
			return ( bc != null && bc.AI == AIType.AI_Mage && bc.Skills[SkillName.ArtMagique].Base > 5.0 );
		}

		public static bool IsFireBreathingCreature( BaseCreature bc )
		{
			if ( bc == null )
				return false;

			return bc.HasBreath;
		}

		public static bool IsPoisonImmune( BaseCreature bc )
		{
			return ( bc != null && bc.PoisonImmune != null );
		}

		public static int GetPoisonLevel( BaseCreature bc )
		{
			if ( bc == null )
				return 0;

			Poison p = bc.HitPoison;

			if ( p == null )
				return 0;

			return p.Level + 1;
		}

		public static double GetBaseDifficulty( Mobile targ )
		{
			/* Difficulty TODO: Add another 100 points for each of the following abilities:
				- Radiation or Aura Damage (Heat, Cold etc.)
				- Summoning Undead
			*/

			double val = (targ.HitsMax * 1.6) + targ.StamMax + targ.ManaMax;

			val += targ.SkillsTotal / 10;

			if ( val > 700 )
				val = 700 + (int)((val - 700) * (3.0 / 11));

			BaseCreature bc = targ as BaseCreature;

			if ( IsMageryCreature( bc ) )
				val += 100;

			if ( IsFireBreathingCreature( bc ) )
				val += 100;

			if ( IsPoisonImmune( bc ) )
				val += 100;

			if ( targ is VampireBat || targ is VampireBatFamiliar )
				val += 100;

			val += GetPoisonLevel( bc ) * 20;

			val /= 10;


			if ( Core.SE && val > 160.0 )
				val = 160.0;

			return val;
		}

		public double GetDifficultyFor( Mobile targ )
		{
			double val = GetBaseDifficulty( targ );

			if ( m_Quality == InstrumentQuality.Exceptional )
				val -= 5.0; // 10%

			return val;
		}

		public static void SetInstrument( Mobile from, BaseInstrument item )
		{
			m_Instruments[from] = item;
		}

		public BaseInstrument( int itemID, int wellSound, int badlySound ) : base( itemID )
		{
			m_WellSound = wellSound;
			m_BadlySound = badlySound;
			UsesRemaining = Utility.RandomMinMax( InitMinUses, InitMaxUses );
            Layer = Layer.TwoHanded;
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			int oldUses = m_UsesRemaining;
			CheckReplenishUses( false );

			base.GetProperties( list );

			if ( m_Crafter != null )
				list.Add( 1050043, m_Crafter.Name ); // crafted by ~1_NAME~

			if ( m_Quality == InstrumentQuality.Exceptional )
				list.Add( 1060636 ); // exceptional

			list.Add( 1060584, m_UsesRemaining.ToString() ); // uses remaining: ~1_val~

			if( m_ReplenishesCharges )
				list.Add( 1070928 ); // Replenish Charges

			if( m_UsesRemaining != oldUses )
				Timer.DelayCall( TimeSpan.Zero, new TimerCallback( InvalidateProperties ) );
		}

		public override void OnSingleClick( Mobile from )
		{
			ArrayList attrs = new ArrayList();

			if ( DisplayLootType )
			{
				if ( LootType == LootType.Blessed )
					attrs.Add( new EquipInfoAttribute( 1038021 ) ); // blessed
				else if ( LootType == LootType.Cursed )
					attrs.Add( new EquipInfoAttribute( 1049643 ) ); // cursed
			}

			if ( m_Quality == InstrumentQuality.Exceptional )
				attrs.Add( new EquipInfoAttribute( 1018305 - (int)m_Quality ) );

			if( m_ReplenishesCharges )
				attrs.Add( new EquipInfoAttribute( 1070928 ) ); // Replenish Charges

			int number;

			if ( Name == null )
			{
				number = LabelNumber;
			}
			else
			{
				this.LabelTo( from, Name );
				number = 1041000;
			}

			if ( attrs.Count == 0 && Crafter == null && Name != null )
				return;

			EquipmentInfo eqInfo = new EquipmentInfo( number, m_Crafter, false, (EquipInfoAttribute[])attrs.ToArray( typeof( EquipInfoAttribute ) ) );

			from.Send( new DisplayEquipmentInfo( this, eqInfo ) );
		}

		public BaseInstrument( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( m_ReplenishesCharges );
			if( m_ReplenishesCharges )
				writer.Write( m_LastReplenished );


			writer.Write( m_Crafter );

			writer.WriteEncodedInt( (int) m_Quality );
			writer.WriteEncodedInt( (int)UsesRemaining );

			writer.WriteEncodedInt( (int) m_WellSound );
			writer.WriteEncodedInt( (int) m_BadlySound );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            m_ReplenishesCharges = reader.ReadBool();

            if (m_ReplenishesCharges)
                m_LastReplenished = reader.ReadDateTime();


            m_Crafter = reader.ReadMobile();

            m_Quality = (InstrumentQuality)reader.ReadEncodedInt();


            UsesRemaining = reader.ReadEncodedInt();

            m_WellSound = reader.ReadEncodedInt();
            m_BadlySound = reader.ReadEncodedInt();
					


			CheckReplenishUses();
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
			{
				from.SendLocalizedMessage( 500446 ); // That is too far away.
			}
			else if ( from.BeginAction( typeof( BaseInstrument ) ) )
			{
				SetInstrument( from, this );

				// Delay of 7 second before beign able to play another instrument again
				new InternalTimer( from ).Start();

				if ( CheckMusicianship( from ) )
					PlayInstrumentWell( from );
				else
					PlayInstrumentBadly( from );
			}
			else
			{
				from.SendLocalizedMessage( 500119 ); // You must wait to perform another action
			}
		}

		public static bool CheckMusicianship( Mobile m )
		{
			m.CheckSkill( SkillName.Musique, 0.0, 120.0 );

			return ( (m.Skills[SkillName.Musique].Value / 100) > Utility.RandomDouble() );
		}

		public void PlayInstrumentWell( Mobile from )
		{
			from.PlaySound( m_WellSound );
		}

		public void PlayInstrumentBadly( Mobile from )
		{
			from.PlaySound( m_BadlySound );
		}

		private class InternalTimer : Timer
		{
			private Mobile m_From;

			public InternalTimer( Mobile from ) : base( TimeSpan.FromSeconds( 6.0 ) )
			{
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				m_From.EndAction( typeof( BaseInstrument ) );
			}
		}
		#region ICraftable Members

		public int OnCraft( int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue )
		{
			Quality = (InstrumentQuality)quality;

			if ( makersMark )
				Crafter = from;

			return quality;
		}

		#endregion
	}
}