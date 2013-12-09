using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x13BB, 0x13C0 )]
	public class ChainCoif : BaseArmor
	{
        public override int NiveauAttirail { get { return 4; } }

        public override int BasePhysicalResistance { get { return Chain_Casque; } }
        public override int BaseContondantResistance { get { return Chain_Casque_Contondant; } }
        public override int BaseTranchantResistance { get { return Chain_Casque_Tranchant; } }
        public override int BasePerforantResistance { get { return Chain_Casque_Perforant; } }
        public override int BaseMagieResistance { get { return Chain_Casque_Magique; } }

        public override int InitMinHits { get { return Chain_MinDurabilite; } }
        public override int InitMaxHits { get { return Chain_MaxDurabilite; } }

        public override int AosStrReq { get { return Chain_Casque_Force; } }
		public override int OldStrReq{ get{ return 20; } }

		public override int ArmorBase{ get{ return 28; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Chainmail; } }

		[Constructable]
		public ChainCoif() : base( 0x13BB )
		{
			Weight = 1.0;
		}

		public ChainCoif( Serial serial ) : base( serial )
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