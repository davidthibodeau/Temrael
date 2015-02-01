using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1452, 0x1457 )]
	public class BoneLegs : BaseArmor
	{

        public override double BasePhysicalResistance { get { return ArmorBone.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorBone.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorBone.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorBone.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorBone.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorBone.malus_Dex; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Bone; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularBones; } }

		[Constructable]
		public BoneLegs() : base( 0x1452 )
		{
			Weight = 3.0;
            Layer = Layer.Pants;
		}

		public BoneLegs( Serial serial ) : base( serial )
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

            Layer = Layer.Pants;
		}
	}
}