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
    }
}
