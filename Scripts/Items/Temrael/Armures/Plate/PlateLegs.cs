using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1411, 0x141a )]
	public class PlateLegs : BaseArmor
	{
        //public override int NiveauAttirail { get { return Plaque_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaque.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ArmorPlaque.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaque.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaque.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorPlaque.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorPlaque.malus_Dex; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public PlateLegs() : base( 0x1411 )
		{
			Weight = 7.0;
            Layer = Layer.Pants;
		}

		public PlateLegs( Serial serial ) : base( serial )
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
            Layer = Layer.Pants;
		}
	}
}