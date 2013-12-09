using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13d5, 0x13dd )]
	public class StuddedGloves : BaseArmor
	{
        public override int NiveauAttirail { get { return 2; } }

        public override int BasePhysicalResistance { get { return Studded_Gants; } }
        public override int BaseContondantResistance { get { return Studded_Gants_Contondant; } }
        public override int BaseTranchantResistance { get { return Studded_Gants_Tranchant; } }
        public override int BasePerforantResistance { get { return Studded_Gants_Perforant; } }
        public override int BaseMagieResistance { get { return Studded_Gants_Magique; } }

        public override int InitMinHits { get { return Studded_MinDurabilite; } }
        public override int InitMaxHits { get { return Studded_MaxDurabilite; } }

        public override int AosStrReq { get { return Studded_Gants_Force; } }
		public override int OldStrReq{ get{ return 25; } }

		public override int ArmorBase{ get{ return 16; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Studded; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.Half; } }

		[Constructable]
		public StuddedGloves() : base( 0x13D5 )
		{
			Weight = 1.0;
		}

		public StuddedGloves( Serial serial ) : base( serial )
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

			if ( Weight == 2.0 )
				Weight = 1.0;
		}
	}
}