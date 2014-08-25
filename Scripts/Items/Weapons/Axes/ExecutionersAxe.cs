using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0xf45, 0xf46 )]
    public class ExecutionersAxe : BasePoleArm
	{
        //public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Bardiche_Force4; } }
        public override int AosMinDamage { get { return Bardiche_MinDam4; } }
        public override int AosMaxDamage { get { return Bardiche_MaxDam4; } }
        public override double AosSpeed { get { return Bardiche_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

		public override int OldStrengthReq{ get{ return 35; } }
		public override int OldMinDamage{ get{ return 6; } }
		public override int OldMaxDamage{ get{ return 33; } }
		public override int OldSpeed{ get{ return 37; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 70; } }

		[Constructable]
		public ExecutionersAxe() : base( 0xF45 )
		{
			Weight = 8.0;
            Name = "Gardiche";
		}

		public ExecutionersAxe( Serial serial ) : base( serial )
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