using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x143B, 0x143A )]
	public class Maul : BaseBashing
	{
        //public override int NiveauAttirail { get { return 3; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }

        public override int AosStrengthReq { get { return Masse_Force3; } }
        public override int AosMinDamage { get { return Masse_MinDam3; } }
        public override int AosMaxDamage { get { return Masse_MaxDam3; } }
        public override double AosSpeed { get { return Masse_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 70; } }

		[Constructable]
		public Maul() : base( 0x143B )
		{
			Weight = 10.0;
		}

		public Maul( Serial serial ) : base( serial )
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

			if ( Weight == 14.0 )
				Weight = 10.0;
		}
	}
}