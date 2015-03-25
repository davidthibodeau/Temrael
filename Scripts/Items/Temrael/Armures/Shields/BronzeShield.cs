using System;
using Server;

namespace Server.Items
{
	public class BronzeShield : BaseShield
	{
        //public override int NiveauAttirail { get { return 1; } }

        public override double BasePhysicalResistance { get { return ShldBronze.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ShldBronze.resistance_Magique; } }

        public override int InitMinHits { get { return ShldBronze.min_Durabilite; } }
        public override int InitMaxHits { get { return ShldBronze.max_Durabilite; } }

        public override int BaseStrReq { get { return ShldBronze.force_Requise; } }
        public override int BaseDexBonus { get { return ShldBronze.malus_Dex; } }

		[Constructable]
		public BronzeShield() : base( 0x1B72 )
		{
			Weight = 6.0;
            Name = "Bouclier Orné";
		}

		public BronzeShield( Serial serial ) : base(serial)
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
