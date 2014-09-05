using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1407, 0x1406 )]
	public class WarMace : BaseBashing
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.BleedAttack; } }

        public override int AosStrengthReq { get { return Masse_Force2; } }
        public override int AosMinDamage { get { return Masse_MinDam2; } }
        public override int AosMaxDamage { get { return Masse_MaxDam2; } }
        public override double AosSpeed { get { return Masse_Vitesse; } }
        public override float MlSpeed { get { return 2.75f; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 110; } }

		[Constructable]
		public WarMace() : base( 0x1407 )
		{
			Weight = 17.0;
            Name = "Mace de Guerre";
		}

		public WarMace( Serial serial ) : base( serial )
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