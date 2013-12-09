using System;
using Server;

namespace Server.Items
{
	public class HeaterShield : BaseShield
	{
        public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def6; } }
        public override int BaseContondantResistance { get { return 0; } }
        public override int BaseTranchantResistance { get { return 0; } }
        public override int BasePerforantResistance { get { return 0; } }
        public override int BaseMagieResistance { get { return 0; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite6; } }
        public override int InitMaxHits { get { return Bouclier_MaxDurabilite6; } }

        public override int AosStrReq { get { return Bouclier_Force6; } }

		public override int ArmorBase{ get{ return 23; } }

		[Constructable]
		public HeaterShield() : base( 0x1B76 )
		{
			Weight = 8.0;
		}

		public HeaterShield( Serial serial ) : base(serial)
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
