using System;
using Server;

namespace Server.Items
{
	public class HeaterShield : BaseShield
	{
        //public override int NiveauAttirail { get { return 6; } }

        public override double BasePhysicalResistance { get { return ShldHeater.resistance_Physique ; } }
        public override double BaseMagieResistance { get { return ShldHeater.resistance_Magique; } }

        public override int InitMinHits { get { return ShldHeater.min_Durabilite; } }
        public override int InitMaxHits { get { return ShldHeater.max_Durabilite; } }

        public override int AosStrReq { get { return ShldHeater.force_Requise; } }
        public override int AosDexBonus { get { return ShldHeater.malus_Dex; } }

		[Constructable]
		public HeaterShield() : base( 0x1B76 )
		{
			Weight = 8.0;
            Name = "Pavois";
		}

		public HeaterShield( Serial serial ) : base(serial)
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
