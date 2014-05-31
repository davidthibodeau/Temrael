using System;
using Server;

namespace Server.Items
{
	public class WoodenKiteShield : BaseShield
	{
        public override int NiveauAttirail { get { return 3; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def3; } }
        public override int BaseContondantResistance { get { return Bouclier_Def3; } }
        public override int BaseTranchantResistance { get { return Bouclier_Def3; } }
        public override int BasePerforantResistance { get { return Bouclier_Def3; } }
        public override int BaseMagieResistance { get { return Bouclier_Def3; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite3; } }
        public override int InitMaxHits { get { return Bouclier_MaxDurabilite3; } }

        public override int AosStrReq { get { return Bouclier_Force3; } }

		public override int ArmorBase{ get{ return 12; } }

		[Constructable]
		public WoodenKiteShield() : base( 0x1B79 )
		{
			Weight = 5.0;
            Name = "Bouclier de Bois";
		}

		public WoodenKiteShield( Serial serial ) : base(serial)
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Weight == 7.0 )
				Weight = 5.0;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
