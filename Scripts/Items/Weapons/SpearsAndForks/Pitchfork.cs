using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xE87, 0xE88 )]
	public class Pitchfork : BaseSpear
	{
        //public override int NiveauAttirail { get { return 1; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.BleedAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Trident_Force1; } }
        public override int AosMinDamage { get { return Trident_MinDam1; } }
        public override int AosMaxDamage { get { return Trident_MaxDam1; } }
        public override double AosSpeed { get { return Trident_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

		[Constructable]
		public Pitchfork() : base( 0xE87 )
		{
			Weight = 11.0;
            Name = "Fourche";
		}

		public Pitchfork( Serial serial ) : base( serial )
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

			if ( Weight == 10.0 )
				Weight = 11.0;
		}
	}
}