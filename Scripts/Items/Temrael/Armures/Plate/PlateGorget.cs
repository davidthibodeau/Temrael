using System;
using Server.Items;

namespace Server.Items
{
	public class PlateGorget : BaseArmor
	{
        //public override int NiveauAttirail { get { return Plaque_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorPlaque.resistance_Physique; } }
        public override int BaseMagieResistance { get { return ArmorPlaque.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaque.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaque.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorPlaque.force_Requise; } }
        public override int AosDexBonus { get { return ArmorPlaque.malus_Dex; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public PlateGorget() : base( 0x1413 )
		{
			Weight = 2.0;
		}

		public PlateGorget( Serial serial ) : base( serial )
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