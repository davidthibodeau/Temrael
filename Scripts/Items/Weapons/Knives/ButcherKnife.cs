using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13F6, 0x13F7 )]
	public class ButcherKnife : BaseKnife
	{
        //public override int NiveauAttirail { get { return 0; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.InfectiousStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Disarm; } }

        public override int AosStrengthReq { get { return Dague_Force0; } }
        public override int AosMinDamage { get { return Dague_MinDam0; } }
        public override int AosMaxDamage { get { return Dague_MaxDam0; } }
        public override double AosSpeed { get { return Dague_Vitesse; } }
        public override float MlSpeed { get { return 2.00f; } }

		public override int OldStrengthReq{ get{ return 5; } }
		public override int OldMinDamage{ get{ return 2; } }
		public override int OldMaxDamage{ get{ return 14; } }
		public override int OldSpeed{ get{ return 40; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 40; } }

		[Constructable]
		public ButcherKnife() : base( 0x13F6 )
		{
			Weight = 1.0;
            Name = "Couteau de Boucher";
		}

		public ButcherKnife( Serial serial ) : base( serial )
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