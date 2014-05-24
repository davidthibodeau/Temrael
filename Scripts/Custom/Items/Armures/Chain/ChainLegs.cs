using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13be, 0x13c3 )]
	public class ChainLegs : BaseArmor
	{
        public override int NiveauAttirail { get { return Chain_Niveau; } }

        public override int BasePhysicalResistance { get { return Chain_Physique; } }
        public override int BaseContondantResistance { get { return Chain_Contondant; } }
        public override int BaseTranchantResistance { get { return Chain_Tranchant; } }
        public override int BasePerforantResistance { get { return Chain_Perforant; } }
        public override int BaseMagieResistance { get { return Chain_Magique; } }

        public override int InitMinHits { get { return Chain_MinDurabilite; } }
        public override int InitMaxHits { get { return Chain_MaxDurabilite; } }

        public override int AosStrReq { get { return Chain_Force; } }
		public override int OldStrReq{ get{ return 20; } }

		public override int OldDexBonus{ get{ return -3; } }

		public override int ArmorBase{ get{ return 28; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Chainmail; } }

		[Constructable]
		public ChainLegs() : base( 0x13BE )
		{
			Weight = 7.0;
		}

		public ChainLegs( Serial serial ) : base( serial )
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