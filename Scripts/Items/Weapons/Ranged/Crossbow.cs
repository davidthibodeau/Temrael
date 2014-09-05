using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xF50, 0xF4F )]
	public class Crossbow : BaseRanged
	{
		public override int EffectID{ get{ return 0x1BFE; } }
		public override Type AmmoType{ get{ return typeof( Bolt ); } }
		public override Item Ammo{ get{ return new Bolt(); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return Arbalete_Force2; } }
        public override int AosMinDamage { get { return Arbalete_MinDam2; } }
        public override int AosMaxDamage { get { return Arbalete_MaxDam2; } }
        public override double AosSpeed { get { return Arbalete_Vitesse; } }
        public override float MlSpeed { get { return 4.50f; } }

		public override int DefMaxRange{ get{ return 8; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 80; } }

		[Constructable]
		public Crossbow() : base( 0xF50 )
		{
			Weight = 7.0;
			Layer = Layer.TwoHanded;
            Name = "Arbalète à Méchanisme";
		}

		public Crossbow( Serial serial ) : base( serial )
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