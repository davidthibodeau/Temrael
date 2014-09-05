using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class Tinker : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public Tinker() : base( "Bricoleur" )
		{
			SetSkill( SkillName.Crochetage, 60.0, 83.0 );
			SetSkill( SkillName.Pieges, 75.0, 98.0 );
			SetSkill( SkillName.Menuiserie, 64.0, 100.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBTinker() );
		}

		public Tinker( Serial serial ) : base( serial )
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
		}
	}
}