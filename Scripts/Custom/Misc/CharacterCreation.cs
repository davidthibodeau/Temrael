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
			//newChar.Body = newChar.Female ? 0x191 : 0x190;

            newChar.Hue = Utility.ClipSkinHue( args.Hue & 0x3FFF ) | 0x8000;


			bool young = false;

			if ( newChar is PlayerMobile )
			{
				PlayerMobile pm = (PlayerMobile) newChar;

				pm.Profession = args.Profession;

				//if ( pm.AccessLevel == AccessLevel.Player && ((Account)pm.Account).Young )
				//	young = pm.Young = true;
			}

			SetName( newChar, args.Name );

			AddBackpack( newChar );

			SetStats( newChar, state, args.Str, args.Dex, args.Int );

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
            return new CityInfo("Temrael", "Creation", 6066, 4045, 5, Map.Felucca);
		}

		private static void FixStats( ref int str, ref int dex, ref int intel, int max )
		{
			int vMax = max - 30;

			int vStr = str - 10;
			int vDex = dex - 10;
			int vInt = intel - 10;

			if ( vStr < 0 )
				vStr = 0;

			if ( vDex < 0 )
				vDex = 0;

			if ( vInt < 0 )
				vInt = 0;

			int total = vStr + vDex + vInt;

			if ( total == 0 || total == vMax )
				return;

			double scalar = vMax / (double)total;

			vStr = (int)(vStr * scalar);
			vDex = (int)(vDex * scalar);
			vInt = (int)(vInt * scalar);

			FixStat( ref vStr, (vStr + vDex + vInt) - vMax, vMax );
			FixStat( ref vDex, (vStr + vDex + vInt) - vMax, vMax );
			FixStat( ref vInt, (vStr + vDex + vInt) - vMax, vMax );

			str = vStr + 25;
			dex = vDex + 25;
			intel = vInt + 25;
		}

		private static void FixStat( ref int stat, int diff, int max )
		{
			stat += diff;

			if ( stat < 0 )
				stat = 0;
			else if ( stat > max )
				stat = max;
		}

		private static void SetStats( Mobile m, NetState state, int str, int dex, int intel )
		{
			int max = state.NewCharacterCreation ? 90 : 80;

			FixStats( ref str, ref dex, ref intel, max );

			if ( str < 10 || str > 60 || dex < 10 || dex > 60 || intel < 10 || intel > 60 || (str + dex + intel) != max )
			{
				str = 25;
				dex = 25;
				intel = 25;
			}

			m.InitStats( str, dex, intel );
		}

		private static void SetName( Mobile m, string name )
		{
			name = name.Trim();

			if ( !NameVerification.Validate( name, 2, 16, true, false, true, 1, NameVerification.SpaceDashPeriodQuote ) )
				name = "Generic Player";

			m.Name = name;
		}

		private static Mobile m_Mobile;

		private static void EquipItem( Item item )
		{
			EquipItem( item, false );
		}

		private static void EquipItem( Item item, bool mustEquip )
		{
			if ( !Core.AOS )
				item.LootType = LootType.Newbied;

			if ( m_Mobile != null && m_Mobile.EquipItem( item ) )
				return;

			Container pack = m_Mobile.Backpack;

			if ( !mustEquip && pack != null )
				pack.DropItem( item );
			else
				item.Delete();
		}
	}
}