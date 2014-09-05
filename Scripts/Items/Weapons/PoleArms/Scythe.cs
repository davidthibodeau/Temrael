using System;
using Server.Network;
using Server.Items;
using Server.Engines.Harvest;

namespace Server.Items
{
	[FlipableAttribute( 0x26BA, 0x26C4 )]
	public class Scythe : BasePoleArm
	{
        //public override int NiveauAttirail { get { return 2; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.BleedAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Bardiche_Force2; } }
        public override int AosMinDamage { get { return Bardiche_MinDam2; } }
        public override int AosMaxDamage { get { return Bardiche_MaxDam2; } }
        public override double AosSpeed { get { return Bardiche_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 100; } }

		public override HarvestSystem HarvestSystem{ get{ return null; } }

		[Constructable]
		public Scythe() : base( 0x26BA )
		{
			Weight = 5.0;
            Name = "Faux";
		}

		public Scythe( Serial serial ) : base( serial )
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

			if ( Weight == 15.0 )
				Weight = 5.0;
		}
	}
}