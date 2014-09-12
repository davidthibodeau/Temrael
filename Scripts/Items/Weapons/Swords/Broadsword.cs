using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xF5E, 0xF5F )]
	public class Broadsword : BaseSword
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }

        public override int AosStrengthReq { get { return Lame_Force0; } }
        public override int AosMinDamage { get { return Lame_MinDam0; } }
        public override int AosMaxDamage { get { return Lame_MaxDam0; } }
        public override int DefSpeed { get { return Lame_Vitesse; } }

		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 100; } }

		[Constructable]
		public Broadsword() : base( 0xF5E )
		{
			Weight = 6.0;
            Name = "Épée";
		}

		public Broadsword( Serial serial ) : base( serial )
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