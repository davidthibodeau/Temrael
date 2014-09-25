using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1450, 0x1455 )]
	public class BoneGloves : BaseArmor
	{

        public override int BasePhysicalResistance { get { return ArmorBone.resistance_Physique; } }
        public override int BaseMagieResistance { get { return ArmorBone.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorBone.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorBone.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorBone.force_Requise; } }
        public override int AosDexBonus { get { return ArmorBone.malus_Dex; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Bone; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularBones; } }

		[Constructable]
		public BoneGloves() : base( 0x1450 )
		{
			Weight = 2.0;
		}

		public BoneGloves( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );

			if ( Weight == 1.0 )
				Weight = 2.0;
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}