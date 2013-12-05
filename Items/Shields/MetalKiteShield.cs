using System;
using Server;

namespace Server.Items
{
	public class MetalKiteShield : BaseShield, IDyable
	{
        public override int NiveauAttirail { get { return 4; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def4; } }
        public override int BaseContondantResistance { get { return Resistances_Inferior0; } }
        public override int BaseTranchantResistance { get { return Resistances_Average0; } }
        public override int BasePerforantResistance { get { return Resistances_Inferior0; } }
        public override int BaseMagieResistance { get { return Resistances_Inferior0; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite4; } }
        public override int InitMaxHits { get { return Bouclier_MaxDurabilite4; } }

        public override int AosStrReq { get { return Bouclier_Force4; } }

		public override int ArmorBase{ get{ return 16; } }

		[Constructable]
		public MetalKiteShield() : base( 0x1B74 )
		{
			Weight = 7.0;
		}

		public MetalKiteShield( Serial serial ) : base(serial)
		{
		}

		public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
				return false;

			Hue = sender.Hue;

			return true;
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Weight == 5.0 )
				Weight = 7.0;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
