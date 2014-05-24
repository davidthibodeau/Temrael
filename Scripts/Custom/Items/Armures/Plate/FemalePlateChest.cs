using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1c04, 0x1c05 )]
	public class FemalePlateChest : BaseArmor
	{
        public override int NiveauAttirail { get { return Plaque_Niveau; } }

        public override Layer Layer
        {
            get
            {
                return Server.Layer.MiddleTorso;
            }
            set
            {
                base.Layer = value;
            }
        }

        public override int BasePhysicalResistance { get { return Plaque_Physique; } }
        public override int BaseContondantResistance { get { return Plaque_Contondant; } }
        public override int BaseTranchantResistance { get { return Plaque_Tranchant; } }
        public override int BasePerforantResistance { get { return Plaque_Perforant; } }
        public override int BaseMagieResistance { get { return Plaque_Magique; } }

        public override int InitMinHits { get { return Plaque_MinDurabilite; } }
        public override int InitMaxHits { get { return Plaque_MaxDurabilite; } }

        public override int AosStrReq { get { return Plaque_Force; } }
		public override int OldStrReq{ get{ return 45; } }

		public override int OldDexBonus{ get{ return -5; } }

		public override bool AllowMaleWearer{ get{ return false; } }

		public override int ArmorBase{ get{ return 30; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public FemalePlateChest() : base( 0x1C04 )
		{
			Weight = 4.0;
		}

		public FemalePlateChest( Serial serial ) : base( serial )
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
				Weight = 4.0;
		}
	}
}