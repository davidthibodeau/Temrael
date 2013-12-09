using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13da, 0x13e1 )]
	public class StuddedLegs : BaseArmor
	{
        public override int NiveauAttirail { get { return 2; } }

        public override int BasePhysicalResistance { get { return Studded_Jambieres; } }
        public override int BaseContondantResistance { get { return Studded_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return Studded_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return Studded_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return Studded_Jambieres_Magique; } }

        public override int InitMinHits { get { return Studded_MinDurabilite; } }
        public override int InitMaxHits { get { return Studded_MaxDurabilite; } }

        public override int AosStrReq { get { return Studded_Jambieres_Force; } }
		public override int OldStrReq{ get{ return 35; } }

		public override int ArmorBase{ get{ return 16; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Studded; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.Half; } }

		[Constructable]
		public StuddedLegs() : base( 0x13DA )
		{
			Weight = 5.0;
		}

		public StuddedLegs( Serial serial ) : base( serial )
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

			if ( Weight == 3.0 )
				Weight = 5.0;
		}
	}
}