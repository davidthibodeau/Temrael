using System;
using Server;

namespace Server.Items
{
	public enum MoonPhase
	{
		NewMoon,
		WaxingCrescentMoon,
		FirstQuarter,
		WaxingGibbous,
		FullMoon,
		WaningGibbous,
		LastQuarter,
		WaningCrescent
	}

	[Flipable( 0x104B, 0x104C )]
	public class Clock : Item
	{
		private static DateTime m_ServerStart;

		public static DateTime ServerStart
		{
			get{ return m_ServerStart; }
		}

		public static void Initialize()
		{
			m_ServerStart = DateTime.Now;
		}

		[Constructable]
		public Clock() : this( 0x104B )
		{
		}

		[Constructable]
		public Clock( int itemID ) : base( itemID )
		{
			Weight = 3.0;
		}

		public Clock( Serial serial ) : base( serial )
		{
		}

		public const double SecondsPerUOMinute = 15;
        public const double MinutesPerUODay = 0.05 * 60;//SecondsPerUOMinute * 60; Just in case MinutesPerUODay is important elsewhere

		public static DateTime WorldStart = new DateTime( 2014, 1, 1 );

		public static MoonPhase GetMoonPhase( Map map, int x, int y )
		{
			int hours, minutes;

			GetTime( out hours, out minutes );

			if ( map != null )
				minutes /= 10 + (map.MapIndex * 20);

			return (MoonPhase)(minutes % 8);
		}

        public static void GetTime(out int hours, out int minutes)
        {
            TimeSpan timeSpan = DateTime.Now - WorldStart;

            int totalMinutes = (int)(timeSpan.TotalSeconds * SecondsPerUOMinute);

            hours = (totalMinutes / 60) % 24;
            minutes = totalMinutes % 60;
        }

        public static string GetExactTime()
        {
            int hours, minutes;

            GetTime(out hours, out minutes);

            hours %= 12;

            return String.Format("{0}:{1:D2}", hours, minutes);
        }

        public override void OnDoubleClick(Mobile from)
        {
            LabelTo(from, GetExactTime());
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Weight == 2.0 )
				Weight = 3.0;
		}
	}

	[Flipable( 0x104B, 0x104C )]
	public class ClockRight : Clock
	{
		[Constructable]
		public ClockRight() : base( 0x104B )
		{
		}

		public ClockRight( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	[Flipable( 0x104B, 0x104C )]
	public class ClockLeft : Clock
	{
		[Constructable]
		public ClockLeft() : base( 0x104C )
		{
		}

		public ClockLeft( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}