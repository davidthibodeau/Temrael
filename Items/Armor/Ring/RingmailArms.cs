using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13ee, 0x13ef )]
	public class RingmailArms : BaseArmor
	{
        public override int NiveauAttirail { get { return 2; } }

        public override int BasePhysicalResistance { get { return Ring_Brassards; } }
        public override int BaseContondantResistance { get { return Ring_Brassards_Contondant; } }
        public override int BaseTranchantResistance { get { return Ring_Brassards_Tranchant; } }
        public override int BasePerforantResistance { get { return Ring_Brassards_Perforant; } }
        public override int BaseMagieResistance { get { return Ring_Brassards_Magique; } }

        public override int InitMinHits { get { return Ring_MinDurabilite; } }
        public override int InitMaxHits { get { return Ring_MaxDurabilite; } }

        public override int AosStrReq { get { return Ring_Brassards_Force; } }
		public override int OldStrReq{ get{ return 20; } }

        public override int OldDexBonus { get { return Ring_Brassards_Dex; } }

		public override int ArmorBase{ get{ return 22; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Ringmail; } }

		[Constructable]
		public RingmailArms() : base( 0x13EE )
		{
			Weight = 15.0;
		}

		public RingmailArms( Serial serial ) : base( serial )
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
				Weight = 15.0;
		}
	}
}