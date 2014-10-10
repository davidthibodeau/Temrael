using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	[TypeAlias( "Server.Mobiles.Bower" )]
	public class Bowyer : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }
        private Race races = Race.Capiceen;

        public Race Races { get { return races; } set { races = value; InitSBInfo(); } }

		[Constructable]
		public Bowyer() : base( "Fabricant d'Arcs" )
		{
			SetSkill( SkillName.Menuiserie, 80.0, 100.0 );
			SetSkill( SkillName.ArmeDistance, 80.0, 100.0 );
		}

		public override VendorShoeType ShoeType
		{
			get{ return Female ? VendorShoeType.ThighBoots : VendorShoeType.Boots; }
		}

		public override int GetShoeHue()
		{
			return 0;
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.GrandArc() );
			AddItem( new Server.Items.LeatherGorget() );
		}

		public override void InitSBInfo()
		{
            m_SBInfos.Clear();
            switch (races)
            {
                case Race.Aasimar: m_SBInfos.Add(new SBBowyerAasimar()); break;
                case Race.Elfe: m_SBInfos.Add(new SBBowyerElfe()); break;
                case Race.ElfeNoir: m_SBInfos.Add(new SBBowyerDrow()); break;
                case Race.Capiceen: m_SBInfos.Add(new SBBowyer()); break;
                case Race.Nain: m_SBInfos.Add(new SBBowyerNain()); break;
                case Race.Nomade: m_SBInfos.Add(new SBBowyerNomade()); break;
                case Race.Nordique: m_SBInfos.Add(new SBBowyerNordique()); break;
                case Race.Orcish: m_SBInfos.Add(new SBBowyerOrcish()); break;
                case Race.Tieffelin: m_SBInfos.Add(new SBBowyerTieffelin()); break;
                default: m_SBInfos.Add(new SBBowyer()); break;
            }

			/*m_SBInfos.Add( new SBBowyer() );
			m_SBInfos.Add( new SBRangedWeapon() );
			
			if ( IsTokunoVendor )
				m_SBInfos.Add( new SBSEBowyer() );	*/
		}

		public Bowyer( Serial serial ) : base( serial )
		{
		}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version

            writer.Write((int)races);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1: reader.ReadInt(); goto case 0;
                case 0: break;
            }
        }
	}
}