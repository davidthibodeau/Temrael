using System;
using Server;

namespace Server.Items
{
	public class WoodenKiteShield : BaseShield
	{
        //public override int NiveauAttirail { get { return 3; } }

        public override double BasePhysicalResistance { get { return ShldWoodnKite.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ShldWoodnKite.resistance_Magique; } }

        public override int InitMinHits { get { return ShldWoodnKite.min_Durabilite; } }
        public override int InitMaxHits { get { return ShldWoodnKite.max_Durabilite; } }

        public override int BaseStrReq { get { return ShldWoodnKite.force_Requise; } }
        public override int BaseDexBonus { get { return ShldWoodnKite.malus_Dex; } }

		[Constructable]
		public WoodenKiteShield() : base( 0x1B79 )
		{
			Weight = 5.0;
            Name = "Bouclier de Bois";
		}

		public WoodenKiteShield( Serial serial ) : base(serial)
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Weight == 7.0 )
				Weight = 5.0;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
