using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x144e, 0x1453 )]
	public class BoneArms : BaseArmor
	{

        public override int BasePhysicalResistance { get { return ArmorBone.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorBone.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorBone.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorBone.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorBone.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorBone.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorBone.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorBone.force_Requise; } }
        public override int AosDexBonus { get { return ArmorBone.malus_Dex; } }

		public override int ArmorBase{ get{ return 30; } }
		public override int RevertArmorBase{ get{ return 4; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Bone; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularBones; } }

		[Constructable]
		public BoneArms() : base( 0x144E )
		{
			Weight = 2.0;
		}

		public BoneArms( Serial serial ) : base( serial )
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