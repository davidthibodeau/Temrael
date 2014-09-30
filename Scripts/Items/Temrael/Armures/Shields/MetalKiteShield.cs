using System;
using Server;

namespace Server.Items
{
	public class MetalKiteShield : BaseShield, IDyable
	{
        //public override int NiveauAttirail { get { return 4; } }

        public override double BasePhysicalResistance { get { return ShldMetalKite.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ShldMetalKite.resistance_Magique; } }

        public override int InitMinHits { get { return ShldMetalKite.min_Durabilite; } }
        public override int InitMaxHits { get { return ShldMetalKite.max_Durabilite; } }

        public override int AosStrReq { get { return ShldMetalKite.force_Requise; } }
        public override int AosDexBonus { get { return ShldMetalKite.malus_Dex; } }

		[Constructable]
		public MetalKiteShield() : base( 0x1B74 )
		{
			Weight = 7.0;
            Name = "Bouclier Croisé";
		}

		public MetalKiteShield( Serial serial ) : base(serial)
		{
		}

		public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
				return false;

			Hue = sender.Hue;

			return true;
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Weight == 5.0 )
				Weight = 7.0;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
