using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1c0c, 0x1c0d )]
	public class StuddedBustierArms : BaseArmor
	{

        public override int BasePhysicalResistance { get { return ArmorStudded.resistance_Physique; } }
        public override int BaseMagieResistance { get { return ArmorStudded.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorStudded.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorStudded.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorStudded.force_Requise; } }
        public override int AosDexBonus { get { return ArmorStudded.malus_Dex; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Studded; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

        public override ArmorMeditationAllowance DefMedAllowance { get { return ArmorMeditationAllowance.All; } }

		public override bool AllowMaleWearer{ get{ return false; } }

		[Constructable]
		public StuddedBustierArms() : base( 0x1C0C )
		{
			Weight = 1.0;
		}

		public StuddedBustierArms( Serial serial ) : base( serial )
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