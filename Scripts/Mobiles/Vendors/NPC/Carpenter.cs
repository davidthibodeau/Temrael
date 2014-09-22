using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class Carpenter : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }
        private Race races = Race.Capiceen;

        public Race Races { get { return races; } set { races = value; InitSBInfo(); } }

		[Constructable]
		public Carpenter() : base( "Charpentier" )
		{
			SetSkill( SkillName.Menuiserie, 85.0, 100.0 );
			SetSkill( SkillName.Foresterie, 60.0, 83.0 );
		}

		public override void InitSBInfo()
		{
            m_SBInfos.Clear();
            switch (races)
            {
                case Race.Aasimar: m_SBInfos.Add(new SBCarpenter()); break;
                case Race.Elfe: m_SBInfos.Add(new SBCarpenterElfe()); break;
                case Race.ElfeNoir: m_SBInfos.Add(new SBCarpenterDrow()); break;
                case Race.Capiceen: m_SBInfos.Add(new SBCarpenter()); break;
                case Race.Nain: m_SBInfos.Add(new SBCarpenterNain()); break;
                case Race.Nomade: m_SBInfos.Add(new SBCarpenterNomade()); break;
                case Race.Nordique: m_SBInfos.Add(new SBCarpenterNordique()); break;
                case Race.Orcish: m_SBInfos.Add(new SBCarpenterOrcish()); break;
                case Race.Tieffelin: m_SBInfos.Add(new SBCarpenterTieffelin()); break;
                default: m_SBInfos.Add(new SBCarpenter()); break;
            }

			/*m_SBInfos.Add( new SBStavesWeapon() );
			m_SBInfos.Add( new SBCarpenter() );
			m_SBInfos.Add( new SBWoodenShields() );
			
			if ( IsTokunoVendor )
				m_SBInfos.Add( new SBSECarpenter() );*/
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.HalfApron() );
		}

		public Carpenter( Serial serial ) : base( serial )
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