using System;
using Server;

namespace Server.Items
{
	public class Bascinet : BaseArmor
	{
        //public override int NiveauAttirail { get { return Ring_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorRingmail.resistance_Physique; } }
        public override int BaseMagieResistance { get { return ArmorRingmail.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorRingmail.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorRingmail.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorRingmail.force_Requise; } }
        public override int AosDexBonus { get { return ArmorRingmail.malus_Dex; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public Bascinet() : base( 0x140C )
		{
			Weight = 5.0;
		}

		public Bascinet( Serial serial ) : base( serial )
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