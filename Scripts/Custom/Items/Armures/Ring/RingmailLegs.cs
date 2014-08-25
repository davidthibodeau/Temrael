using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13f0, 0x13f1 )]
	public class RingmailLegs : BaseArmor
	{
        //public override int NiveauAttirail { get { return Ring_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorRingmail.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorRingmail.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorRingmail.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorRingmail.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorRingmail.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorRingmail.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorRingmail.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorRingmail.force_Requise; } }
        public override int AosDexBonus { get { return ArmorRingmail.malus_Dex; } }

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