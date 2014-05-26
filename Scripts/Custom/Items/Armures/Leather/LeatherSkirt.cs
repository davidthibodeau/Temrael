using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1c08, 0x1c09 )]
	public class LeatherSkirt : BaseArmor
	{

        public override int BasePhysicalResistance { get { return Leather_Physique; } }
        public override int BaseContondantResistance { get { return Leather_Contondant; } }
        public override int BaseTranchantResistance { get { return Leather_Tranchant; } }
        public override int BasePerforantResistance { get { return Leather_Perforant; } }
        public override int BaseMagieResistance { get { return Leather_Magique; } }

        public override int InitMinHits { get { return Leather_MinDurabilite; } }
        public override int InitMaxHits { get { return Leather_MaxDurabilite; } }

        public override int AosStrReq { get { return Leather_Force; } }
		public override int OldStrReq{ get{ return 10; } }

		public override int ArmorBase{ get{ return 13; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		public override bool AllowMaleWearer{ get{ return false; } }

		[Constructable]
		public LeatherSkirt() : base( 0x1C08 )
		{
			Weight = 1.0;
		}

		public LeatherSkirt( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );

			if ( Weight == 3.0 )
				Weight = 1.0;
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}