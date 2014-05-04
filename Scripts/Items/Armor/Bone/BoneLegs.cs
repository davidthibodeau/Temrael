using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1452, 0x1457 )]
	public class BoneLegs : BaseArmor
	{
        public override int NiveauAttirail { get { return 2; } }

        public override int BasePhysicalResistance { get { return Os_Jambieres; } }
        public override int BaseContondantResistance { get { return Os_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return Os_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return Os_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return Os_Jambieres_Magique; } }

        public override int InitMinHits { get { return Os_MinDurabilite; } }
        public override int InitMaxHits { get { return Os_MaxDurabilite; } }

        public override int AosStrReq { get { return Os_Jambieres_Force; } }
		public override int OldStrReq{ get{ return 40; } }

		public override int OldDexBonus{ get{ return -4; } }

		public override int ArmorBase{ get{ return 30; } }
		public override int RevertArmorBase{ get{ return 7; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Bone; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularBones; } }

		[Constructable]
		public BoneLegs() : base( 0x1452 )
		{
			Weight = 3.0;
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
		}
	}
}