using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xF4D, 0xF4E )]
	public class Bardiche : BasePoleArm
	{
        //public override int NiveauAttirail { get { return 1; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Bardiche_Force1; } }
        public override int AosMinDamage { get { return Bardiche_MinDam1; } }
        public override int AosMaxDamage { get { return Bardiche_MaxDam1; } }
        public override double AosSpeed { get { return Bardiche_Vitesse; } }
		public override float MlSpeed{ get{ return 3.75f; } }

		public override int OldStrengthReq{ get{ return 40; } }
		public override int OldMinDamage{ get{ return 5; } }
		public override int OldMaxDamage{ get{ return 43; } }
		public override int OldSpeed{ get{ return 26; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 100; } }

		[Constructable]
		public Bardiche() : base( 0xF4D )
		{
			Weight = 7.0;
            Name = "Bardiche";
		}

		public Bardiche( Serial serial ) : base( serial )
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