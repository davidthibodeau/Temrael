using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1c06, 0x1c07 )]
	public class FemaleLeatherChest : BaseArmor
	{
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

        public override double BasePhysicalResistance { get { return ArmorLeather.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ArmorLeather.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorLeather.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorLeather.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorLeather.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorLeather.malus_Dex; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override bool AllowMaleWearer{ get{ return false; } }

		[Constructable]
		public FemaleLeatherChest() : base( 0x1C06 )
		{
			Weight = 1.0;
		}

		public FemaleLeatherChest( Serial serial ) : base( serial )
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