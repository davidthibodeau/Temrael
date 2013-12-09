using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13db, 0x13e2 )]
	public class StuddedChest : BaseArmor
	{
        public override int NiveauAttirail { get { return 2; } }

        public override int BasePhysicalResistance { get { return Studded_Cuirasse; } }
        public override int BaseContondantResistance { get { return Studded_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return Studded_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return Studded_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return Studded_Cuirasse_Magique; } }

        public override int InitMinHits { get { return Studded_MinDurabilite; } }
        public override int InitMaxHits { get { return Studded_MaxDurabilite; } }

        public override int AosStrReq { get { return Studded_Cuirasse_Force; } }
		public override int OldStrReq{ get{ return 35; } }

		public override int ArmorBase{ get{ return 16; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Studded; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.Half; } }

		[Constructable]
		public StuddedChest() : base( 0x13DB )
		{
			Weight = 8.0;
		}

		public StuddedChest( Serial serial ) : base( serial )
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
				Weight = 8.0;
		}
	}
}