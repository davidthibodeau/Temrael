using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	[TypeAlias( "Server.Mobiles.GargoyleAlchemist" )]
	public class Glassblower : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
        public Glassblower()
            : base("Souffleur de verre")
		{
			SetSkill( SkillName.Alchimie, 85.0, 100.0 );
			SetSkill( SkillName.Empoisonnement, 85.0, 100.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBGlassblower() );
			m_SBInfos.Add( new SBAlchemist() );
		}

		public Glassblower( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Body == 0x2F2 )
				Body = 0x2F6;
		}
	}
}