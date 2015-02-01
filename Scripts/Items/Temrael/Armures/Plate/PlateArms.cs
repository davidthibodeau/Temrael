using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1410, 0x1417 )]
	public class PlateArms : BaseArmor
	{
        //public override int NiveauAttirail { get { return Plaque_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaque.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorPlaque.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaque.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaque.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorPlaque.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorPlaque.malus_Dex; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public PlateArms() : base( 0x1410 )
		{
			Weight = 5.0;
		}

		public PlateArms( Serial serial ) : base( serial )
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
				Weight = 5.0;
		}
	}
}