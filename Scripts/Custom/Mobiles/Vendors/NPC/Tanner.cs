using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class Tanner : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }
        private Races races = Races.Humain;

        public Races Races { get { return races; } set { races = value; InitSBInfo(); } }

		[Constructable]
		public Tanner() : base( "Tanneur" )
		{
			SetSkill( SkillName.Couture, 36.0, 68.0 );
		}

		public override void InitSBInfo()
		{
            m_SBInfos.Clear();
            switch (races)
            {
                case Races.Aasimar: m_SBInfos.Add(new SBTannerAasimar()); break;
                case Races.Elfe: m_SBInfos.Add(new SBTannerElfe()); break;
                case Races.ElfeNoir: m_SBInfos.Add(new SBTannerDrow()); break;
                case Races.Humain: m_SBInfos.Add(new SBTanner()); break;
                case Races.Nain: m_SBInfos.Add(new SBTannerNain()); break;
                case Races.Nomade: m_SBInfos.Add(new SBTannerNomade()); break;
                case Races.Nordique: m_SBInfos.Add(new SBTannerNordique()); break;
                case Races.Orcish: m_SBInfos.Add(new SBTannerOrcish()); break;
                case Races.Tieffelin: m_SBInfos.Add(new SBTannerTieffelin()); break;
                default: m_SBInfos.Add(new SBTanner()); break;
            }

			//m_SBInfos.Add( new SBTanner() );
		}

		public Tanner( Serial serial ) : base( serial )
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
