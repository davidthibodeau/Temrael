using System;
using Server;

namespace Server.Items
{
	public class HeaterShield : BaseShield
	{
        //public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return ShldHeater.resistance_Physique ; } }
        public override int BaseContondantResistance { get { return ShldHeater.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ShldHeater.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ShldHeater.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ShldHeater.resistance_Magique; } }

        public override int InitMinHits { get { return ShldHeater.min_Durabilite; } }
        public override int InitMaxHits { get { return ShldHeater.max_Durabilite; } }

        public override int AosStrReq { get { return ShldHeater.force_Requise; } }
        public override int AosDexBonus { get { return ShldHeater.malus_Dex; } }

		public override int ArmorBase{ get{ return 23; } }

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
