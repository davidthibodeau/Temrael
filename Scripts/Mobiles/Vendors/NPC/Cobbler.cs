using System; 
using System.Collections.Generic; 
using Server; 

namespace Server.Mobiles 
{ 
	public class Cobbler : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }
        private Race races = Race.Capiceen;

        public Race Races { get { return races; } set { races = value; InitSBInfo(); } }

		[Constructable]
        public Cobbler()
            : base("Cordonnier") 
		{ 
			SetSkill( SkillName.Couture, 60.0, 83.0 );
		} 

		public override void InitSBInfo() 
		{
            m_SBInfos.Clear();
            switch (races)
            {
                case Race.Aasimar: m_SBInfos.Add(new SBCobbler()); break;
                case Race.Elfe: m_SBInfos.Add(new SBCobblerElfe()); break;
                case Race.ElfeNoir: m_SBInfos.Add(new SBCobblerDrow()); break;
                case Race.Capiceen: m_SBInfos.Add(new SBCobbler()); break;
                case Race.Nain: m_SBInfos.Add(new SBCobblerNain()); break;
                case Race.Nomade: m_SBInfos.Add(new SBCobblerNomade()); break;
                case Race.Nordique: m_SBInfos.Add(new SBCobblerNordique()); break;
                case Race.Orcish: m_SBInfos.Add(new SBCobblerOrcish()); break;
                case Race.Tieffelin: m_SBInfos.Add(new SBCobblerTieffelin()); break;
                default: m_SBInfos.Add(new SBCobbler()); break;
            }

			//m_SBInfos.Add( new SBCobbler() ); 
		} 

		public override VendorShoeType ShoeType
		{
			get{ return Utility.RandomBool() ? VendorShoeType.Sandals : VendorShoeType.Shoes; }
		}

		public Cobbler( Serial serial ) : base( serial ) 
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