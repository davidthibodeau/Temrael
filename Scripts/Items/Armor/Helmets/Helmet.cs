using System;
using Server;

namespace Server.Items
{
	public class Helmet : BaseArmor
	{
        public override int NiveauAttirail { get { return 2; } }

        public override int BasePhysicalResistance { get { return Ring_Casque; } }
        public override int BaseContondantResistance { get { return Ring_Casque_Contondant; } }
        public override int BaseTranchantResistance { get { return Ring_Casque_Tranchant; } }
        public override int BasePerforantResistance { get { return Ring_Casque_Perforant; } }
        public override int BaseMagieResistance { get { return Ring_Casque_Magique; } }

        public override int InitMinHits { get { return Ring_MinDurabilite; } }
        public override int InitMaxHits { get { return Ring_MaxDurabilite; } }

        public override int AosStrReq { get { return Ring_Casque_Force; } }
		public override int OldStrReq{ get{ return 40; } }

        public override int OldDexBonus { get { return Ring_Casque_Dex; } }

		public override int ArmorBase{ get{ return 30; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public Helmet() : base( 0x140A )
		{
			Weight = 5.0;
		}

		public Helmet( Serial serial ) : base( serial )
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