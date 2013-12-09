using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0x13FB, 0x13FA )]
	public class LargeBattleAxe : BaseAxe
	{
        public override int NiveauAttirail { get { return 4; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.WhirlwindAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.BleedAttack; } }

        public override int AosStrengthReq { get { return Hache_Force4; } }
        public override int AosMinDamage { get { return Hache_MinDam4; } }
        public override int AosMaxDamage { get { return Hache_MaxDam4; } }
        public override double AosSpeed { get { return Hache_Vitesse; } }
        public override float MlSpeed { get { return 3.00f; } }

		public override int OldStrengthReq{ get{ return 40; } }
		public override int OldMinDamage{ get{ return 6; } }
		public override int OldMaxDamage{ get{ return 38; } }
		public override int OldSpeed{ get{ return 30; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 70; } }

		[Constructable]
		public LargeBattleAxe() : base( 0x13FB )
		{
			Weight = 6.0;
            Name = "Hache Barbare";
		}

		public LargeBattleAxe( Serial serial ) : base( serial )
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