using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13cc, 0x13d3 )]
	public class LeatherChest : BaseArmor
	{
        public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return Leather_Cuirasse; } }
        public override int BaseContondantResistance { get { return Leather_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return Leather_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return Leather_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return Leather_Cuirasse_Magique; } }

        public override int InitMinHits { get { return Leather_MinDurabilite; } }
        public override int InitMaxHits { get { return Leather_MaxDurabilite; } }

        public override int AosStrReq { get { return Leather_Cuirasse_Force; } }
		public override int OldStrReq{ get{ return 15; } }

		public override int ArmorBase{ get{ return 13; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		[Constructable]
		public LeatherChest() : base( 0x13CC )
		{
			Weight = 6.0;
		}

		public LeatherChest( Serial serial ) : base( serial )
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