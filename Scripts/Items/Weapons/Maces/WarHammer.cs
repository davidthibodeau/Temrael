using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1439, 0x1438 )]
	public class WarHammer : BaseBashing
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.WhirlwindAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.CrushingBlow; } }

        public override int DefStrengthReq { get { return Marteau_Force4; } }
        public override int DefMinDamage { get { return Marteau_MinDam4; } }
        public override int DefMaxDamage { get { return Marteau_MaxDam4; } }
        public override int DefSpeed { get { return Marteau_Vitesse; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 110; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Bash2H; } }

		[Constructable]
		public WarHammer() : base( 0x1439 )
		{
			Weight = 10.0;
			Layer = Layer.TwoHanded;
            Name = "Marteau";
		}

		public WarHammer( Serial serial ) : base( serial )
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