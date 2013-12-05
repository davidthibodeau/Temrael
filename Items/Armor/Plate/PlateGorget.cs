using System;
using Server.Items;

namespace Server.Items
{
	public class PlateGorget : BaseArmor
	{
        public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return Plaque_Gorget; } }
        public override int BaseContondantResistance { get { return Plaque_Gorget_Contondant; } }
        public override int BaseTranchantResistance { get { return Plaque_Gorget_Tranchant; } }
        public override int BasePerforantResistance { get { return Plaque_Gorget_Perforant; } }
        public override int BaseMagieResistance { get { return Plaque_Gorget_Magique; } }

        public override int InitMinHits { get { return Plaque_MinDurabilite; } }
        public override int InitMaxHits { get { return Plaque_MaxDurabilite; } }

        public override int AosStrReq { get { return Plaque_Gorget_Force; } }
		public override int OldStrReq{ get{ return 30; } }

		public override int OldDexBonus{ get{ return -1; } }

		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public PlateGorget() : base( 0x1413 )
		{
			Weight = 2.0;
		}

		public PlateGorget( Serial serial ) : base( serial )
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