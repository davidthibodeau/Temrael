using System;
using Server;
using Server.Items;
using Server.Targets;
using Server.Engines.Combat;

namespace Server.Items
{
	public abstract class BaseKatar : BaseMeleeWeapon
	{
        public override int DefHitSound { get { return 0x23B; } }
        public override int DefMissSound { get { return 0x238; } }

        public override WeaponType DefType { get { return WeaponType.Slashing; } }
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Slash1H; } }

        public override CombatStrategy Strategy { get { return StrategyPerforante.Strategy; } }

		public BaseKatar( int itemID ) : base( itemID )
		{
            Layer = Layer.TwoHanded;
		}

		public BaseKatar( Serial serial ) : base( serial )
		{
            Layer = Layer.TwoHanded;
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