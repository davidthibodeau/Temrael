using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13f0, 0x13f1 )]
	public class RingmailLegs : BaseArmor
	{
        public override int NiveauAttirail { get { return 2; } }

        public override int BasePhysicalResistance { get { return Ring_Jambieres; } }
        public override int BaseContondantResistance { get { return Ring_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return Ring_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return Ring_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return Ring_Jambieres_Magique; } }

        public override int InitMinHits { get { return Ring_MinDurabilite; } }
        public override int InitMaxHits { get { return Ring_MaxDurabilite; } }

        public override int AosStrReq { get { return Ring_Jambieres_Force; } }
		public override int OldStrReq{ get{ return 20; } }

        public override int OldDexBonus { get { return Ring_Jamvieres_Dex; } }

		public override int ArmorBase{ get{ return 22; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Ringmail; } }

		[Constructable]
		public RingmailLegs() : base( 0x13F0 )
		{
			Weight = 15.0;
		}

		public RingmailLegs( Serial serial ) : base( serial )
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
		}
	}
}