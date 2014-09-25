using System;
using Server;

namespace Server.Items
{
	public class Buckler : BaseShield
	{
        //public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return ShldBuckler.resistance_Physique ; } }
        public override int BaseMagieResistance { get { return ShldBuckler.resistance_Magique; } }

        public override int InitMinHits { get { return ShldBuckler.min_Durabilite; } }
        public override int InitMaxHits { get { return ShldBuckler.max_Durabilite; } }

        public override int AosStrReq { get { return ShldBuckler.force_Requise; } }
        public override int AosDexBonus { get { return ShldBuckler.malus_Dex; } }

		[Constructable]
		public Buckler() : base( 0x1B73 )
		{
			Weight = 5.0;
            Name = "Bouclet";
		}

		public Buckler( Serial serial ) : base(serial)
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
