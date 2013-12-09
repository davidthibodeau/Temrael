using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13eb, 0x13f2 )]
	public class RingmailGloves : BaseArmor
	{
        public override int NiveauAttirail { get { return 2; } }

		public override int BasePhysicalResistance{ get{ return Ring_Gants; } }
        public override int BaseContondantResistance { get { return Ring_Gants_Contondant; } }
        public override int BaseTranchantResistance { get { return Ring_Gants_Tranchant; } }
		public override int BasePerforantResistance{ get{ return Ring_Gants_Perforant; } }
		public override int BaseMagieResistance{ get{ return Ring_Gants_Magique; } }

		public override int InitMinHits{ get{ return Ring_MinDurabilite; } }
        public override int InitMaxHits { get { return Ring_MaxDurabilite; } }

        public override int AosStrReq { get { return Ring_Gants_Force; } }
		public override int OldStrReq{ get{ return 20; } }

        public override int OldDexBonus { get { return Ring_Gants_Dex; } }

		public override int ArmorBase{ get{ return 22; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Ringmail; } }

		[Constructable]
		public RingmailGloves() : base( 0x13EB )
		{
			Weight = 2.0;
		}

		public RingmailGloves( Serial serial ) : base( serial )
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
				Weight = 2.0;
		}
	}
}