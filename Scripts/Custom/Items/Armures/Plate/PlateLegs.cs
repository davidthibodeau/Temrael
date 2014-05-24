using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1411, 0x141a )]
	public class PlateLegs : BaseArmor
	{
        public override int NiveauAttirail { get { return Plaque_Niveau; } }

        public override int BasePhysicalResistance { get { return Plaque_Physique; } }
        public override int BaseContondantResistance { get { return Plaque_Contondant; } }
        public override int BaseTranchantResistance { get { return Plaque_Tranchant; } }
        public override int BasePerforantResistance { get { return Plaque_Perforant; } }
        public override int BaseMagieResistance { get { return Plaque_Magique; } }

        public override int InitMinHits { get { return Plaque_MinDurabilite; } }
        public override int InitMaxHits { get { return Plaque_MaxDurabilite; } }

        public override int AosStrReq { get { return Plaque_Force; } }

		public override int OldStrReq{ get{ return 60; } }
		public override int OldDexBonus{ get{ return -6; } }

		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public PlateLegs() : base( 0x1411 )
		{
			Weight = 7.0;
		}

		public PlateLegs( Serial serial ) : base( serial )
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