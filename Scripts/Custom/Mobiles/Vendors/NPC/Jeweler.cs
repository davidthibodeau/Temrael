using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class Jeweler : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }
        private Races races = Races.Capiceen;

        public Races Races { get { return races; } set { races = value; InitSBInfo(); } }

		[Constructable]
		public Jeweler() : base( "Bijoutier" )
		{
			SetSkill( SkillName.Identification, 64.0, 100.0 );
		}

		public override void InitSBInfo()
		{
            m_SBInfos.Clear();
            switch (races)
            {
                case Races.Aasimar: m_SBInfos.Add(new SBJewelAasimar()); break;
                case Races.Elfe: m_SBInfos.Add(new SBJewelElfe()); break;
                case Races.ElfeNoir: m_SBInfos.Add(new SBJewelDrow()); break;
                case Races.Capiceen: m_SBInfos.Add(new SBJewel()); break;
                case Races.Nain: m_SBInfos.Add(new SBJewelNain()); break;
                case Races.Nomade: m_SBInfos.Add(new SBJewelNomade()); break;
                case Races.Nordique: m_SBInfos.Add(new SBJewelNordique()); break;
                case Races.Orcish: m_SBInfos.Add(new SBJewelOrcish()); break;
                case Races.Tieffelin: m_SBInfos.Add(new SBJewelTieffelin()); break;
                default: m_SBInfos.Add(new SBJewel()); break;
            }

			//m_SBInfos.Add( new SBJewel() );
		}

		public Jeweler( Serial serial ) : base( serial )
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