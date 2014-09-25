using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1c02, 0x1c03 )]
	public class FemaleStuddedChest : BaseArmor
	{

        public override Layer Layer
        {
            get
            {
                return Server.Layer.MiddleTorso;
            }
            set
            {
                base.Layer = value;
            }
        }

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
		public FemaleStuddedChest() : base( 0x1C02 )
		{
			Weight = 6.0;
		}

		public FemaleStuddedChest( Serial serial ) : base( serial )
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
				Weight = 6.0;
		}
	}
}