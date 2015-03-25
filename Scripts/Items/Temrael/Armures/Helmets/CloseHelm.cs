using System;
using Server;

namespace Server.Items
{
	public class CloseHelm : BaseArmor
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
		public CloseHelm() : base( 0x1408 )
		{
			Weight = 5.0;
		}

		public CloseHelm( Serial serial ) : base( serial )
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