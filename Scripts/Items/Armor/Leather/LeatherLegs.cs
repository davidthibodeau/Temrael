using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13cb, 0x13d2 )]
	public class LeatherLegs : BaseArmor
	{
        public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return Leather_Jambieres; } }
        public override int BaseContondantResistance { get { return Leather_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return Leather_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return Leather_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return Leather_Jambieres_Magique; } }

        public override int InitMinHits { get { return Leather_MinDurabilite; } }
        public override int InitMaxHits { get { return Leather_MaxDurabilite; } }

        public override int AosStrReq { get { return Leather_Jambieres_Force; } }
		public override int OldStrReq{ get{ return 10; } }

		public override int ArmorBase{ get{ return 13; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		[Constructable]
		public LeatherLegs() : base( 0x13CB )
		{
			Weight = 4.0;
		}

		public LeatherLegs( Serial serial ) : base( serial )
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