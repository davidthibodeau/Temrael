using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0xf45, 0xf46 )]
    public class ExecutionersAxe : BasePoleArm
	{
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int DefStrengthReq { get { return Bardiche_Force4; } }
        public override int DefMinDamage { get { return Bardiche_MinDam4; } }
        public override int DefMaxDamage { get { return Bardiche_MaxDam4; } }
        public override int DefSpeed { get { return Bardiche_Vitesse; } }

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