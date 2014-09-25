using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0x13FB, 0x13FA )]
	public class LargeBattleAxe : BaseAxe
	{
        //public override int NiveauAttirail { get { return 4; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.WhirlwindAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.BleedAttack; } }

        public override int DefStrengthReq { get { return Hache_Force4; } }
        public override int DefMinDamage { get { return Hache_MinDam4; } }
        public override int DefMaxDamage { get { return Hache_MaxDam4; } }
        public override int DefSpeed { get { return Hache_Vitesse; } }

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