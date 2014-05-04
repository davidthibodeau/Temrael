using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1450, 0x1455 )]
	public class BoneGloves : BaseArmor
	{
        public override int NiveauAttirail { get { return 2; } }

        public override int BasePhysicalResistance { get { return Os_Gants; } }
        public override int BaseContondantResistance { get { return Os_Gants_Contondant; } }
        public override int BaseTranchantResistance { get { return Os_Gants_Tranchant; } }
        public override int BasePerforantResistance { get { return Os_Gants_Perforant; } }
        public override int BaseMagieResistance { get { return Os_Gants_Magique; } }

        public override int InitMinHits { get { return Os_MinDurabilite; } }
        public override int InitMaxHits { get { return Os_MaxDurabilite; } }

        public override int AosStrReq { get { return Os_Gants_Force; } }
		public override int OldStrReq{ get{ return 40; } }

		public override int OldDexBonus{ get{ return -1; } }

		public override int ArmorBase{ get{ return 30; } }
		public override int RevertArmorBase{ get{ return 2; } }

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