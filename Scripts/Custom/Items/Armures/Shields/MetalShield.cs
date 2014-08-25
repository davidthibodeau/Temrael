using System;
using Server;

namespace Server.Items
{
	public class MetalShield : BaseShield
	{
        //public override int NiveauAttirail { get { return 2; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def2; } }
        public override int BaseContondantResistance { get { return Bouclier_Def2; } }
        public override int BaseTranchantResistance { get { return Bouclier_Def2; } }
        public override int BasePerforantResistance { get { return Bouclier_Def2; } }
        public override int BaseMagieResistance { get { return Bouclier_Def2; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite2; } }
        public override int InitMaxHits { get { return Bouclier_MaxDurabilite2; } }

        public override int AosStrReq { get { return Bouclier_Force2; } }

		public override int ArmorBase{ get{ return 11; } }

		[Constructable]
		public MetalShield() : base( 0x1B7B )
		{
			Weight = 6.0;
            Name = "Bouclier";
		}

		public MetalShield( Serial serial ) : base(serial)
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
