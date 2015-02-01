using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class Tanner : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public Tanner() : base( "Tanneur" )
		{
			SetSkill( SkillName.Couture, 36.0, 68.0 );
		}

		public override void InitSBInfo()
		{
            m_SBInfos.Clear();
            //switch (races)
            //{
            //    case Race.Aasimar: m_SBInfos.Add(new SBTannerAasimar()); break;
            //    case Race.Elfe: m_SBInfos.Add(new SBTannerElfe()); break;
            //    case Race.ElfeNoir: m_SBInfos.Add(new SBTannerDrow()); break;
            //    case Race.Capiceen: m_SBInfos.Add(new SBTanner()); break;
            //    case Race.Nain: m_SBInfos.Add(new SBTannerNain()); break;
            //    case Race.Nomade: m_SBInfos.Add(new SBTannerNomade()); break;
            //    case Race.Nordique: m_SBInfos.Add(new SBTannerNordique()); break;
            //    case Race.Orcish: m_SBInfos.Add(new SBTannerOrcish()); break;
            //    case Race.Tieffelin: m_SBInfos.Add(new SBTannerTieffelin()); break;
            //    default: m_SBInfos.Add(new SBTanner()); break;
            //}

			//m_SBInfos.Add( new SBTanner() );
		}

		public Tanner( Serial serial ) : base( serial )
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
