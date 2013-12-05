using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1405, 0x1404 )]
	public class WarFork : BaseSpear
	{
        public override int NiveauAttirail { get { return 4; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.BleedAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Disarm; } }

        public override int AosStrengthReq { get { return Lance_Force4; } }
        public override int AosMinDamage { get { return Lance_MinDam4; } }
        public override int AosMaxDamage { get { return Lance_MaxDam4; } }
        public override double AosSpeed { get { return Lance_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

		public override int OldStrengthReq{ get{ return 35; } }
		public override int OldMinDamage{ get{ return 4; } }
		public override int OldMaxDamage{ get{ return 32; } }
		public override int OldSpeed{ get{ return 45; } }

		public override int DefHitSound{ get{ return 0x236; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 110; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Pierce1H; } }

		[Constructable]
		public WarFork() : base( 0x1405 )
		{
			Weight = 9.0;
            Name = "Hastal";
		}

		public WarFork( Serial serial ) : base( serial )
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