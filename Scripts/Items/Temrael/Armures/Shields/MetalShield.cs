using System;
using Server;

namespace Server.Items
{
	public class MetalShield : BaseShield
	{
        //public override int NiveauAttirail { get { return 2; } }

        public override double BasePhysicalResistance { get { return ShldMetal.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ShldMetal.resistance_Magique; } }

        public override int InitMinHits { get { return ShldMetal.min_Durabilite; } }
        public override int InitMaxHits { get { return ShldMetal.max_Durabilite; } }

        public override int AosStrReq { get { return ShldMetal.force_Requise; } }
        public override int AosDexBonus { get { return ShldMetal.malus_Dex; } }

		[Constructable]
		public MetalShield() : base( 0x1B7B )
		{
			Weight = 6.0;
            Name = "Bouclier";
		}

		public MetalShield( Serial serial ) : base(serial)
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
