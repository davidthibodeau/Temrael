using System;
using Server;
using Server.Items;
using Server.Engines.Combat;

namespace Server.Items
{
	public abstract class BaseBashing : BaseMeleeWeapon
	{
		public override int DefHitSound{ get{ return 0x233; } }
		public override int DefMissSound{ get{ return 0x239; } }

		public override WeaponType DefType{ get{ return WeaponType.Bashing; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Bash1H; } }

        public override CombatStrategy Strategy { get { return StrategyContondante.Strategy; } }

		public BaseBashing( int itemID ) : base( itemID )
		{
            Layer = Layer.OneHanded;
		}

		public BaseBashing( Serial serial ) : base( serial )
		{
            Layer = Layer.OneHanded;
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