using System;
using Server;

namespace Server.Items
{
	public class PlateHelm : BaseArmor
	{
        //public override int NiveauAttirail { get { return Plaque_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorPlaque.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorPlaque.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorPlaque.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorPlaque.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorPlaque.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaque.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaque.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorPlaque.force_Requise; } }
        public override int AosDexBonus { get { return ArmorPlaque.malus_Dex; } }

		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public PlateHelm() : base( 0x1412 )
		{
			Weight = 5.0;
		}

		public PlateHelm( Serial serial ) : base( serial )
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