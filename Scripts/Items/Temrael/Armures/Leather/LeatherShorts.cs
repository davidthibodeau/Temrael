using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1c00, 0x1c01 )]
	public class LeatherShorts : BaseArmor
	{

        public override int BasePhysicalResistance { get { return ArmorLeather.resistance_Physique; } }
        public override int BaseMagieResistance { get { return ArmorLeather.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorLeather.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorLeather.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorLeather.force_Requise; } }
        public override int AosDexBonus { get { return ArmorLeather.malus_Dex; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		public override bool AllowMaleWearer{ get{ return false; } }

		[Constructable]
		public LeatherShorts() : base( 0x1C00 )
		{
			Weight = 3.0;
		}

		public LeatherShorts( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}