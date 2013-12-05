using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1c0a, 0x1c0b )]
	public class LeatherBustierArms : BaseArmor
	{
        public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return Leather_Brassards; } }
		public override int BaseContondantResistance{ get{ return Leather_Brassards_Contondant; } }
        public override int BaseTranchantResistance { get { return Leather_Brassards_Tranchant; } }
        public override int BasePerforantResistance { get { return Leather_Brassards_Perforant; } }
        public override int BaseMagieResistance { get { return Leather_Brassards_Magique; } }

        public override int InitMinHits { get { return Leather_MinDurabilite; } }
        public override int InitMaxHits { get { return Leather_MaxDurabilite; } }

        public override int AosStrReq { get { return Leather_Brassards_Force; } }
		public override int OldStrReq{ get{ return 15; } }

		public override int ArmorBase{ get{ return 13; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		public override bool AllowMaleWearer{ get{ return false; } }

		[Constructable]
		public LeatherBustierArms() : base( 0x1C0A )
		{
			Weight = 1.0;
		}

		public LeatherBustierArms( Serial serial ) : base( serial )
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