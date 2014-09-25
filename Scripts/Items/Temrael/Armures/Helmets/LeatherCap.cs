using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x1db9, 0x1dba )]
	public class LeatherCap : BaseArmor
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

		[Constructable]
		public LeatherCap() : base( 0x1DB9 )
		{
			Weight = 2.0;
		}

		public LeatherCap( Serial serial ) : base( serial )
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

			if ( Weight == 1.0 )
				Weight = 2.0;
		}
	}
}