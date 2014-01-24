using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class Armorer : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }
        private Races races = Races.Capiceen;

        public Races Races { get { return races; } set { races = value; InitSBInfo(); } }

		[Constructable]
		public Armorer() : base( "Armurier" )
		{
			SetSkill( SkillName.Identification, 64.0, 100.0 );
			SetSkill( SkillName.Forge, 60.0, 83.0 );
		}

		public override void InitSBInfo()
		{
            m_SBInfos.Clear();
            switch (races)
            {
                case Races.Aasimar: m_SBInfos.Add(new SBArmorerAasimar()); break;
                case Races.Elfe: m_SBInfos.Add(new SBArmorerElfe()); break;
                case Races.ElfeNoir: m_SBInfos.Add(new SBArmorerDrow()); break;
                case Races.Capiceen: m_SBInfos.Add(new SBArmorer()); break;
                case Races.Nain: m_SBInfos.Add(new SBArmorerNain()); break;
                case Races.Nomade: m_SBInfos.Add(new SBArmorerNomade()); break;
                case Races.Nordique: m_SBInfos.Add(new SBArmorerNordique()); break;
                case Races.Orcish: m_SBInfos.Add(new SBArmorerOrcish()); break;
                case Races.Tieffelin: m_SBInfos.Add(new SBArmorerTieffelin()); break;
                default: m_SBInfos.Add(new SBArmorer()); break;
            }

			/*switch ( Utility.Random( 4 ))
			{
				case 0:
				{
					m_SBInfos.Add( new SBLeatherArmor() );
					m_SBInfos.Add( new SBStuddedArmor() );
					m_SBInfos.Add( new SBMetalShields() );
					m_SBInfos.Add( new SBPlateArmor() );
					m_SBInfos.Add( new SBHelmetArmor() );
					m_SBInfos.Add( new SBChainmailArmor() );
					m_SBInfos.Add( new SBRingmailArmor() );
					break;
				}
				case 1:
				{
					m_SBInfos.Add( new SBStuddedArmor() );
					m_SBInfos.Add( new SBLeatherArmor() );
					m_SBInfos.Add( new SBMetalShields() );
					m_SBInfos.Add( new SBHelmetArmor() );
					break;
				}
				case 2:
				{
					m_SBInfos.Add( new SBMetalShields() );
					m_SBInfos.Add( new SBPlateArmor() );
					m_SBInfos.Add( new SBHelmetArmor() );
					m_SBInfos.Add( new SBChainmailArmor() );
					m_SBInfos.Add( new SBRingmailArmor() );
					break;
				}
				case 3:
				{
					m_SBInfos.Add( new SBMetalShields() );
					m_SBInfos.Add( new SBHelmetArmor() );
					break;
				}
			}
			if ( IsTokunoVendor )
			{
				m_SBInfos.Add( new SBSELeatherArmor() );	
				m_SBInfos.Add( new SBSEArmor() );
			}*/
		}

		public override VendorShoeType ShoeType
		{
			get{ return VendorShoeType.Boots; }
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.HalfApron( Utility.RandomYellowHue() ) );
			AddItem( new Server.Items.Bascinet() );
		}

		public Armorer( Serial serial ) : base( serial )
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