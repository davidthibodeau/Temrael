using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x1451, 0x1456 )]
	public class BoneHelm : BaseArmor
	{

        public override int BasePhysicalResistance { get { return Os_Physique; } }
        public override int BaseContondantResistance { get { return Os_Contondant; } }
        public override int BaseTranchantResistance { get { return Os_Tranchant; } }
        public override int BasePerforantResistance { get { return Os_Perforant; } }
        public override int BaseMagieResistance { get { return Os_Magique; } }

        public override int InitMinHits { get { return Os_MinDurabilite; } }
        public override int InitMaxHits { get { return Os_MaxDurabilite; } }

        public override int AosStrReq { get { return Os_Force; } }
		public override int OldStrReq{ get{ return 40; } }

		public override int ArmorBase{ get{ return 30; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Bone; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularBones; } }

		[Constructable]
		public BoneHelm() : base( 0x1451 )
		{
			Weight = 3.0;
		}

		public BoneHelm( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );

			if ( Weight == 1.0 )
				Weight = 3.0;
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}