using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Accounting;

namespace Server.Misc
{
	public class CharacterCreation
	{
		public static void Initialize()
		{
			// Register our event handler
			EventSink.CharacterCreated += new CharacterCreatedEventHandler( EventSink_CharacterCreated );
		}

		private static void AddBackpack( Mobile m )
		{
			Container pack = m.Backpack;

			if ( pack == null )
			{
				pack = new Backpack();
				pack.Movable = false;

				m.AddItem( pack );
			}

			/*PackItem( new RedBook( "a book", m.Name, 20, true ) );
			PackItem( new Gold( 100 ) ); // Starting gold can be customized here
			PackItem( new Dagger() );
			PackItem( new Candle() );*/
		}

		private static Mobile CreateMobile( Account a )
		{
			if ( a.Count >= a.Limit )
				return null;

			for ( int i = 0; i < a.Length; ++i )
			{
				if ( a[i] == null )
					return (a[i] = new TMobile());
			}

			return null;
		}

		private static void EventSink_CharacterCreated( CharacterCreatedEventArgs args )
		{
			if ( !VerifyProfession( args.Profession ) )
				args.Profession = 0;

			NetState state = args.State;

			if ( state == null )
				return;

			Mobile newChar = CreateMobile( args.Account as Account );

			if ( newChar == null )
			{
				Console.WriteLine( "Login: {0}: Character creation failed, account full", state );
				return;
			}

			args.Mobile = newChar;
			m_Mobile = newChar;

			newChar.Player = true;
			newChar.AccessLevel = args.Account.AccessLevel;
			newChar.Female = args.Female;
			newChar.Body = newChar.Female ? 0x191 : 0x190;

            newChar.Hue = Utility.ClipSkinHue( args.Hue & 0x3FFF ) | 0x8000;


			bool young = false;

			if ( newChar is PlayerMobile )
			{
				PlayerMobile pm = (PlayerMobile) newChar;

				pm.Profession = args.Profession;
			}

			SetName( newChar, args.Name );

			AddBackpack( newChar );

            newChar.InitStats(25, 25, 25);

            newChar.HairItemID = args.HairID;
            newChar.HairHue = args.HairHue & 0x3FFF;

            newChar.FacialHairItemID = args.BeardID;
            newChar.FacialHairHue = args.BeardHue & 0x3FFF;
			

			CityInfo city = GetStartLocation( args, young );

			newChar.MoveToWorld( city.Location, city.Map );

			Console.WriteLine( "Login: {0}: New character being created (account={1})", state, args.Account.Username );
			Console.WriteLine( " - Character: {0} (serial={1})", newChar.Name, newChar.Serial );
			Console.WriteLine( " - Started: {0} {1} in {2}", city.City, city.Location, city.Map.ToString() );

			new WelcomeTimer( newChar ).Start();
		}

		public static bool VerifyProfession( int profession )
		{
			if ( profession < 0 )
				return false;
			else if ( profession < 4 )
				return true;
			else if ( Core.AOS && profession < 6 )
				return true;
			else if ( Core.SE && profession < 8 )
				return true;
			else
				return false;
		}

		private class BadStartMessage : Timer
		{
			Mobile m_Mobile;
			int m_Message;
			public BadStartMessage( Mobile m, int message ) : base( TimeSpan.FromSeconds ( 3.5 ) )
			{
				m_Mobile = m;
				m_Message = message;
				this.Start();
			}

			protected override void OnTick()
			{
				m_Mobile.SendLocalizedMessage( m_Message );
			}
		}

		private static CityInfo GetStartLocation( CharacterCreatedEventArgs args, bool isYoung )
		{
            return new CityInfo("Temrael", "Creation", 6024, 107, 10, Map.Felucca);
		}

		private static void SetName( Mobile m, string name )
		{
			name = name.Trim();

			if ( !NameVerification.Validate( name, 2, 16, true, false, true, 1, NameVerification.SpaceDashPeriodQuote ) )
				name = "Generic Player";

			m.Name = name;
		}

		private static Mobile m_Mobile;
	}
}