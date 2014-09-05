using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0x1443, 0x1442 )]
	public class TwoHandedAxe : BaseAxe
	{
        //public override int NiveauAttirail { get { return 3; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ShadowStrike; } }

        public override int AosStrengthReq { get { return Hache_Force3; } }
        public override int AosMinDamage { get { return Hache_MinDam3; } }
        public override int AosMaxDamage { get { return Hache_MaxDam3; } }
        public override double AosSpeed { get { return Hache_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 90; } }

		[Constructable]
		public TwoHandedAxe() : base( 0x1443 )
		{
			Weight = 8.0;
            Name = "Hache Double";
		}

		public TwoHandedAxe( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}