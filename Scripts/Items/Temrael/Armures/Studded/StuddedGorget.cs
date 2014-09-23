using System;
using Server.Items;

namespace Server.Items
{
	public class StuddedGorget : BaseArmor
	{

        public override int BasePhysicalResistance { get { return ArmorStudded.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorStudded.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorStudded.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorStudded.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorStudded.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorStudded.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorStudded.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorStudded.force_Requise; } }
        public override int AosDexBonus { get { return ArmorStudded.malus_Dex; } }

		public override int ArmorBase{ get{ return 16; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Studded; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

        public override ArmorMeditationAllowance DefMedAllowance { get { return ArmorMeditationAllowance.All; } }

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