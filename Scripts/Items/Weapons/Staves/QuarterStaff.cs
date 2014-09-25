using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xE89, 0xE8a )]
	public class QuarterStaff : BaseStaff
	{
        //public override int NiveauAttirail { get { return 0; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }

		public override int DefStrengthReq{ get{ return 30; } }
		public override int DefMinDamage{ get{ return 11; } }
		public override int DefMaxDamage{ get{ return 14; } }
		public override int DefSpeed{ get{ return 48; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 60; } }

		[Constructable]
		public QuarterStaff() : base( 0xE89 )
		{
			Weight = 4.0;
		}

		public QuarterStaff( Serial serial ) : base( serial )
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