using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class Jeweler : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public Jeweler() : base( "Bijoutier" )
		{
			SetSkill( SkillName.Fignolage, 64.0, 100.0 );
		}

		public override void InitSBInfo()
		{
            m_SBInfos.Clear();
            //switch (races)
            //{
            //    case Race.Aasimar: m_SBInfos.Add(new SBJewelAasimar()); break;
            //    case Race.Elfe: m_SBInfos.Add(new SBJewelElfe()); break;
            //    case Race.ElfeNoir: m_SBInfos.Add(new SBJewelDrow()); break;
            //    case Race.Capiceen: m_SBInfos.Add(new SBJewel()); break;
            //    case Race.Nain: m_SBInfos.Add(new SBJewelNain()); break;
            //    case Race.Nomade: m_SBInfos.Add(new SBJewelNomade()); break;
            //    case Race.Nordique: m_SBInfos.Add(new SBJewelNordique()); break;
            //    case Race.Orcish: m_SBInfos.Add(new SBJewelOrcish()); break;
            //    case Race.Tieffelin: m_SBInfos.Add(new SBJewelTieffelin()); break;
            //    default: m_SBInfos.Add(new SBJewel()); break;
            //}

			//m_SBInfos.Add( new SBJewel() );
		}

		public Jeweler( Serial serial ) : base( serial )
		{
		}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
	}
}