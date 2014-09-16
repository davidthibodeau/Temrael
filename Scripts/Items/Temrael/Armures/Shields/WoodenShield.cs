using System;
using Server;

namespace Server.Items
{
	public class WoodenShield : BaseShield
	{
        //public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return ShldWoodn.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ShldWoodn.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ShldWoodn.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ShldWoodn.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ShldWoodn.resistance_Magique; } }

        public override int InitMinHits { get { return ShldWoodn.min_Durabilite; } }
        public override int InitMaxHits { get { return ShldWoodn.max_Durabilite; } }

        public override int AosStrReq { get { return ShldWoodn.force_Requise; } }
        public override int AosDexBonus { get { return ShldWoodn.malus_Dex; } }

		[Constructable]
		public WoodenShield() : base( 0x1B7A )
		{
			Weight = 5.0;
		}

		public WoodenShield( Serial serial ) : base(serial)
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
