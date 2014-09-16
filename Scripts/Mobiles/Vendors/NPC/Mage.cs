using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class Mage : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }
        private Races races = Races.Capiceen;

        public Races Races { get { return races; } set { races = value; InitSBInfo(); } }

		[Constructable]
		public Mage() : base( "Mage" )
		{
			//SetSkill( SkillName.EvalInt, 65.0, 88.0 );
			SetSkill( SkillName.Inscription, 60.0, 83.0 );
			SetSkill( SkillName.ArtMagique, 64.0, 100.0 );
			SetSkill( SkillName.Concentration, 60.0, 83.0 );
			//SetSkill( SkillName.Concentration, 65.0, 88.0 );
			SetSkill( SkillName.Anatomie, 36.0, 68.0 );
		}

		public override void InitSBInfo()
		{
            m_SBInfos.Clear();
            switch (races)
            {
                case Races.Aasimar: m_SBInfos.Add(new SBMageAasimar()); break;
                case Races.Elfe: m_SBInfos.Add(new SBMageElfe()); break;
                case Races.ElfeNoir: m_SBInfos.Add(new SBMageDrow()); break;
                case Races.Capiceen: m_SBInfos.Add(new SBMage()); break;
                case Races.Nain: m_SBInfos.Add(new SBMageNain()); break;
                case Races.Nomade: m_SBInfos.Add(new SBMageNomade()); break;
                case Races.Nordique: m_SBInfos.Add(new SBMageNordique()); break;
                case Races.Orcish: m_SBInfos.Add(new SBMageOrcish()); break;
                case Races.Tieffelin: m_SBInfos.Add(new SBMageTieffelin()); break;
                default: m_SBInfos.Add(new SBMage()); break;
            }

			//m_SBInfos.Add( new SBMage() );
		}

		public override VendorShoeType ShoeType
		{
			get{ return Utility.RandomBool() ? VendorShoeType.Shoes : VendorShoeType.Sandals; }
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.Robe( Utility.RandomBlueHue() ) );
		}

		public Mage( Serial serial ) : base( serial )
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