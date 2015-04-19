using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13db, 0x13e2 )]
	public class StuddedChest : BaseArmor
	{

        public override double BasePhysicalResistance { get { return ArmorStudded.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ArmorStudded.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorStudded.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorStudded.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorStudded.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorStudded.malus_Dex; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Studded; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		[Constructable]
		public StuddedChest() : base( 0x13DB )
		{
			Weight = 8.0;
            Layer = Layer.InnerTorso;
		}

		public StuddedChest( Serial serial ) : base( serial )
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
				Weight = 8.0;

            Layer = Layer.InnerTorso;
		}
	}
}