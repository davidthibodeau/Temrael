using System;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Engines.Races;


namespace Server.Mobiles.Vendeurs
{
    public class Dresseur : BaseVendor
    {
        [Constructable]
        public Dresseur()
            : base("Dresseur")
        {
            Name = "Eldalote Lendis";
        }


        public Dresseur(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 0x35;
            Body = 0x191; //female

            SetRace(new Elfe(1002));
            HairItemID = 11125;
            HairHue = 2421;
            FacialHairItemID = 0;
            FacialHairHue = 0;
        }

        public override void InitOutfit()
        {
            AddItem(new ThighBoots(0));
            AddItem(new ElfiqueChaineLeggings(0));
            AddItem(new ChemiseElfique(0));
            AddItem(new FourreauDague(0));
            AddItem(new ChapeauCourt(0));
            AddItem(new Cloak(2325));
        }

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBDresseur());
        }

        
		private class StableEntry : ContextMenuEntry
		{
			private Dresseur m_Trainer;
			private Mobile m_From;

			public StableEntry( Dresseur trainer, Mobile from ) : base( 6126, 12 )
			{
				m_Trainer = trainer;
				m_From = from;
			}

			public override void OnClick()
			{
				m_Trainer.BeginStable( m_From );
			}
		}

		private class ClaimListGump : Gump
		{
			private Dresseur m_Trainer;
			private Mobile m_From;
			private List<BaseCreature> m_List;

			public ClaimListGump( Dresseur trainer, Mobile from, List<BaseCreature> list ) : base( 50, 50 )
			{
				m_Trainer = trainer;
				m_From = from;
				m_List = list;

				from.CloseGump( typeof( ClaimListGump ) );

				AddPage( 0 );

				AddBackground( 0, 0, 325, 50 + (list.Count * 20), 9250 );
				AddAlphaRegion( 5, 5, 315, 40 + (list.Count * 20) );

				AddHtml( 15, 15, 275, 20, "<BASEFONT COLOR=#FFFFFF>Select a pet to retrieve from the stables:</BASEFONT>", false, false );

				for ( int i = 0; i < list.Count; ++i )
				{
					BaseCreature pet = list[i];

					if ( pet == null || pet.Deleted )
						continue;

					AddButton( 15, 39 + (i * 20), 10006, 10006, i + 1, GumpButtonType.Reply, 0 );
					AddHtml( 32, 35 + (i * 20), 275, 18, String.Format( "<BASEFONT COLOR=#C0C0EE>{0}</BASEFONT>", pet.Name ), false, false );
				}
			}

			public override void OnResponse( NetState sender, RelayInfo info )
			{
				int index = info.ButtonID - 1;

				if ( index >= 0 && index < m_List.Count )
					m_Trainer.EndClaimList( m_From, m_List[index] );
			}
		}

		private class ClaimAllEntry : ContextMenuEntry
		{
			private Dresseur m_Trainer;
			private Mobile m_From;

			public ClaimAllEntry( Dresseur trainer, Mobile from ) : base( 6127, 12 )
			{
				m_Trainer = trainer;
				m_From = from;
			}

			public override void OnClick()
			{
				m_Trainer.Claim( m_From );
			}
		}

		public override void AddCustomContextEntries( Mobile from, List<ContextMenuEntry> list )
		{
			if ( from.Alive )
			{
				list.Add( new StableEntry( this, from ) );

				if ( from.Stabled.Count > 0 )
					list.Add( new ClaimAllEntry( this, from ) );
			}

			base.AddCustomContextEntries( from, list );
		}

		public static int GetMaxStabled( Mobile from )
		{
            // TOCHECK MAXSTABLED
			return 10;
		}

		private class StableTarget : Target
		{
			private Dresseur m_Trainer;

			public StableTarget( Dresseur trainer ) : base( 12, false, TargetFlags.None )
			{
				m_Trainer = trainer;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is BaseCreature )
					m_Trainer.EndStable( from, (BaseCreature)targeted );
				else if ( targeted == from )
					m_Trainer.SayTo( from, 502672 ); // HA HA HA! Sorry, I am not an inn.
				else
					m_Trainer.SayTo( from, 1048053 ); // You can't stable that!
			}
		}
		
		private void CloseClaimList( Mobile from )
		{
			from.CloseGump( typeof( ClaimListGump ) );
		}

		public void BeginClaimList( Mobile from )
		{
			if ( Deleted || !from.CheckAlive() )
				return;

			List<BaseCreature> list = new List<BaseCreature>();

			for ( int i = 0; i < from.Stabled.Count; ++i )
			{
				BaseCreature pet = from.Stabled[i] as BaseCreature;

				if ( pet == null || pet.Deleted )
				{
					pet.IsStabled = false;
					from.Stabled.RemoveAt( i );
					--i;
					continue;
				}

				list.Add( pet );
			}

			if ( list.Count > 0 )
				from.SendGump( new ClaimListGump( this, from, list ) );
			else
				SayTo( from, 502671 ); // But I have no animals stabled with me at the moment!
		}

		public void EndClaimList( Mobile from, BaseCreature pet )
		{
			if ( pet == null || pet.Deleted || from.Map != this.Map || !from.Stabled.Contains( pet ) || !from.CheckAlive() )
				return;
			
			if ( !from.InRange( this, 14 ) )
			{
				from.SendLocalizedMessage( 500446 ); // That is too far away.
				return;
			}

			if ( CanClaim( from, pet ) )
			{
				DoClaim( from, pet );

				from.Stabled.Remove( pet );
			}
			else
			{
				SayTo( from, 1049612, pet.Name ); // ~1_NAME~ remained in the stables because you have too many followers.
			}
		}

		public void BeginStable( Mobile from )
		{
			if ( Deleted || !from.CheckAlive() )
				return;

			Container bank = from.FindBankNoCreate();
			
			if ( ( from.Backpack == null || from.Backpack.GetAmount( typeof( Gold ) ) < 3 ) && ( bank == null || bank.GetAmount( typeof( Gold ) ) < 3 ) )
			{
				SayTo( from, 1042556 ); // Thou dost not have enough gold, not even in thy bank account.
			}
			else
			{
				/* I charge 3 gold per pet for a real week's stable time.
				 * I will withdraw it from thy bank account.
				 * Which animal wouldst thou like to stable here?
				 */
				from.SendLocalizedMessage(1042558);

				from.Target = new StableTarget( this );
			}
		}

		public void EndStable( Mobile from, BaseCreature pet )
		{
			if ( Deleted || !from.CheckAlive() )
				return;

			if ( pet.Body.IsHuman )
			{
				SayTo( from, 502672 ); // HA HA HA! Sorry, I am not an inn.
			}
			else if ( !pet.Controlled )
			{
				SayTo( from, 1048053 ); // You can't stable that!
			}
			else if ( pet.ControlMaster != from )
			{
				SayTo( from, 1042562 ); // You do not own that pet!
			}
			else if ( pet.IsDeadPet )
			{
				SayTo( from, 1049668 ); // Living pets only, please.
			}
			else if ( pet.Summoned )
			{
				SayTo( from, 502673 ); // I can not stable summoned creatures.
			}
			else if ( (pet is PackHorse || pet is Scarabee) && (pet.Backpack != null && pet.Backpack.Items.Count > 0) )
			{
				SayTo( from, 1042563 ); // You need to unload your pet.
			}
			else if ( pet.Combatant != null && pet.InRange( pet.Combatant, 12 ) && pet.Map == pet.Combatant.Map )
			{
				SayTo( from, 1042564 ); // I'm sorry.  Your pet seems to be busy.
			}
			else if ( from.Stabled.Count >= GetMaxStabled( from ) )
			{
				SayTo( from, 1042565 ); // You have too many pets in the stables!
			}
			else
			{
				Container bank = from.FindBankNoCreate();

				if ( ( from.Backpack != null && from.Backpack.ConsumeTotal( typeof( Gold ), 3 ) ) || ( bank != null && bank.ConsumeTotal( typeof( Gold ), 3 ) ) )
				{
					pet.ControlTarget = null;
					pet.ControlOrder = OrderType.Stay;
					pet.Internalize();

					pet.SetControlMaster( null );
					pet.SummonMaster = null;

					pet.IsStabled = true;

					if ( Core.SE )	
						pet.Loyalty = BaseCreature.MaxLoyalty; // Wonderfully happy

					from.Stabled.Add( pet );

					SayTo( from, Core.AOS ? 1049677 : 502679 ); // [AOS: Your pet has been stabled.] Very well, thy pet is stabled. Thou mayst recover it by saying 'claim' to me. In one real world week, I shall sell it off if it is not claimed!
				}
				else
				{
					SayTo( from, 502677 ); // But thou hast not the funds in thy bank account!
				}
			}
		}

		public void Claim( Mobile from )
		{
			Claim( from, null );
		}

		public void Claim( Mobile from, string petName )
		{
			if ( Deleted || !from.CheckAlive() )
				return;

			bool claimed = false;
			int stabled = 0;
			
			bool claimByName = ( petName != null );

			for ( int i = 0; i < from.Stabled.Count; ++i )
			{
				BaseCreature pet = from.Stabled[i] as BaseCreature;

				if ( pet == null || pet.Deleted )
				{
					pet.IsStabled = false;
					from.Stabled.RemoveAt( i );
					--i;
					continue;
				}

				++stabled;

				if ( claimByName && !Insensitive.Equals( pet.Name, petName ) )
					continue;

				if ( CanClaim( from, pet ) )
				{
					DoClaim( from, pet );

					from.Stabled.RemoveAt( i );
					--i;

					claimed = true;
				}
				else
				{
					SayTo( from, 1049612, pet.Name ); // ~1_NAME~ remained in the stables because you have too many followers.
				}
			}

			if ( claimed )
				SayTo( from, 1042559 ); // Here you go... and good day to you!
			else if ( stabled == 0 )
				SayTo( from, 502671 ); // But I have no animals stabled with me at the moment!
			else if ( claimByName )
				BeginClaimList( from );
		}

		public bool CanClaim( Mobile from, BaseCreature pet )
		{
			return ((from.Followers + pet.ControlSlots) <= from.FollowersMax);
		}

		private void DoClaim( Mobile from, BaseCreature pet )
		{
			pet.SetControlMaster( from );

			if ( pet.Summoned )
				pet.SummonMaster = from;

			pet.ControlTarget = from;
			pet.ControlOrder = OrderType.Follow;

			pet.MoveToWorld( from.Location, from.Map );

			pet.IsStabled = false;

			if ( Core.SE )
				pet.Loyalty = BaseCreature.MaxLoyalty; // Wonderfully Happy
		}

		public override bool HandlesOnSpeech( Mobile from )
		{
			return true;
		}

		public override void OnSpeech( SpeechEventArgs e )
		{
			if ( !e.Handled && e.HasKeyword( 0x0008 ) ) // *stable*
			{
				e.Handled = true;
				
				CloseClaimList( e.Mobile );				
				BeginStable( e.Mobile );
			}
			else if ( !e.Handled && e.HasKeyword( 0x0009 ) ) // *claim*
			{
				e.Handled = true;
				
				CloseClaimList( e.Mobile );
				
				int index = e.Speech.IndexOf( ' ' );

				if ( index != -1 )
					Claim( e.Mobile, e.Speech.Substring( index ).Trim() );
				else
					Claim( e.Mobile );
			}
			else
			{
				base.OnSpeech( e );
			}
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

    public class SBDresseur : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBDresseur()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new AnimalBuyInfo(1, typeof(Cat), 100, 10, 201, 0));
                Add(new AnimalBuyInfo(1, typeof(Dog), 150, 10, 217, 0));
                Add(new AnimalBuyInfo(1, typeof(HorseScelle), 500, 10, 204, 0));
                Add(new AnimalBuyInfo(1, typeof(PackHorse), 400, 10, 291, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
            }
        }
    }
}
