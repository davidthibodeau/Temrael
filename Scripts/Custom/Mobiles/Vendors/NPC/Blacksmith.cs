using System;
using System.Collections.Generic;
using Server;
using Server.Engines.BulkOrders;

namespace Server.Mobiles
{
	public class Blacksmith : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }
        private Races races = Races.Capiceen;

        public Races Races { get { return races; } set { races = value; InitSBInfo(); } }

		[Constructable]
		public Blacksmith() : base( "Forgeron" )
		{
			SetSkill( SkillName.Identification, 36.0, 68.0 );
			SetSkill( SkillName.Forge, 65.0, 88.0 );
			SetSkill( SkillName.ArmePerforante, 60.0, 83.0 );
			SetSkill( SkillName.ArmeContondante, 61.0, 93.0 );
			SetSkill( SkillName.ArmeTranchante, 60.0, 83.0 );
			SetSkill( SkillName.Tactiques, 60.0, 83.0 );
			SetSkill( SkillName.Parer, 61.0, 93.0 );
		}

		public override void InitSBInfo()
		{
			/*m_SBInfos.Add( new SBSmithTools() );

			m_SBInfos.Add( new SBMetalShields() );
			m_SBInfos.Add( new SBWoodenShields() );

			m_SBInfos.Add( new SBPlateArmor() );

			m_SBInfos.Add( new SBHelmetArmor() );
			m_SBInfos.Add( new SBChainmailArmor() );
			m_SBInfos.Add( new SBRingmailArmor() );
			m_SBInfos.Add( new SBAxeWeapon() );
			m_SBInfos.Add( new SBPoleArmWeapon() );
			m_SBInfos.Add( new SBRangedWeapon() );

			m_SBInfos.Add( new SBKnifeWeapon() );
			m_SBInfos.Add( new SBMaceWeapon() );
			m_SBInfos.Add( new SBSpearForkWeapon() );
			m_SBInfos.Add( new SBSwordWeapon() );*/

            m_SBInfos.Clear();
            switch (races)
            {
                case Races.Aasimar: m_SBInfos.Add(new SBBlacksmithAasimar()); break;
                case Races.Elfe: m_SBInfos.Add(new SBBlacksmithElfe()); break;
                case Races.ElfeNoir: m_SBInfos.Add(new SBBlacksmithDrow()); break;
                case Races.Capiceen: m_SBInfos.Add(new SBBlacksmith()); break;
                case Races.Nain: m_SBInfos.Add(new SBBlacksmithNain()); break;
                case Races.Nomade: m_SBInfos.Add(new SBBlacksmithNomade()); break;
                case Races.Nordique: m_SBInfos.Add(new SBBlacksmithNordique()); break;
                case Races.Orcish: m_SBInfos.Add(new SBBlacksmithOrcish()); break;
                case Races.Tieffelin: m_SBInfos.Add(new SBBlacksmithTieffelin()); break;
                default: m_SBInfos.Add(new SBBlacksmith()); break;
            }

			/*m_SBInfos.Add( new SBBlacksmith() );
			if ( IsTokunoVendor )
			{
				m_SBInfos.Add( new SBSEArmor() );	
				m_SBInfos.Add( new SBSEWeapons() );
			}*/
		}

		public override VendorShoeType ShoeType
		{
			get{ return VendorShoeType.None; }
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			Item item = ( Utility.RandomBool() ? null : new Server.Items.RingmailChest() );

			if ( item != null && !EquipItem( item ) )
			{
				item.Delete();
				item = null;
			}

			if ( item == null )
				AddItem( new Server.Items.FullApron() );

			AddItem( new Server.Items.Bascinet() );
			AddItem( new Server.Items.SmithHammer() );
		}

		#region Bulk Orders
		/*public override Item CreateBulkOrder( Mobile from, bool fromContextMenu )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( pm != null && pm.NextSmithBulkOrder == TimeSpan.Zero && (fromContextMenu || 0.2 > Utility.RandomDouble()) )
			{
				double theirSkill = pm.Skills[SkillName.Forge].Base;

				if ( theirSkill >= 70.1 )
					pm.NextSmithBulkOrder = TimeSpan.FromHours( 6.0 );
				else if ( theirSkill >= 50.1 )
					pm.NextSmithBulkOrder = TimeSpan.FromHours( 2.0 );
				else
					pm.NextSmithBulkOrder = TimeSpan.FromHours( 1.0 );

				if ( theirSkill >= 70.1 && ((theirSkill - 40.0) / 300.0) > Utility.RandomDouble() )
					return new LargeSmithBOD();

				return SmallSmithBOD.CreateRandomFor( from );
			}

			return null;
		}

		public override bool IsValidBulkOrder( Item item )
		{
			return ( item is SmallSmithBOD || item is LargeSmithBOD );
		}

		public override bool SupportsBulkOrders( Mobile from )
		{
			return ( from is PlayerMobile && from.Skills[SkillName.Forge].Base > 0 );
		}

		public override TimeSpan GetNextBulkOrder( Mobile from )
		{
			if ( from is PlayerMobile )
				return ((PlayerMobile)from).NextSmithBulkOrder;

			return TimeSpan.Zero;
		}*/

		public override void OnSuccessfulBulkOrderReceive( Mobile from )
		{
			if( Core.SE && from is PlayerMobile )
				((PlayerMobile)from).NextSmithBulkOrder = TimeSpan.Zero;
		}
		#endregion

		public Blacksmith( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

            writer.Write((int)races);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            switch (version)
            {
                case 1: reader.ReadInt(); goto case 0;
                case 0: break;
            }
		}
	}
}