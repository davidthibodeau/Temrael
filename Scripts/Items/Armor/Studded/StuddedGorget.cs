using System;
using Server.Items;

namespace Server.Items
{
	public class StuddedGorget : BaseArmor
	{
        public override int NiveauAttirail { get { return 2; } }

        public override int BasePhysicalResistance { get { return Studded_Gorget; } }
        public override int BaseContondantResistance { get { return Studded_Gorget_Contondant; } }
        public override int BaseTranchantResistance { get { return Studded_Gorget_Tranchant; } }
        public override int BasePerforantResistance { get { return Studded_Gorget_Perforant; } }
        public override int BaseMagieResistance { get { return Studded_Gorget_Magique; } }

        public override int InitMinHits { get { return Studded_MinDurabilite; } }
        public override int InitMaxHits { get { return Studded_MaxDurabilite; } }

        public override int AosStrReq { get { return Studded_Gorget_Force; } }
		public override int OldStrReq{ get{ return 25; } }

		public override int ArmorBase{ get{ return 16; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Studded; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.Half; } }

		[Constructable]
		public StuddedGorget() : base( 0x13D6 )
		{
			Weight = 1.0;
		}

		public StuddedGorget( Serial serial ) : base( serial )
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