using System;
using System.Collections.Generic;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class HolyMage : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public HolyMage() : base( "Religieux" )
		{
			//SetSkill( SkillName.EvalInt, 65.0, 88.0 );
			SetSkill( SkillName.Inscription, 60.0, 83.0 );
			SetSkill( SkillName.ArtMagique, 64.0, 100.0 );
			SetSkill( SkillName.Concentration, 60.0, 83.0 );
			SetSkill( SkillName.Concentration, 65.0, 88.0 );
			SetSkill( SkillName.ArmePoing, 36.0, 68.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBHolyMage() );
		}

		public Item ApplyHue( Item item, int hue )
		{
			item.Hue = hue;

			return item;
		}

		public override void InitOutfit()
		{
			AddItem( ApplyHue( new Robe(), 0x47E ) );
			AddItem( ApplyHue( new ThighBoots(), 0x47E ) );
			AddItem( ApplyHue( new BlackStaff(), 0x47E ) );

			if ( Female )
			{
				AddItem( ApplyHue( new LeatherGloves(), 0x47E ) );
				AddItem( ApplyHue( new GoldNecklace(), 0x47E ) );
			}
			else
			{
				AddItem( ApplyHue( new PlateGloves(), 0x47E ) );
				AddItem( ApplyHue( new PlateGorget(), 0x47E ) );
			}

			switch ( Utility.Random( Female ? 2 : 1 ) )
			{
				case 0: HairItemID = 0x203C; break;
				case 1: HairItemID = 0x203D; break;
			}

			HairHue = 0x47E;

			PackGold( 100, 200 );
		}

		public HolyMage( Serial serial ) : base( serial )
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