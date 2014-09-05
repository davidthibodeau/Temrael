using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x143E, 0x143F )]
	public class Halberd : BasePoleArm
	{
        //public override int NiveauAttirail { get { return 2; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.WhirlwindAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }

        public override int AosStrengthReq { get { return Hallebarde_Force2; } }
        public override int AosMinDamage { get { return Hallebarde_MinDam2; } }
        public override int AosMaxDamage { get { return Hallebarde_MaxDam2; } }
        public override double AosSpeed { get { return Hallebarde_Vitesse; } }
		public override float MlSpeed{ get{ return 4.25f; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 80; } }

		[Constructable]
		public Halberd() : base( 0x143E )
		{
			Weight = 16.0;
            Name = "Hallebarde";
		}

		public Halberd( Serial serial ) : base( serial )
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