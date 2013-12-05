using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1410, 0x1417 )]
	public class PlateArms : BaseArmor
	{
        public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return Plaque_Brassards; } }
        public override int BaseContondantResistance { get { return Plaque_Brassards_Contondant; } }
        public override int BaseTranchantResistance { get { return Plaque_Brassards_Tranchant; } }
        public override int BasePerforantResistance { get { return Plaque_Brassards_Perforant; } }
        public override int BaseMagieResistance { get { return Plaque_Brassards_Magique; } }

        public override int InitMinHits { get { return Plaque_MinDurabilite; } }
        public override int InitMaxHits { get { return Plaque_MaxDurabilite; } }

        public override int AosStrReq { get { return Plaque_Brassards_Force; } }
		public override int OldStrReq{ get{ return 40; } }

		public override int OldDexBonus{ get{ return -2; } }

		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public PlateArms() : base( 0x1410 )
		{
			Weight = 5.0;
		}

		public PlateArms( Serial serial ) : base( serial )
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
				Weight = 5.0;
		}
	}
}