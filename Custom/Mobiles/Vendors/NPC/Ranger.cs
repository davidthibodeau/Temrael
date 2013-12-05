using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class Ranger : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public Ranger() : base( "the ranger" )
		{
			SetSkill( SkillName.Survie, 55.0, 78.0 );
			SetSkill( SkillName.Detection, 65.0, 88.0 );
			SetSkill( SkillName.Discretion, 45.0, 68.0 );
			SetSkill( SkillName.ArmeDistance, 65.0, 88.0 );
			SetSkill( SkillName.Poursuite, 65.0, 88.0 );
			SetSkill( SkillName.Soins, 60.0, 83.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBRanger() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.Shirt( Utility.RandomNeutralHue() ) );
			AddItem( new Server.Items.LongPants( Utility.RandomNeutralHue() ) );
			AddItem( new Server.Items.Bow() );
			AddItem( new Server.Items.ThighBoots( Utility.RandomNeutralHue() ) );
		}

		public Ranger( Serial serial ) : base( serial )
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