using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13cd, 0x13c5 )]
	public class LeatherArms : BaseArmor
    {
        public override int GoldValue { get { return 9; } }


        public override double BasePhysicalResistance { get { return ArmorLeather.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorLeather.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorLeather.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorLeather.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorLeather.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorLeather.malus_Dex; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		[Constructable]
		public LeatherArms() : base( 0x13CD )
		{
			Weight = 2.0;
		}

		public LeatherArms( Serial serial ) : base( serial )
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