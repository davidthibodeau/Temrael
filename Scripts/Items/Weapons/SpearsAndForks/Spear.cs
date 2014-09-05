using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xF62, 0xF63 )]
	public class Spear : BaseSpear
	{
        //public override int NiveauAttirail { get { return 1; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return Lance_Force1; } }
        public override int AosMinDamage { get { return Lance_MinDam1; } }
        public override int AosMaxDamage { get { return Lance_MaxDam1; } }
        public override double AosSpeed { get { return Lance_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 80; } }

		[Constructable]
		public Spear() : base( 0xF62 )
		{
			Weight = 7.0;
            Name = "Lance";
		}

		public Spear( Serial serial ) : base( serial )
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